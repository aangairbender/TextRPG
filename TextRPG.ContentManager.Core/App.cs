using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.ContentManager.Core.Services;
using TextRPG.ContentManager.Core.ViewModels;

namespace TextRPG.ContentManager.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<StoryManagementVM>();
        }
    }
}
