using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TextRPG.Domain.Models;

namespace TextRPG.ContentManager.Core.ViewModels
{
    public class MainVM : MvxViewModel<Story>
    {
        public Story Story { get; private set; }

        public override void Prepare(Story story)
        {
            Story = story;
        }
    }
}
