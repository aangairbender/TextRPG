using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.ContentManager.App.Services;
using TextRPG.ContentManager.Core.Services;

namespace TextRPG.ContentManager.App
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        protected override IMvxApplication CreateApp()
        {
            var app = base.CreateApp();
            RegisterTypes();
            return app;
        }

        private void RegisterTypes()
        {
            Mvx.IoCProvider.ConstructAndRegisterSingleton<IDialogService, DialogService>();
        }
    }
}
