﻿// Copyright 2020 zmjack
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;

namespace LinqSharp
{
    public static partial class XIEnumerable
    {
        public static TResult Sum<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    TResult current = selector(enumerator.Current);
                    if (current is null) continue;

                    var op_Addition = GetOpAddition<TResult>();
                    if (op_Addition is null) throw new InvalidOperationException($"There is no matching op_Addition method for {typeof(TResult).FullName}.");

                    TResult sum = current;
                    while (enumerator.MoveNext())
                    {
                        current = selector(enumerator.Current);
                        if (current is not null)
                        {
                            sum = op_Addition(sum, current);
                        }
                    }
                    return sum;
                }
            }
            return default;
        }
        public static TSource Sum<TSource>(this IEnumerable<TSource> source) => Sum(source, x => x);

    }

}
