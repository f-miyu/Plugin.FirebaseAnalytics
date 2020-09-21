using System;

namespace Plugin.FirebaseAnalytics
{
    public static class FirebaseAnalytics
    {
        [Obsolete("Use IFirebaseAnalytics#SetAnalyticsCollectionEnabled(bool)instead.")]
        public static void SetAnalyticsCollectionEnabled(bool enabled)
        {
            AnalyticsProvider.GetAnalytics().SetAnalyticsCollectionEnabled(enabled);
        }

        [Obsolete("deprecated")]
        public static void SetMinimumSessionDuration(long milliseconds)
        {
            AnalyticsProvider.GetAnalytics().SetMinimumSessionDuration(milliseconds);
        }

        [Obsolete("Use IFirebaseAnalytics#SetSessionTimeoutDuration(long)instead.")]
        public static void SetSessionTimeoutDuration(long milliseconds)
        {
            AnalyticsProvider.GetAnalytics().SetSessionTimeoutDuration(milliseconds);
        }
    }
}
