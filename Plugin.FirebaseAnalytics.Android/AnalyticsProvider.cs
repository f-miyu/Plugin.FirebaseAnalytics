using System;
using Plugin.CurrentActivity;

namespace Plugin.FirebaseAnalytics
{
    public static class AnalyticsProvider
    {
        public static Firebase.Analytics.FirebaseAnalytics GetAnalytics()
        {
            return Firebase.Analytics.FirebaseAnalytics.GetInstance(CrossCurrentActivity.Current.Activity);
        }
    }
}
