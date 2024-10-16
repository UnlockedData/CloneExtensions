﻿using System;
using System.Linq;
using System.Reflection;
namespace UnlockedData.CloneExtensions
{
    static class TypeExtensions
    {
        public static bool IsPrimitiveOrKnownImmutable(this Type type)
        {
            return type.IsPrimitive() || CloneFactory.KnownImmutableTypes.Contains(type);
        }

        public static bool UsePrimitive(this Type type)
        {
            return type.IsPrimitiveOrKnownImmutable() || typeof(Delegate).IsAssignableFrom(type);
        }


        public static ConstructorInfo[] GetConstructors(this Type type)
        {
            return type.GetTypeInfo().GetConstructors();
        }

        public static ConstructorInfo GetConstructor(this Type type, params Type[] types)
        {
            return type.GetTypeInfo().GetConstructor(types);
        }

        public static Type[] GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().GetInterfaces();
        }

        public static bool IsAssignableFrom(this Type type, Type c)
        {
            return type.GetTypeInfo().IsAssignableFrom(c);
        }

        public static Type[] GetGenericArguments(this Type type)
        {
            return type.GetTypeInfo().IsGenericTypeDefinition
                ? type.GetTypeInfo().GenericTypeParameters
                : type.GetTypeInfo().GenericTypeArguments;
        }

        public static bool IsAbstract(this Type type)
        {
            return type.GetTypeInfo().IsAbstract;
        }

        public static bool IsPrimitive(this Type type)
        {
            return type.GetTypeInfo().IsPrimitive;
        }

        public static bool IsGenericType(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        public static bool IsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        public static bool IsInterface(this Type type)
        {
            return type.GetTypeInfo().IsInterface;
        }

    }
}
