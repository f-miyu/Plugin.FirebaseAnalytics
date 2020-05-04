using System;

namespace Plugin.FirebaseAnalytics
{
    public static class FirebaseAnalytics
    {
        public static void SetAnalyticsCollectionEnabled(bool enabled)
        {
            AnalyticsProvider.GetAnalytics().SetAnalyticsCollectionEnabled(enabled);
        }

        [Obsolete("deprecated")]
        public static void SetMinimumSessionDuration(long milliseconds)
        {
            AnalyticsProvider.GetAnalytics().SetMinimumSessionDuration(milliseconds);
        }

        public static void SetSessionTimeoutDuration(long milliseconds)
        {
            AnalyticsProvider.GetAnalytics().SetSessionTimeoutDuration(milliseconds);
        }
    }
}
