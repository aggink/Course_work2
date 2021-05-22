using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Entity
{
    public class Table2
    {
        public int Id { get; set; }
        public string TypeSupport { get; set; }
        public string TypeTeeth { get; set; }
        public decimal? HB_min { get; set; }
        public decimal? HB_max { get; set; }
        public decimal L_FB { get; set; }
        public decimal? K_HB { get; set; }
        public decimal? K_FB { get; set; }
    }
}
