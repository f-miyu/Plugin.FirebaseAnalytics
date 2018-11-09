using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;

namespace Plugin.FirebaseAnalytics
{
    public class FirebaseAnalyticsImplementation : IFirebaseAnalytics
    {
        public Task<string> GetAppInstanceIdAsync()
        {
            var tcs = new TaskCompletionSource<string>();

            FirebaseAnalytics.Instance.AppInstanceId.AddOnCompleteListener(new OnCompleteHandlerListener(task =>
            {
                if (task.IsSuccessful)
                {
                    tcs.SetResult(task.Result.ToString());
                }
                else
                {
                    tcs.SetException(task.Exception);
                }
            }));

            return tcs.Task;
        }

        public void LogEvent(string name, params Parameter[] parameters)
        {
            var bundle = new Bundle();
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    switch (parameter.Value)
                    {
                        case long longValue:
                            bundle.PutLong(parameter.Name, longValue);
                            break;
                        case double doubleValue:
                            bundle.PutDouble(parameter.Name, doubleValue);
                            break;
                        default:
                            bundle.PutString(parameter.Name, parameter.Value as string);
                            break;
                    }
                }
            }

            FirebaseAnalytics.Instance.LogEvent(name, bundle);
        }

        public void SetCurrentScreen(string screenName, string screenClass)
        {
            FirebaseAnalytics.Instance.SetCurrentScreen(FirebaseAnalytics.CurrentActivity, screenName, screenClass);
        }

        public void SetUserId(string userId)
        {
            FirebaseAnalytics.Instance.SetUserId(userId);
        }

        public void SetUserProperty(string name, string value)
        {
            FirebaseAnalytics.Instance.SetUserProperty(name, value);
        }
    }
}
