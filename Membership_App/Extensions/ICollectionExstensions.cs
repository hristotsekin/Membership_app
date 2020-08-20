﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Membership_App.Extensions
{
    public static class ICollectionExstensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(
            this ICollection<T> items, int selectedValue)
        {
            return from item in items
                select new SelectListItem
                {
                    Text = item.GetPropertyValue("Title"),
                    Value = item.GetPropertyValue("Id"),
                    Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                };
        }
    }
}