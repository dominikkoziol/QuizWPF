using Quiz.Models;
using Quiz.ViewModels;
using Quiz.Views.Dialogs;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowModel _mainWindowModel = new MainWindowModel();
        public MainWindow()
        {
            InitializeComponent();

        }

        public override async void BeginInit()
        {
            base.BeginInit();
            DataContext = _mainWindowModel;
            await _mainWindowModel.InitAsync();
        }

        private async void Button_Click_Create_New_User(object sender, RoutedEventArgs e)
        {
            CreateUserWindow modalWindow = new CreateUserWindow();
            modalWindow.ShowDialog();
            modalWindow.Closing += await ModalWindow_Closing(null, null);
        }

        private async void Button_Start_Game(object sender, RoutedEventArgs e)
        {
            var id = ((User)UserList.SelectedItem).Id;
            var game = new StartQuizWindow(id);
            game.Show();
            this.Close();


        }

        private async Task<CancelEventHandler> ModalWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await _mainWindowModel.InitAsync();
            return null;
        }

        private async void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            var id = ((User)UserList.SelectedItem).Id;
            await _mainWindowModel.RemoveUser(id);
        }
    }
}
