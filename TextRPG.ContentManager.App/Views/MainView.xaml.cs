using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using TextRPG.ContentManager.Core.ViewModels;

namespace TextRPG.ContentManager.App.Views
{
    [MvxViewFor(typeof(MainVM))]
    public partial class MainView : MvxWpfView
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
