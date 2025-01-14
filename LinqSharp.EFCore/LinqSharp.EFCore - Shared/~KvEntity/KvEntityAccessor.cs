﻿// Copyright 2020 zmjack
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// See the LICENSE file in the project root for more information.

using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using NStandard;
using System;
using System.Linq;

namespace LinqSharp.EFCore
{
    public static class KvEntityAccessor
    {
        public static KvEntityAccessor<TKvEntity> Create<TKvEntity>(DbSet<TKvEntity> dbSet)
            where TKvEntity : KvEntity, new()
        {
            return new KvEntityAccessor<TKvEntity>(dbSet);
        }
    }

    public class KvEntityAccessor<TKvEntity>
        where TKvEntity : KvEntity, new()
    {
        private readonly DbSet<TKvEntity> DbSet;

        public KvEntityAccessor(DbSet<TKvEntity> dbSet)
        {
            DbSet = dbSet;
        }

        public TKvEntityAgent Get<TKvEntityAgent>(string item)
            where TKvEntityAgent : KvEntityAgent, new()
        {
            var accessor = new KvEntityAccessor<TKvEntityAgent, TKvEntity>(DbSet);
            return accessor.Get(item);
        }
    }

    public class KvEntityAccessor<TKvEntityAgent, TKvEntity>
        where TKvEntityAgent : KvEntityAgent, new()
        where TKvEntity : KvEntity, new()
    {
        public DbSet<TKvEntity> DbSet;

        public KvEntityAccessor(DbSet<TKvEntity> dbSet)
        {
            DbSet = dbSet;
        }

        public void EnsureItem(string item)
        {
            var defaultAgent = typeof(TKvEntityAgent).CreateInstance();
            var props = typeof(TKvEntityAgent).GetProperties();
            var ensureItems = props
                .Where(x => x.GetMethod.IsVirtual)
                .Select(x => new QueryCondition<TKvEntity>
                {
                    [c => c.Item] = item,
                    [c => c.Key] = x.Name,
                }).ToArray();

            if (ensureItems.Length == 0) throw new InvalidOperationException($"No virtual properties could be found in `{typeof(TKvEntityAgent).FullName}`.");

            DbSet.Ensure(ensureItems, option =>
            {
                option.Set = entity =>
                {
                    var prop = props.First(x => x.Name == entity.Key);
                    entity.Value = prop.GetValue(defaultAgent)?.ToString();
                };
            });
        }

        public TKvEntityAgent Get(string item)
        {
            EnsureItem(item);

            var registry = new TKvEntityAgent();
            var registryProxy = Activator.CreateInstance(typeof(KvEntityAgentProxy<TKvEntityAgent>));

            var proxy = new ProxyGenerator().CreateClassProxyWithTarget(registry, registryProxy as IInterceptor);
            proxy.Load(DbSet, item);
            return proxy;
        }

    }
}
