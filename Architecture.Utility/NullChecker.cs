using System;
using System.Globalization;

namespace Architecture.Utility
{
    public static class NullChecker
    {
        #region STRING
        public static bool CheckIsNull(this string T) => string.IsNullOrEmpty(T) ? true : false;
        public static string ToNull(this string T) => string.IsNullOrEmpty(T) ? null : T;
        public static string ToSafeString(this string T) => string.IsNullOrEmpty(T) ? string.Empty : T;
        #endregion

        #region OBJECT
        public static T NullToEmpty<T>(this T o) where T : new() => o == null ? new T() : o;
        public static bool CheckIsNull<T>(this T o) => o == null ? true : false;
        public static bool CheckIsNull(this object o) => o == null ? true : false;
        #endregion

        #region BOOL
        public static bool CheckIsNull(this bool? T) => !T.HasValue;
        public static bool NullToFalse(this bool? T) => T.HasValue ? T.Value : false;

        #endregion

        #region INT
        public static bool CheckIsNull(this int? T) => !T.HasValue;
        public static int? CheckIs0(this int T) => T == 0 ? (int?)null : T;
        public static int? CheckIs0(this int? T) => T.HasValue ? (T.Value == 0 ? null : T) : null;
        public static string ToNumberString(this int T) => (T == 0 ? string.Empty : String.Format("{0:n}", T));
        public static string ToNumberCultureString(this int T, string culture) => (T == 0 ? string.Empty : T.ToString("N", new CultureInfo(culture)));
        #endregion

        #region LONG
        public static bool CheckIsNull(this long? T) => !T.HasValue;
        public static long? CheckIs0(this long T) => T == 0 ? (long?)null : T;
        public static long? CheckIs0(this long? T) => T.HasValue ? (T.Value == 0 ? null : T) : null;
        public static string ToNumberString(this long T) => (T == 0 ? string.Empty : String.Format("{0:n}", T));
        public static string ToNumberCultureString(this long T, string culture) => (T == 0 ? string.Empty : T.ToString("N", new CultureInfo(culture)));
        #endregion

        #region DECIMAL
        public static bool CheckIsNull(this decimal? T) => !T.HasValue;
        public static decimal? CheckIs0(this decimal T) => T == 0 ? (decimal?)null : T;
        public static decimal? CheckIs0(this decimal? T) => T.HasValue ? (T.Value == 0 ? null : T) : null;
        public static string ToNumberString(this decimal T) => (T == 0 ? string.Empty : String.Format("{0:n}", T));
        public static string ToNumberCultureString(this decimal T, string culture) => (T == 0 ? string.Empty : T.ToString("N", new CultureInfo(culture)));
        #endregion

        #region DATETIME
        public static DateTime? CheckMinValue(this DateTime? T) => T.HasValue ? ((T.Value == DateTime.MinValue) ? null : T) : null;
        public static DateTime? CheckIsNull(this DateTime T) => T == DateTime.MinValue ? (DateTime?)null : T;
        #endregion
    }
}

