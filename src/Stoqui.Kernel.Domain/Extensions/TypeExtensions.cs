﻿using System.Linq.Expressions;
using System.Reflection;

namespace Stoqui.Kernel.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static PropertyInfo GetPropertyInfo<T, TProp>(this T? objectReference, Expression<Func<T, TProp>> propertySelector)
        {
            if(objectReference == null) throw new NullReferenceException();
            
            var body = (MemberExpression)propertySelector.Body;
            return objectReference.GetType().GetProperties().FirstOrDefault(p => p.Name == body.Member.Name);
        }



    }
}
