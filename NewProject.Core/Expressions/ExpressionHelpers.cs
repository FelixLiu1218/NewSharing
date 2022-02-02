using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Core
{
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">the type of return value</typeparam>
        /// <param name="lamba">THe expression to compile </param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }


        /// <summary>
        /// sets the underlying properties value to the given value
        /// from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">the type of value to set</typeparam>
        /// <param name="lamba"></param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lamba,T value)
        {
            //covert lamba() => some.property to some.property
            var expression = (lamba as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo) expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target,value);
        }
    }
}
