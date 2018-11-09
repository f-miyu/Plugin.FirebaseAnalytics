using System;
using Android.App;
using Android.OS;
using Android.Content;

namespace Plugin.FirebaseAnalytics
{
    public static class FirebaseAnalytics
    {
        private static Func<Activity> _currentActivityFactory;
        private static ActivityLifecycleCallbacks _callbacks;

        internal static Activity CurrentActivity => _currentActivityFactory?.Invoke();
        internal static Firebase.Analytics.FirebaseAnalytics Instance { get; private set; }

        public static void Init(Context context, Func<Activity> currentActivityFactory)
        {
            _currentActivityFactory = currentActivityFactory;
            Instance = Firebase.Analytics.FirebaseAnalytics.GetInstance(context);
        }

        public static void Init(Application application)
        {
            if (_callbacks == null)
            {
                _callbacks = new ActivityLifecycleCallbacks();
                application.RegisterActivityLifecycleCallbacks(_callbacks);
            }

            Init(application, () => _callbacks.CurrentActivit);
        }

        public static void Init(Activity activity)
        {
            if (_callbacks == null)
            {
                _callbacks = new ActivityLifecycleCallbacks(activity);
                activity.Application.RegisterActivityLifecycleCallbacks(_callbacks);
            }

            Init(activity, () => _callbacks.CurrentActivit);
        }

        public static void SetAnalyticsCollectionEnabled(bool enabled)
        {
            Instance.SetAnalyticsCollectionEnabled(enabled);
        }

        public static void SetMinimumSessionDuration(long milliseconds)
        {
            Instance.SetMinimumSessionDuration(milliseconds);
        }

        public static void SetSessionTimeoutDuration(long milliseconds)
        {
            Instance.SetSessionTimeoutDuration(milliseconds);
        }

        private class ActivityLifecycleCallbacks : Java.Lang.Object, Application.IActivityLifecycleCallbacks
        {
            private WeakReference<Activity> _currentActivity = new WeakReference<Activity>(null);
            public Activity CurrentActivit
            {
                get => _currentActivity.TryGetTarget(out var activity) ? activity : null;
                set => _currentActivity.SetTarget(value);
            }

            public ActivityLifecycleCallbacks()
            {
            }

            public ActivityLifecycleCallbacks(Activity activity)
            {
                CurrentActivit = activity;
            }

            public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
            {
                CurrentActivit = activity;
            }

            public void OnActivityDestroyed(Activity activity)
            {
            }

            public void OnActivityPaused(Activity activity)
            {
            }

            public void OnActivityResumed(Activity activity)
            {
                CurrentActivit = activity;
            }

            public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
            {
            }

            public void OnActivityStarted(Activity activity)
            {
            }

            public void OnActivityStopped(Activity activity)
            {
            }
        }
    }
}
