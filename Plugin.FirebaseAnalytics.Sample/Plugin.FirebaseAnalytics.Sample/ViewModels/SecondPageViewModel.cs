using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;

namespace Plugin.FirebaseAnalytics.Sample.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public ICommand SendUserPropertyCommand { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Second Page";

            SendUserPropertyCommand = new DelegateCommand(() =>
            {
                CrossFirebaseAnalytics.Current.SetUserProperty("name", Name);
            });
        }

        public override void OnAppearing()
        {
            CrossFirebaseAnalytics.Current.SetCurrentScreen(Title, nameof(SecondPageViewModel));
        }
    }
}
