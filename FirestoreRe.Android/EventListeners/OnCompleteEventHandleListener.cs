using System;
using Android.Gms.Tasks;

namespace FirestoreRe.Droid.EventListeners
{
    public class OnCompleteEventHandleListener : Java.Lang.Object, IOnCompleteListener
    {
        private readonly Action<Task> _completeAction;

        public OnCompleteEventHandleListener(Action<Task> completeAction)
        {
            _completeAction = completeAction;
        }

        public void OnComplete(Task task) => _completeAction(task);
    }
}
