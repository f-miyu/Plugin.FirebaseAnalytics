# Plugin.FirebaseAnalytics

A cross platform plugin for Firebase Analytics. 
A wrapper for [Xamarin.Firebase.iOS.Analytics](https://www.nuget.org/packages/Xamarin.Firebase.iOS.Analytics/) 
and [Xamarin.Firebase.Analytics](https://www.nuget.org/packages/Xamarin.Firebase.Analytics).


## Setup
Install Nuget package to each projects.

[Plugin.FirebaseAnalytics](https://www.nuget.org/packages/Plugin.FirebaseAnalytics/) [![NuGet](https://img.shields.io/nuget/vpre/Plugin.FirebaseAnalytics.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.FirebaseAnalytics/)

### iOS
* Add GoogleService-Info.plist to iOS project. Select BundleResource as build action.
* Initialize as follows in AppDelegate. 
```C#
Firebase.Core.App.Configure();
```

### Android
* Add google-services.json to Android project. Select GoogleServicesJson as build action. (If you can't select GoogleServicesJson, reload this android project.)
* Target framework version needs to be Android 10.0.
* This Plugin uses [Plugin.CurrentActivity](https://github.com/jamesmontemagno/CurrentActivityPlugin). Setup as follows in MainActivity.
```C#
Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
```

## Usage
### Log events
```C#
CrossFirebaseAnalytics.Current.LogEvent(EventName.SelectContent,
                                        new Parameter(ParameterName.ItemId, itemId),
                                        new Parameter(ParameterName.ItemName, itemName));

var parameters = new Dictionary<string, object>
{
    [ParameterName.ItemId] = 1,
    [ParameterName.ItemName] = "test"
};
CrossFirebaseAnalytics.Current.LogEvent(EventName.SelectContent, parameters);
```

### Set user properties
```C#
CrossFirebaseAnalytics.Current.SetUserProperty("name", userName);
```

### Set user id
```C#
CrossFirebaseAnalytics.Current.SetUserId(userId);
```

### Set screen name
```C#
CrossFirebaseAnalytics.Current.SetCurrentScreen(screenName, screenClass));
```

### Get app instance id
```C#
var id = await CrossFirebaseAnalytics.Current.GetAppInstanceIdAsync();
```

### Reset analytics data
```C#
CrossFirebaseAnalytics.Current.ResetAnalyticsData();
```

### Set parameters
```C#
CrossFirebaseAnalytics.Current.SetAnalyticsCollectionEnabled(enabled);

CrossFirebaseAnalytics.Current.SetSessionTimeoutDuration(sessionTimeoutDuration);
```
