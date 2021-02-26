using Quiz.ViewModels.Dialogs;
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

namespace Quiz.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameViewModel _gameViewModel { get; set; } = new GameViewModel();
        private int _categoryId { get; set; }
        private int _userId { get; set; }
        private bool _isButtonEnabled { get; set; } = false;
        private RadioButton choosenAnswer { get; set; }
        public GameWindow(int categoryId, int userId)
        {
            _categoryId = categoryId;
            _userId = userId;
            InitializeComponent();
            next.IsEnabled = false;
        }

        public override async void BeginInit()
        {
            base.BeginInit();
            DataContext = _gameViewModel;
            await _gameViewModel.InitAsync(_categoryId, _userId);
        }

        private async void Button_Click_Next_Question(object sender, RoutedEventArgs e)
        {
            var isLast = _gameViewModel.NextQuestion();
            if (isLast)
            {
                await _gameViewModel.Finish();
                this.Close();
            }

            next.IsEnabled = false;
            choosenAnswer.IsChecked = false;

        }

        private void answer_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            choosenAnswer = radioButton;
            _gameViewModel.SetAnswer(radioButton.Name);
            next.IsEnabled = true;
        }
    }
}
