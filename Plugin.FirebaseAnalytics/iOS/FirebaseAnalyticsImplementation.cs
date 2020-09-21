using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Analytics;
using System.Linq;
using Foundation;

namespace Plugin.FirebaseAnalytics
{
    public class FirebaseAnalyticsImplementation : IFirebaseAnalytics
    {
        public Task<string> GetAppInstanceIdAsync()
        {
            return Task.FromResult(Analytics.AppInstanceId);
        }

        public void LogEvent(string name, params Parameter[] parameters)
        {
            NSDictionary<NSString, NSObject?>? dict = null;
            if (parameters != null)
            {
                dict = new NSDictionary<NSString, NSObject?>(
                    parameters.Select(p => new NSString(p.Name)).ToArray(),
                    parameters.Select(p => Convert(p.Value)).ToArray());
            }

            Analytics.LogEvent(name, dict);
        }

        public void LogEvent(string name, IDictionary<string, object>? parameters)
        {
            NSDictionary<NSString, NSObject>? dict = null;

            if (parameters != null)
            {
                dict = new NSDictionary<NSString, NSObject>(
                    parameters.Keys.Select(key => new NSString(key)).ToArray(),
                    parameters.Values.Select(value => Convert(value)).ToArray());
            }

            Analytics.LogEvent(name, dict);
        }

        public void SetCurrentScreen(string? screenName, string? screenClass)
        {
            Analytics.SetScreenNameAndClass(screenName, screenClass);
        }

        public void SetUserId(string? userId)
        {
            Analytics.SetUserId(userId);
        }

        public void SetUserProperty(string name, string? value)
        {
            Analytics.SetUserProperty(value, name);
        }

        public void ResetAnalyticsData()
        {
            Analytics.ResetAnalyticsData();
        }

        public void SetSessionTimeoutDuration(long milliseconds)
        {
            Analytics.SetSessionTimeoutInterval(milliseconds / 1000.0);
        }

        public void SetAnalyticsCollectionEnabled(bool enabled)
        {
            Analytics.SetAnalyticsCollectionEnabled(enabled);
        }

        private NSObject Convert(object? value)
        {
            switch (value)
            {
                case bool @bool:
                    return new NSNumber(@bool);
                case byte @byte:
                    return new NSNumber(@byte);
                case sbyte @sbyte:
                    return new NSNumber(@sbyte);
                case short @short:
                    return new NSNumber(@short);
                case ushort @ushort:
                    return new NSNumber(@ushort);
                case int @int:
                    return new NSNumber(@int);
                case uint @uint:
                    return new NSNumber(@uint);
                case long @long:
                    return new NSNumber(@long);
                case ulong @ulong:
                    if (@ulong > long.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    return new NSNumber(@ulong);
                case float @float:
                    return new NSNumber(@float);
                case double @double:
                    return new NSNumber(@double);
                case decimal @decimal:
                    return new NSNumber(decimal.ToDouble(@decimal));
                case string @string:
                    return new NSString(@string);
                case IEnumerable<IDictionary<string, object>> dictionaries:
                    {
                        var ret = new NSMutableArray();
                        foreach (var dictionary in dictionaries)
                        {
                            var nsDictionary = new NSMutableDictionary();
                            foreach (var (key, val) in dictionary)
                            {
                                nsDictionary[new NSString(key)] = Convert(val);
                            }
                            ret.Add(nsDictionary);
                        }
                        return ret;
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), $"{value?.GetType().FullName ?? "null"} is not supported");
            }
        }
    }
}
