using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FlaUI.Custom
{
    internal static class ReflectionUtils
    {
        internal static MethodInfo GetMethodInfo(Expression<Action> methodCallExpression)
        {
            var methodCall = methodCallExpression.Body as MethodCallExpression;
            return methodCall.Method;
        }
    }
}
