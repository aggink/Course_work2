using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Model
{
    public static class StaticData
    {

        //константные значения по заданной задаче

        //вид передачи
        private static string TypeTransmition_ = "коническая зубчатая";
        public static string TypeTransmition 
        {
            get
            {
                return TypeTransmition_;
            }

        }
        //вид зубьев
        private static string TypeTeeth_ = "прямые";
        public static string TypeTeeth 
        {
            get
            {
                return TypeTeeth_;
            }
        }
        //вид опоры
        public static string[] TypeSupport = { "Шариковая", "Роликовая" };
        //вид нагрузки
        public static string[] TypeLoad_r = { "pеверсивная", "нереверсивная" };
        //вид числа зубьев
        public static string[] TypeTeeth_z = { "эквивалентное", "биэквивалентное" };
        //тип нагрузки (постоянная/ступенчатая)
        public static string[] TypeLoad_p = { "постоянная", "ступенчатая" };
    }
}
