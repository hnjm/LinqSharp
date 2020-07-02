﻿using LinqSharp.Strategies;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LinqSharp
{
    public static partial class XIQueryable
    {
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> @this, string searchString, Expression<Func<TEntity, object>> searchMembers, SearchOption option = SearchOption.Contains)
        {
            return @this.XWhere(h => h.Search(searchString, searchMembers, option));
        }

        [Obsolete("This function may cause performance problems.")]
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> @this, string[] searchStrings, Expression<Func<TEntity, object>> searchMembers, SearchOption option = SearchOption.Contains)
        {
            return searchStrings.Aggregate(@this, (acc, searchString) => acc.Where(new WhereSearchStrategy<TEntity>(searchString, searchMembers, option).StrategyExpression));
        }

    }// Copyright 2020 zmjack
     // Licensed under the Apache License, Version 2.0 (the "License");
     // you may not use this file except in compliance with the License.
     // See the LICENSE file in the project root for more information.


}