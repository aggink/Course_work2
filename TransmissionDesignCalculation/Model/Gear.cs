using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Model
{
    public class Gear
    {
        private string NameGear_ = "Прямозубая коническая передача";
        public string NameGear
        {
            get
            {
                return NameGear_;
            }
        }
        public Guid GearId { get; set; }
        //мощность
        public decimal N { get; set; }
        //частота вращения меньшего шкива
        public decimal n1 { get; set; }
        //частота вращения
        public decimal n { get; set; }
        //время работы передачи
        public decimal t_r { get; set; }

        //вид опоры (шариковая/роликовая)
        public string TypeSupport { get; set; }
        //тип нагрузки (реверсивная/нереверсивная)
        public string TypeLoad_r { get; set; }

        //вид нагрузки (постоянная/ступенчатая)
        public string TypeLoad_p { get; set; }

        //эквивалентное число циклов перемены напряжений при ступенчатой нагрузки
        public decimal? N_FE { get; set; }
        //число циклов перемены напряжений при ступенчатой нагрузки
        public decimal? N_HE { get; set; }
        //тип механической передачи
        public string TypeGear { get; set; }
        //параметры детали
        public Detail detail;

        public bool save = false;
        public Gear()
        {
            detail = new Detail();
            N_FE = null;
            N_HE = null;
            save = false;
        }
    }
}
