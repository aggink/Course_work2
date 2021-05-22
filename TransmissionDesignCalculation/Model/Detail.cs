using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Model
{
    public class Detail
    {
        private string NameGear_ = "Шестерня";
        public string NameGear
        {
            get
            {
                return NameGear_;
            }
        }
        private string NameWheel_ = "Колесо";
        public string NameWheel
        {
            get
            {
                return NameWheel_;
            }
        }
        public int MaterialId { get; set; }
        //материал
        public string Material { get; set; }
        //Марка
        public string Mark { get; set; }
        //вид упрочнения
        public string TypeHardening { get; set; }

        public Guid gearId { get; set; }
        //число зубьев шестерни
        public int z1 { get; set; }
        //угол делительного конуса шестерни
        public decimal delta1 { get; set; }

        public Guid wheelId { get; set; }
        //число зубьев колеса
        public int z2 { get; set; }

        //угол делительного конуса колеса
        public decimal delta2 { get; set; }

        //вид зубьев
        public string TypeTeeth { get; set; }
        //угол наклона линии зуба
        public decimal beta_m { get; set; }
        //вид числа зубье (эквивалентное/биэквивалентное)
        public string TypeTeeth_z { get; set; }
        //сохранение результатов
        public bool save { get; set; }  = false;
        public Detail() 
        {
            save = false;

        }
    }
}
