using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Базы_данных.Курсовая_работа.Entity;
using Базы_данных.Курсовая_работа.Manager;

namespace Базы_данных.Курсовая_работа
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //считываем данные из таблиц
            DataBaseContext dbContext = new DataBaseContext();

            try
            {
                Application.Run(new FormMain(dbContext));
            }
            catch
            {
                ErrorManager.ErrorOK("В ходе работы приложения возникла неизвестная ошибка!");
            }
        }
    }
}
