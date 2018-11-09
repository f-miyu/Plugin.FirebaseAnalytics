using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Plugin.FirebaseAnalytics.Sample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand Command { get; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            Command = new DelegateCommand(() =>
            {
                CrossFirebaseAnalytics.Current.LogEvent(EventName.ViewItem,
                                                        new Parameter("aaa", 1),
                                                        new Parameter("bbb", 1.5),
                                                        new Parameter("ccc", "ddd"));
            });
        }
    }
}
