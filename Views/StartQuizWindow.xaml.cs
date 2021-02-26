using Quiz.Models;
using Quiz.ViewModels;
using Quiz.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Quiz.Views
{
    /// <summary>
    /// Interaction logic for StartQuizWindow.xaml
    /// </summary>
    public partial class StartQuizWindow : Window
    {
        private int _userId;
        private StartQuizViewModel _startQuizViewModel = new StartQuizViewModel();
        public StartQuizWindow(int id)
        {
            this._userId = id;
            InitializeComponent();
        }



        public override async void BeginInit()
        {
            base.BeginInit();
            DataContext = _startQuizViewModel;
            await _startQuizViewModel.InitAsync(this._userId);
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void Button_Click_Start_Game(object sender, RoutedEventArgs e)
        {
            var categoryId = ((Category)CategoryList.SelectedItem).Id;
            var gameWindow = new GameWindow(categoryId);
            gameWindow.ShowDialog();
        }
    }
}
