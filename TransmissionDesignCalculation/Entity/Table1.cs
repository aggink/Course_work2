using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Entity
{
    public class Table1
    {
        public int Id { get; set; }
        public string Material { get; set; }
        public string Mark { get; set; }
        public string TypeHardening { get; set; }
        public decimal HBmin { get; set; }
        public decimal HBmax { get; set; }
        public string TypeLoad { get; set; }
        public decimal o_FP { get; set; }
        public decimal N_FO { get; set; }
        public decimal o_HP { get; set; }
        public decimal N_HO { get; set; }
    }
}
