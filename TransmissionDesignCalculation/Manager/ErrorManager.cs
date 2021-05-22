using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Базы_данных.Курсовая_работа.Manager
{
    public static class ErrorManager
    {
        //информациооное сообщение
        static public DialogResult InfoOK(string text, string error = "Ошибка")
        {
            DialogResult result = MessageBox.Show(
                                                    text,
                                                    error,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly
                                                  );
            return result;
        }
        static public DialogResult ErrorOK(string text, string error = "Ошибка")
        {
            DialogResult result = MessageBox.Show(
                                                    text,
                                                    error,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly
                                                  );
            return result;
        }
        public static DialogResult InfoYesNo(string text, string error = "Ошибка")
        {
            DialogResult result = MessageBox.Show(
                                                    text,
                                                    error,
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly
                                                  );
            return result;
        }
    }
}
