﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tailor_Infrastructure.Common
{
    public class Assign
    {
        public static void Partial<T, U>(T source, U dest, Func<string, object, bool> ignoreCallback = null)
        {
            foreach (var item in source.GetType().GetProperties())
            {
                var property = dest.GetType().GetProperty(item.Name);
                if (property == null)
                {
                    continue;
                }
                //var i = item.GetValue(source);
                //if (String.IsNullOrEmpty(i?.ToString())) continue;
                if (item.GetValue(source) == null) continue;
                var value = item.GetValue(source, null);
                if (ignoreCallback != null && ignoreCallback(property.Name, value))
                {
                    continue;
                }

                property.SetValue(dest, value);
            }
        }

        public static void Omit<T, U>(T source, U dest, string[] fields)
        {
            foreach (var item in source.GetType().GetProperties())
            {
                var property = dest.GetType().GetProperty(item.Name);
                if (fields.Contains(item.Name) || property == null)
                {
                    continue;
                }
                if (item.GetValue(source) == null) continue;

                property
                .SetValue(dest, source.GetType().GetProperty(item.Name).GetValue(source, null));
            }
        }
    }
}
