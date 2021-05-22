using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Базы_данных.Курсовая_работа.Model
{

    public class AllData
    {
        //код узла
        public Guid NodeId { get; set; }



        //код передачи
        public Guid GearId { get; set; }
        //мощность
        public decimal N { get; set; }
        //частота вращения меньшего шкива
        public decimal n1 { get; set; }
        //частота вращения
        public decimal n { get; set; }
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





        //Крутящий момент
        public decimal T1 { get; set; }
        //передаточное число 
        public decimal u { get; set; }
        //твердость
        public decimal HB { get; set; }
        //Коэффициент зубчатого венца
        public decimal K_be { get; set; }
        //Относительная ширина эквивалентного конического колеса
        public decimal L_FB { get; set; }
        //коэффициент учитывающий распределение нагрузки по ширине вента конического колес
        public decimal K_HB { get; set; }
        //вспомогательный коэффициент
        public decimal K_d { get; set; }
        //вспомогательный коэффициент 
        public decimal K_R { get; set; }
        //базовое число циклов перемены напряжения
        public decimal N_HO { get; set; }
        //полное число работы передачи за расчетный срок службы
        public decimal t_r { get; set; }
        //коэффициент долговечности
        public decimal K_HL { get; set; }
        //допускаемое контактное напряжение o'_HP
        public decimal o_HPr { get; set; }
        //Допускаемое контактное напряжение
        public decimal o_HP { get; set; }
        //внешнее конусное расстояние
        public decimal R_e { get; set; }
        //внешний делительный диаметр шестерни
        public decimal d_e1 { get; set; }
        //внешний делительный диаметр колеса
        public decimal d_e2 { get; set; }
        //вспомогательный коэффициент
        public decimal K_m { get; set; }
        //коэффициент учитывающий распределение нагрузки по ширине венца конического колеса
        public decimal K_FB { get; set; }
        //коэффициент смещения
        public decimal x_n1 { get; set; }
        //число зубьев (эквивалентное/биэквивалентное)
        public decimal z_v { get; set; }
        //коэффициент учитывающий форму зуба Y'_F1
        public decimal Y_F1r { get; set; }
        //коэффициент изменения толщины зуба у шестерни
        public decimal x_t1 { get; set; }
        //Коэффициент учитывающий форму зуба
        public decimal Y_F1 { get; set; }
        //Коэффициент ширины венца шестерни относительно среднего делительного диаметра ψ_bd
        public decimal psi_bd { get; set; }
        //допускаемое контактное напряжение o'_FP
        public decimal o_FPr { get; set; }
        //базовое число циклов перемены напряжений
        public decimal N_FO { get; set; }
        //показатель степени для определения коэффициента долговечности
        public decimal m_F { get; set; }
        //Коэффициент долговечности
        public decimal K_FL { get; set; }
        //Допустимое контактное напряжение
        public decimal o_FP { get; set; }
        //минимально допустимый средний нормальный модуль
        public decimal m_nm { get; set; }

        public AllData(Guid NodeId, Gear gear)
        {
            //код узла
            this.NodeId = NodeId;

            this.GearId = gear.GearId;
            //мощность
            this.N = gear.N;
            //частота вращения меньшего шкива
            this.n1 = gear.n1;
            //частота вращения
            this.n = gear.n;
            //часы работы
            this.t_r = gear.t_r;
            //вид опоры (шариковая/роликовая)
            this.TypeSupport = gear.TypeSupport;
            //тип нагрузки (реверсивная/нереверсивная)
            this.TypeLoad_r = gear.TypeLoad_r;
            //вид нагрузки (постоянная/ступенчатая)
            this.TypeLoad_p = gear.TypeLoad_p;
            //эквивалентное число циклов перемены напряжений при ступенчатой нагрузки
            this.N_FE = gear.N_FE;
            //число циклов перемены напряжений при ступенчатой нагрузки
            this.N_HE = gear.N_HE;
            //тип механической передачи
            this.TypeGear = gear.TypeGear;

            this.MaterialId = gear.detail.MaterialId;
            //материал
            this.Material = gear.detail.Material;
            //Марка
            this.Mark = gear.detail.Mark;
            //вид упрочнения
            this.TypeHardening = gear.detail.TypeHardening;
            this.gearId = gear.detail.gearId;
            //число зубьев шестерни
            this.z1 = gear.detail.z1;
            //угол делительного конуса шестерни
            this.delta1 = gear.detail.delta1;
            this.wheelId = gear.detail.wheelId;
            //число зубьев колеса
            this.z2 = gear.detail.z2;
            //угол делительного конуса колеса
            this.delta2 = gear.detail.delta2;
            //вид зубьев
            this.TypeTeeth = gear.detail.TypeTeeth;
            //угол наклона линии зуба
            this.beta_m = gear.detail.beta_m;
            //вид числа зубье (эквивалентное/биэквивалентное)
            this.TypeTeeth_z = gear.detail.TypeTeeth_z;
        }
    }
}
