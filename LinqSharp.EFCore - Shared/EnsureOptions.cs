﻿// Copyright 2020 zmjack
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq.Expressions;

namespace LinqSharp.EFCore
{
    public class EnsureOptions<TEntity> where TEntity : class, new()
    {
        public Action<TEntity> Set { get; set; }

        /// <summary>
        /// If you want to optimize the search logic, you can specify the predicate.
        /// (Note that the predicate must contain all possible records.)
        /// </summary>
        public Expression<Func<TEntity, bool>> Predicate { get; set; }
    }
}
