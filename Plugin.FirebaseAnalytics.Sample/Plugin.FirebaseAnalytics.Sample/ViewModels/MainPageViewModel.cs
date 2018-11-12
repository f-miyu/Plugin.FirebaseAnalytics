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
        public ICommand SendEventCommand { get; }
        public ICommand GoToSecondPageCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            SendEventCommand = new DelegateCommand(() =>
            {
                CrossFirebaseAnalytics.Current.LogEvent(EventName.SelectContent,
                                                        new Parameter(ParameterName.ItemId, 1),
                                                        new Parameter(ParameterName.ItemName, "test"));
            });

            GoToSecondPageCommand = new DelegateCommand(() => NavigationService.NavigateAsync("SecondPage"));
        }

        public override void OnAppearing()
        {
            CrossFirebaseAnalytics.Current.SetCurrentScreen(Title, nameof(MainPageViewModel));
        }
    }
}
