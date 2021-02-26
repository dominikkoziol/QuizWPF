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
        public GameWindow(int categoryId)
        {
            _categoryId = categoryId;
            InitializeComponent();
        }

        public override async void BeginInit()
        {
            base.BeginInit();
            DataContext = _gameViewModel;
            await _gameViewModel.InitAsync(_categoryId);
        }
    }
}
