﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership_App.Extensions
{
    public static class ReflectionExtensions
    {
        public static string GetPropertyValue<T>(this T item, 
            string propertyName)
        {
            return item.GetType()
                .GetProperty(propertyName)
                .GetValue(item, null)
                .ToString();
        }

    }
}