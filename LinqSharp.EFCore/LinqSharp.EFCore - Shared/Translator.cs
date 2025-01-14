﻿// Copyright 2020 zmjack
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
#if EFCore2
using Microsoft.EntityFrameworkCore.Query.Expressions;
#else
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using NStandard;
using System.Data;
#endif

namespace LinqSharp.EFCore
{
    public static class Translator
    {
#if EFCore2
        public static ConstantExpression Constant(object value)
        {
            return Expression.Constant(value);
        }

        public static SqlFragmentExpression Fragment(string sql)
        {
            return new SqlFragmentExpression(sql);
        }

        public static SqlFunctionExpression Function<TRet>(string name, params Expression[] arguments)
        {
            return Function<TRet>(name, arguments as IEnumerable<Expression>);
        }
        public static SqlFunctionExpression Function<TRet>(string name, IEnumerable<Expression> arguments)
        {
            var returnType = typeof(TRet);
            return new SqlFunctionExpression(name, returnType, arguments);
        }

        public static SqlFunctionExpression Function<TRet>(string schema, string name, params Expression[] arguments)
        {
            return Function<TRet>(schema, name, arguments as IEnumerable<Expression>);
        }
        public static SqlFunctionExpression Function<TRet>(string schema, string name, IEnumerable<Expression> arguments)
        {
            var returnType = typeof(TRet);
            return new SqlFunctionExpression(name, returnType, schema, arguments);
        }
#else
        private static RelationalTypeMapping GetTypeMapping(Type type)
        {
            RelationalTypeMapping typeMapping = type switch
            {
                Type _ when type == typeof(char) => new CharTypeMapping("char", DbType.String),
                Type _ when type == typeof(bool) => new BoolTypeMapping("bool", DbType.Boolean),
                Type _ when type == typeof(byte) => new ByteTypeMapping("byte", DbType.Byte),
                Type _ when type == typeof(sbyte) => new SByteTypeMapping("sbyte", DbType.SByte),
                Type _ when type == typeof(short) => new ShortTypeMapping("short", DbType.Int16),
                Type _ when type == typeof(ushort) => new UShortTypeMapping("ushort", DbType.UInt16),
                Type _ when type == typeof(int) => new IntTypeMapping("int", DbType.Int32),
                Type _ when type == typeof(uint) => new UIntTypeMapping("uint", DbType.UInt32),
                Type _ when type == typeof(long) => new LongTypeMapping("long", DbType.Int64),
                Type _ when type == typeof(ulong) => new ULongTypeMapping("ulong", DbType.UInt64),
                Type _ when type == typeof(float) => new FloatTypeMapping("float", DbType.Single),
                Type _ when type == typeof(double) => new DoubleTypeMapping("double", DbType.Double),
                Type _ when type == typeof(string) => new StringTypeMapping("string", DbType.String),
                Type _ when type == typeof(decimal) => new DecimalTypeMapping("decimal", DbType.Decimal),
                Type _ when type == typeof(DateTime) => new DateTimeTypeMapping("DateTime", DbType.DateTime),
                _ => throw new NotSupportedException($"Type mapping is not supported to {type.FullName}."),
            };
            return typeMapping;
        }

        public static SqlConstantExpression Constant(object value)
        {
            var typeMapping = GetTypeMapping(value.GetType());
            return new SqlConstantExpression(Expression.Constant(value), typeMapping);
        }

        public static SqlFragmentExpression Fragment(string sql)
        {
#if EFCore30
            return typeof(SqlFragmentExpression).CreateInstance(sql) as SqlFragmentExpression;
#else
            return new SqlFragmentExpression(sql);
#endif
        }

        public static SqlFunctionExpression Function<TRet>(string name, params SqlExpression[] arguments)
        {
            return Function<TRet>(name, arguments as IEnumerable<SqlExpression>);
        }
        public static SqlFunctionExpression Function<TRet>(string name, IEnumerable<SqlExpression> arguments)
        {
            var returnType = typeof(TRet);
            var typeMapping = GetTypeMapping(returnType);
            return SqlFunctionExpression.Create(name, arguments, returnType, typeMapping);
        }

        public static SqlFunctionExpression Function<TRet>(string schema, string name, params SqlExpression[] arguments)
        {
            return Function<TRet>(schema, name, arguments as IEnumerable<SqlExpression>);
        }
        public static SqlFunctionExpression Function<TRet>(string schema, string name, IEnumerable<SqlExpression> arguments)
        {
            var returnType = typeof(TRet);
            var typeMapping = GetTypeMapping(returnType);
            return SqlFunctionExpression.Create(schema, name, arguments, returnType, typeMapping);
        }
#endif
    }
}
