﻿using NStandard;
using System;
using System.Linq.Expressions;

namespace LinqSharp.EFCore
{
    public class EnsureConditionUnit<TEntity>
    {
        public readonly string PropName;
        public readonly object ExpectedValue;
        public readonly Expression<Func<TEntity, object>> UnitExpression;

        public EnsureConditionUnit(Expression<Func<TEntity, object>> expression, object expectedValue)
        {
            UnitExpression = expression;
            ExpectedValue = expectedValue;
            PropName = (expression.Body.For(body => (body as UnaryExpression)?.Operand ?? body) as MemberExpression).Member.Name;
        }

        public EnsureConditionUnit(string propName, object expectedValue)
        {
            var parameter = Expression.Parameter(typeof(TEntity));
            var body = Expression.Property(parameter, propName);
            UnitExpression = Expression.Lambda<Func<TEntity, object>>(body, parameter);
            ExpectedValue = expectedValue;
            PropName = propName;
        }

    }

}
