using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ManagedUiaCustomizationCore
{
    public static class TypeMember<TClass>
    {
        public static PropertyInfo PropertyInfo<TProp>(Expression<Func<TClass, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;

            if (body == null)
                throw new ArgumentException("'expression' should be a property expression");

            var propInfo = body.Member as PropertyInfo;

            if (propInfo == null)
                throw new ArgumentException("'expression' should be a property expression");

            return propInfo;
        }

        public static Func<object, object> GetPropertyGetter<TProp>(Expression<Func<TClass, TProp>> expression)
        {
            var propertyInfo = PropertyInfo(expression);
            return propertyInfo.GetPropertyGetter();
        }
    }
}