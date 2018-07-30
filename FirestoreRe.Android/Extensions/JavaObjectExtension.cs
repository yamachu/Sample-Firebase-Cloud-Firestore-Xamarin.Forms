using System;
using Android.Runtime;

namespace FirestoreRe.Droid.Extensions
{
    public static class JavaObjectExtension
    {
        // https://stackoverflow.com/a/6607412
        public static T Cast<T>(this Java.Lang.Object obj) where T : class
        {
            var propertyInfo = obj.GetType().GetProperty("Instance");
            return propertyInfo == null ? null : propertyInfo.GetValue(obj, null) as T;
        }
    }
}
