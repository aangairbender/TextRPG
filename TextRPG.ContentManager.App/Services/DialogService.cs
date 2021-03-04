using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using TextRPG.ContentManager.Core.Services;

namespace TextRPG.ContentManager.App.Services
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool SaveFileDialog(string title, string filter, out string filename)
        {
            var dialog = new SaveFileDialog()
            {
                Title = title,
                Filter = filter,
            };

            if (dialog.ShowDialog() == true)
            {
                filename = dialog.FileName;
                return true;
            } else
            {
                filename = null;
                return false;
            }
        }
    }
}
