using System;
namespace FirestoreRe.iOS.Services
{
    public static class FirestoreService
    {
        public static Firebase.CloudFirestore.Firestore Instance
        {
            get
            {
                return Firebase.CloudFirestore.Firestore.SharedInstance;
            }
        }

        public static void Init()
        {
            Firebase.Core.App.Configure();
        }
    }
}
