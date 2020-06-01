﻿using Microsoft.EntityFrameworkCore;
using NStandard;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LinqSharp.EFCore
{
    public static partial class XIQueryable
    {
        public static TEntity[] EnsureMany<TEntity>(this DbSet<TEntity> @this, EnsureCondition<TEntity>[] conditions)
            where TEntity : class, new()
        {
            return EnsureMany(@this, conditions, null);
        }

        public static TEntity[] EnsureMany<TEntity>(this DbSet<TEntity> @this, EnsureCondition<TEntity>[] conditions, Action<EnsureOptions<TEntity>> initOptions)
        where TEntity : class, new()
        {
            var options = new EnsureOptions<TEntity>();
            initOptions?.Invoke(options);

            var context = @this.GetDbContext();
            var expressions = conditions.Select(x => x.GetExpression()).ToArray();

            Expression<Func<TEntity, bool>> predicate;
            if (options.Predicate is null)
            {
                var parameter = expressions[0].Parameters[0];
                predicate = expressions.Each(exp => exp.RebindParameter(exp.Parameters[0], parameter)).LambdaJoin(Expression.OrElse);
            }
            else predicate = options.Predicate;

            var exsists = @this.Where(predicate).ToArray();
            var conditionsForAdd = conditions.Where(condition => !exsists.Any(condition.GetExpression().Compile()));

            foreach (var conditionForAdd in conditionsForAdd)
            {
                var item = new TEntity();
                foreach (var unit in conditionForAdd.UnitList)
                {
                    var prop = typeof(TEntity).GetProperty(unit.PropName);
                    prop.SetValue(item, unit.ExpectedValue);
                }
                options.SetEntity?.Invoke(item);
                context.Add(item);
            }
            context.SaveChanges();

            return @this.Where(predicate).ToArray();
        }

    }
}
