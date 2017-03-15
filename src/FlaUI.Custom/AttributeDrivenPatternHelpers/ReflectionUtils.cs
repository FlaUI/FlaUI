using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ManagedUiaCustomizationCore
{
    public static class ReflectionUtils
    {
        internal static IEnumerable<TA> GetAttributes<TA>(this MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes(typeof(TA), true).Cast<TA>();
        }

        internal static TA GetAttribute<TA>(this MemberInfo memberInfo)
        {
            return memberInfo.GetAttributes<TA>().FirstOrDefault();
        }

        internal static IEnumerable<MethodInfo> GetMethodsMarkedWith<TAttribute>(this Type type)
        {
            return from m in type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                   where m.GetAttributes<TAttribute>().Any()
                   select m;
        }

        internal static IEnumerable<PropertyInfo> GetPropertiesMarkedWith<TAttribute>(this Type type)
        {
            return from m in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                   where m.GetAttributes<TAttribute>().Any()
                   select m;
        }

        internal static IEnumerable<FieldInfo> GetStaticFieldsMarkedWith<TAttribute>(this Type type)
        {
            return from m in type.GetFields(BindingFlags.Static | BindingFlags.Public)
                   where m.GetAttributes<TAttribute>().Any()
                   select m;
        }

        public static Func<object, object> GetPropertyGetter(this PropertyInfo propInfo)
        {
            if (propInfo.GetGetMethod(false) == null)
                throw new InvalidOperationException("Given property has no public getter");
            var param = Expression.Parameter(typeof(object), "t");
            var expression = Expression.Lambda<Func<object, object>>(
                Expression.Convert(
                    Expression.MakeMemberAccess(
                        Expression.Convert(param, propInfo.DeclaringType),
                        propInfo),
                    typeof(object)),
                param);
            return expression.Compile();
        }

        public static MethodInfo GetMethodInfo(Expression<Action> methodCallExpression)
        {
            var methodCall = methodCallExpression.Body as MethodCallExpression;
            return methodCall.Method;
        }
    }
}
