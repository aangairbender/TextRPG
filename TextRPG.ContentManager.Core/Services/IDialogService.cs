using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG.ContentManager.Core.Services
{
    public interface IDialogService
    {
        void ShowMessage(string message);
        bool SaveFileDialog(string title, string filter, out string filename);
    }
}
