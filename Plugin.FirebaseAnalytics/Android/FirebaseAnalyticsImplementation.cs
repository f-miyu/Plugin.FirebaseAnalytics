using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Plugin.CurrentActivity;

namespace Plugin.FirebaseAnalytics
{
    public class FirebaseAnalyticsImplementation : IFirebaseAnalytics
    {
        public Task<string> GetAppInstanceIdAsync()
        {
            var tcs = new TaskCompletionSource<string>();

            AnalyticsProvider.GetAnalytics().GetAppInstanceId().AddOnCompleteListener(new OnCompleteHandlerListener(task =>
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

            AnalyticsProvider.GetAnalytics().LogEvent(name, bundle);
        }

        public void SetCurrentScreen(string screenName, string screenClass)
        {
            AnalyticsProvider.GetAnalytics().SetCurrentScreen(CrossCurrentActivity.Current.Activity, screenName, screenClass);
        }

        public void SetUserId(string userId)
        {
            AnalyticsProvider.GetAnalytics().SetUserId(userId);
        }

        public void SetUserProperty(string name, string value)
        {
            AnalyticsProvider.GetAnalytics().SetUserProperty(name, value);
        }

        public void ResetAnalyticsData()
        {
            AnalyticsProvider.GetAnalytics().ResetAnalyticsData();
        }
    }
}
