using System;
using System.Linq;
using System.Web.Mvc;

namespace Architecture.Utility
{
    public static class EnumExtention
    {
        // /// <summary>
        ///// Convert to select list
        ///// </summary>
        ///// <typeparam name="TEnum">Enum type</typeparam>
        ///// <param name="enumObj">Enum</param>
        ///// <param name="markCurrentAsSelected">Mark current value as selected</param>
        ///// <returns>SelectList</returns>
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj, bool markCurrentAsSelected = true) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("An Enumeration type is required.", nameof(enumObj));
            }
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString()
            }).ToList();

            object selectedValue = null;
            if (markCurrentAsSelected)
            {
                selectedValue = Convert.ToInt32(enumObj);
            }

            return new SelectList(values, "Value", "Text", selectedValue);
        }

        // /// <summary>
        ///// Convert to select list
        ///// </summary>
        ///// <typeparam name="TEnum">Enum type</typeparam>
        ///// <param name="enumObj">Enum</param>
        ///// <param name="markCurrentAsSelected">Mark current value as selected</param>
        ///// <returns>SelectList</returns>
        public static SelectList ToIntSelectList<TEnum>(this TEnum enumObj, bool markCurrentAsSelected = true) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("An Enumeration type is required.", nameof(enumObj));
            }
            var values = Enum.GetValues(typeof(TEnum)).Cast<int>().Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = v.ToString()
            }).ToList();

            object selectedValue = null;
            if (markCurrentAsSelected)
            {
                selectedValue = Convert.ToInt32(enumObj);
            }
            //values.Add(new SelectListItem("All", "0"));

            return new SelectList(values, "Value", "Text", selectedValue);
        }
    }
}