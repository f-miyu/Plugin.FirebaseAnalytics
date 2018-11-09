using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Plugin.FirebaseAnalytics
{
    public interface IFirebaseAnalytics
    {
        Task<string> GetAppInstanceIdAsync();
        void LogEvent(string name, params Parameter[] parameters);
        void SetCurrentScreen(string screenName, string screenClass);
        void SetUserId(string userId);
        void SetUserProperty(string name, string value);
    }
}
