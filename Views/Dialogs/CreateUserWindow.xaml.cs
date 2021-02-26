using Quiz.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Quiz.Models.User;

namespace Quiz.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private CreateUserViewModel _createUserViewModel = new CreateUserViewModel();
        public CreateUserWindow()
        {
            InitializeComponent();
            DataContext = _createUserViewModel;
        }

        private async void CreateUser(object sender, RoutedEventArgs e)
        {
            var isUserCreated = await _createUserViewModel.CreateUser(nameInput.Text, (sex1.IsChecked.Value ? SexEnum.Man : SexEnum.Woman));
            if (isUserCreated) Close();

            
        }

    }
}
