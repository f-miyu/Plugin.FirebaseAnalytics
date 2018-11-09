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
            NSDictionary<NSString, NSObject> dict = null;
            if (parameters != null)
            {
                dict = new NSDictionary<NSString, NSObject>(parameters.Select(p => new NSString(p.Name)).ToArray(),
                                                            parameters.Select(p =>
                                                            {
                                                                NSObject value = null;
                                                                switch (p.Value)
                                                                {
                                                                    case long longValue:
                                                                        value = new NSNumber(longValue);
                                                                        break;
                                                                    case double doubleValue:
                                                                        value = new NSNumber(doubleValue);
                                                                        break;
                                                                    case string stringValue:
                                                                        value = new NSString(stringValue);
                                                                        break;
                                                                }
                                                                return value;
                                                            }).ToArray());
            }

            Analytics.LogEvent(name, dict);
        }

        public void SetCurrentScreen(string screenName, string screenClass)
        {
            Analytics.SetScreenNameAndClass(screenName, screenClass);
        }

        public void SetUserId(string userId)
        {
            Analytics.SetUserId(userId);
        }

        public void SetUserProperty(string name, string value)
        {
            Analytics.SetUserProperty(value, name);
        }
    }
}
