using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Runtime;
using Firebase.Firestore;
using FirestoreRe.Droid.EventListeners;
using Java.Lang;

namespace FirestoreRe.Droid.Extensions
{
    public static class FirestoreExtension
    {
        // ToDo: Support more types...
        // https://firebase.google.com/docs/firestore/manage-data/data-types
        // ToDo: Add interface to add custom types
        private static Dictionary<Type, Func<Java.Lang.Object, System.Object>> TypeMapper = new Dictionary<Type, Func<Java.Lang.Object, dynamic>>
        {
            // array
            { typeof(bool), (obj) => ((Java.Lang.Boolean)obj).BooleanValue() },
            // byte
            // Date?
            // double
            // pos
            // int
            // KVP
            // null
            // reference
            { typeof(string), (obj) => obj.ToString() },
        };


        private static T Cast<T>(DocumentSnapshot doc)
        {
            var instance = Activator.CreateInstance<T>();

            var baseData = doc.Data;
            foreach (var key in baseData.Keys)
            {
                // ToDo: Error handling
                var prop = typeof(T).GetProperty(key);
                var propType = prop.PropertyType;
                prop.SetValue(instance, TypeMapper[propType](baseData[key]));
            }

            return instance;
        }

        public static Task<T> GetDocumentAsync<T>(this DocumentReference reference) where T : class
        {
            var tcs = new TaskCompletionSource<T>();

            reference
                .Get()
                .AddOnCompleteListener(new OnCompleteEventHandleListener((Android.Gms.Tasks.Task obj) =>
            {
                if (obj.IsSuccessful)
                {
                    var res = obj.GetResult(Class.FromType(typeof(DocumentSnapshot))).JavaCast<DocumentSnapshot>();
                    tcs.SetResult(Cast<T>(res));
                }
                else
                {
                    tcs.SetException(obj.Exception);
                }
            }));

            return tcs.Task;
        }

        public static Task<IEnumerable<T>> GetCollectionAsync<T>(this CollectionReference reference) where T : class
        {
            var tcs = new TaskCompletionSource<IEnumerable<T>>();

            reference
                .Get()
                .AddOnCompleteListener(new OnCompleteEventHandleListener((Android.Gms.Tasks.Task obj) =>
            {
                if (obj.IsSuccessful)
                {
                    var res = obj.GetResult(Class.FromType(typeof(QuerySnapshot))).JavaCast<QuerySnapshot>();
                    tcs.SetResult(res.Documents.Select((doc) => Cast<T>(doc)).ToList());
                }
                else
                {
                    tcs.SetException(obj.Exception);
                }
            }));

            return tcs.Task;
        }

        // ToDo: Add QueryReference
    }
}
