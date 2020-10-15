using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
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
                    tcs.SetResult(task.Result.ToString()!);
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
            Bundle? bundle = null;
            if (parameters != null)
            {
                bundle = new Bundle();
                foreach (var parameter in parameters)
                {
                    PutToBundle(bundle, parameter.Name, parameter.Value);
                }
            }

            AnalyticsProvider.GetAnalytics().LogEvent(name, bundle);
        }

        public void LogEvent(string name, IDictionary<string, object>? parameters)
        {
            Bundle? bundle = null;
            if (parameters != null)
            {
                bundle = new Bundle();
                foreach (var (key, value) in parameters)
                {
                    PutToBundle(bundle, key, value);
                }
            }

            AnalyticsProvider.GetAnalytics().LogEvent(name, bundle);
        }

        public void SetCurrentScreen(string? screenName, string? screenClass)
        {
            AnalyticsProvider.GetAnalytics().SetCurrentScreen(CrossCurrentActivity.Current.Activity, screenName, screenClass);
        }

        public void SetUserId(string? userId)
        {
            AnalyticsProvider.GetAnalytics().SetUserId(userId);
        }

        public void SetUserProperty(string name, string? value)
        {
            AnalyticsProvider.GetAnalytics().SetUserProperty(name, value);
        }

        public void ResetAnalyticsData()
        {
            AnalyticsProvider.GetAnalytics().ResetAnalyticsData();
        }

        public void SetSessionTimeoutDuration(long milliseconds)
        {
            AnalyticsProvider.GetAnalytics().SetSessionTimeoutDuration(milliseconds);
        }

        public void SetAnalyticsCollectionEnabled(bool enabled)
        {
            AnalyticsProvider.GetAnalytics().SetAnalyticsCollectionEnabled(enabled);
        }

        private void PutToBundle(Bundle bundle, string name, object? value)
        {
            switch (value)
            {
                case bool @bool:
                    bundle.PutBoolean(name, @bool);
                    break;
                case byte @byte:
                    bundle.PutShort(name, @byte);
                    break;
                case sbyte @sbyte:
                    bundle.PutByte(name, @sbyte);
                    break;
                case short @short:
                    bundle.PutShort(name, @short);
                    break;
                case ushort @ushort:
                    bundle.PutInt(name, @ushort);
                    break;
                case int @int:
                    bundle.PutInt(name, @int);
                    break;
                case uint @uint:
                    bundle.PutLong(name, @uint);
                    break;
                case long @long:
                    bundle.PutLong(name, @long);
                    break;
                case ulong @ulong:
                    if (@ulong > long.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    bundle.PutLong(name, (long)@ulong);
                    break;
                case float @float:
                    bundle.PutFloat(name, @float);
                    break;
                case double @double:
                    bundle.PutDouble(name, @double);
                    break;
                case decimal @decimal:
                    bundle.PutDouble(name, decimal.ToDouble(@decimal));
                    break;
                case string @string:
                    bundle.PutString(name, @string);
                    break;
                case IEnumerable<IDictionary<string, object>> dictionaries:
                    {
                        var bundles = new List<Bundle>();
                        foreach (var dictionary in dictionaries)
                        {
                            var newBundle = new Bundle();
                            foreach (var (key, val) in dictionary)
                            {
                                PutToBundle(newBundle, key, val);
                            }
                            bundles.Add(newBundle);
                        }
                        bundle.PutParcelableArray(name, bundles.ToArray());
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), $"{value?.GetType().FullName ?? "null"} is not supported");
            }
        }
    }
}
