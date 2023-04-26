using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bbservertask.ViewModels.UserViewModel
{
    public class SubscriberHomeViewModel : BaseViewModel
    {
        public RelayCommand RegisterCommand { get; set; }

        public RelayCommand SignInCommand { get; set; }

        public RelayCommand BackCommand { get; set; }
        public SubscriberHomeViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            RegisterCommand = new RelayCommand(c =>
            {
                var registerUC = new RegisterUC();
                var registerViewModel = new RegisterViewModel();
                registerViewModel.PasswordBox = registerUC.password_box;
                registerUC.DataContext = registerViewModel;

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(registerUC);

            });

            SignInCommand = new RelayCommand(c =>
            {
                var subscriberSigninUC = new SubscriberSignInUC();
                var viewModel = new SubsciberSignInViewModel();
                subscriberSigninUC.DataContext = viewModel;
                viewModel.PasswordBox = subscriberSigninUC.password_box;

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(subscriberSigninUC);
            });

            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });
        }
    }
}
