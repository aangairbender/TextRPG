using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TextRPG.ContentManager.Core.ViewModels;

namespace TextRPG.ContentManager.App.Views
{
    /// <summary>
    /// Логика взаимодействия для StoryManagementView.xaml
    /// </summary>
    [MvxViewFor(typeof(StoryManagementVM))]
    public partial class StoryManagementView : MvxWpfView
    {
        public StoryManagementView()
        {
            InitializeComponent();
        }
    }
}
