using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Базы_данных.Курсовая_работа.Entity;
using Базы_данных.Курсовая_работа.Model;

namespace Базы_данных.Курсовая_работа.Manager
{
    public class Decision
    {
        private DataBaseContext dbContext;
        private List<AllData> alldata;
        public Decision(DataBaseContext dbContext, List<AllData> allData)
        {
            this.dbContext = dbContext;
            this.alldata = allData;
        }
        //ищем близкое  значение к L_FB
        private decimal Find_Lfb(List<Table2> list, decimal a)
        {
            decimal min = list[0].L_FB;
            foreach(var n in list)
            {
                if((Math.Abs(n.L_FB - a)) < (Math.Abs(a - min)))
                {
                    min = n.L_FB;
                }
            }
            return min;
        }
        //ещем ближайшее значение к z_v
        private decimal Find_Zv(List<Table3> list, decimal a)
        {
            decimal min = list[0].z_v;
            foreach (var n in list)
            {
                if ((Math.Abs(n.z_v - a)) < (Math.Abs(a - min)))
                {
                    min = n.z_v;
                }
            }
            return min;
        }
        //ищем ближайщее значение к x_t1
        private decimal Find_Xt1(List<Table3> list, decimal a)
        {
            decimal min = list[0].x_t1;
            foreach (var n in list)
            {
                if ((Math.Abs(n.x_t1 - a)) < (Math.Abs(a - min)))
                {
                    min = n.x_t1;
                }
            }
            return min;
        }
        public List<AllData> Result()
        {
            int cout = alldata.Count();
            for(int i = 0; i < cout; i++)
            {
                //определение крутящего момента T1
                alldata[i].T1 = 9.55M * 1000M * alldata[i].N / alldata[i].n1;

                //определение передаточного числа u
                alldata[i].u = alldata[i].z2 / (alldata[i].z1 + 0.0M);

                //определение всех параметров зависящих от материала
                Table1 record_t1 = dbContext.table1.FirstOrDefault(s => s.Id == alldata[i].MaterialId);

                //определение твердости HB
                alldata[i].HB = record_t1.HBmax;

                //определение базового числа циклов перемены напряжений N_H0
                alldata[i].N_HO = record_t1.N_HO;

                //определение допускаемого контактного напряжения o'_HP
                alldata[i].o_HPr = record_t1.o_HP;

                //определение допускаемого контактного напряжения o'_FP
                alldata[i].o_FPr = record_t1.o_FP;

                //определение базового числа циклов перемены напряжений n_F0
                alldata[i].N_FO = record_t1.N_FO;

                //определение К_be
                if ( alldata[i].u > 3M)
                {
                    alldata[i].K_be = 0.25M;
                }
                else
                {
                    alldata[i].K_be = 0.3M;
                }

                //определение относительной ширины эквмвалентного конического колеса L_FB
                alldata[i].L_FB = (alldata[i].K_be * alldata[i].u) / (2M - alldata[i].K_be);

                //определение коэффициентов K_HB и K_FL
                if(alldata[i].HB > 350M)
                {
                    //определение K_HB при HB > 350
                    List<Table2> list = dbContext.table2.Where(x => x.HB_min != null && x.TypeSupport.ToLower().Contains(alldata[i].TypeSupport.ToLower()) && x.K_HB != null).ToList();
                    Table2 record = list.FirstOrDefault(x => x.L_FB == Find_Lfb(list, alldata[i].L_FB));
                    alldata[i].K_HB = Convert.ToDecimal(record.K_HB);

                    //определение K_FB при HB > 350
                    list = dbContext.table2.Where(x => x.HB_min != null && x.TypeSupport.ToLower().Contains(alldata[i].TypeSupport.ToLower()) && x.K_FB != null).ToList();
                    record = list.FirstOrDefault(x => x.L_FB == Find_Lfb(list, alldata[i].L_FB));
                    alldata[i].K_FB = Convert.ToDecimal(record.K_FB);
                }
                else
                {
                    //Hb <=350

                    //определение K_HB при HB <= 350
                    List<Table2> list = dbContext.table2.Where(x => x.HB_max != null && (x.TypeSupport.ToLower() == alldata[i].TypeSupport.ToLower()) && x.K_HB != null).ToList();
                    Table2 record = list.FirstOrDefault(x => x.L_FB == Find_Lfb(list, alldata[i].L_FB));
                    alldata[i].K_HB = Convert.ToDecimal(record.K_HB);

                    //определение K_FB при HB <= 350
                    list = dbContext.table2.Where(x => x.HB_max != null && x.TypeSupport.ToLower().Contains(alldata[i].TypeSupport.ToLower()) && x.K_FB != null).ToList();
                    record = list.FirstOrDefault(x => x.L_FB == Find_Lfb(list, alldata[i].L_FB));
                    alldata[i].K_FB = Convert.ToDecimal(record.K_FB);
                }

                //Определение коэффициента K_d
                alldata[i].K_d = Convert.ToDecimal(Math.Pow(1000000, 1 / 3.0));

                //определение коэффициента K_R
                alldata[i].K_R = 0.5M * alldata[i].K_d;

                //определение числа циклов перемены напряжений N_HE и N_FE
                if (alldata[i].N_HE == null && alldata[i].N_FE == null)
                {
                    //определение числа циклов перемены напряжений N_HE и N_FE при постоянной нагрузки
                    alldata[i].N_HE = 60 * alldata[i].t_r * alldata[i].n;
                    alldata[i].N_FE = alldata[i].N_HE;
                }

                //определение коэффициента долговечности K_HL
                decimal K_HL = Convert.ToDecimal(Math.Pow(Convert.ToDouble(alldata[i].N_HO / alldata[i].N_HE), 1 / 8.0));
                if (K_HL > 1M)
                {
                    K_HL = 1M;
                }
                alldata[i].K_HL = K_HL;

                //определение допускаемого контактного напряжения o_HP
                alldata[i].o_HP = alldata[i].o_HPr * alldata[i].K_HL;

                //расчет внешнего конусного расстояния Re
                decimal n1 = Convert.ToDecimal(Math.Pow(Math.Pow(Convert.ToDouble(alldata[i].u), 2) + 1, 1/2.0)); // pow(u^2, 1/2)
                decimal n2 = alldata[i].T1 * alldata[i].K_HB; //T1 * K_HB
                decimal n3 = (1M - alldata[i].K_be) * alldata[i].K_be * alldata[i].u * Convert.ToDecimal(Math.Pow(Convert.ToDouble(alldata[i].o_HP), 2));

                alldata[i].R_e = alldata[i].K_R * n1 * Convert.ToDecimal(Math.Pow(Convert.ToDouble(n2 / n3), 1 / 3.0));

                //определение внешнего делительного диаметра шестерни d_e1
                alldata[i].d_e1 = 2M * alldata[i].R_e * Convert.ToDecimal(Math.Sin(Convert.ToDouble(alldata[i].delta1) * Math.PI / 180.0));

                //определение внешнего делительного диаметра колеса d_e2
                alldata[i].d_e2 = 2M * alldata[i].R_e * Convert.ToDecimal(Math.Sin(Convert.ToDouble(alldata[i].delta2) * Math.PI / 180.0));

                //определение вспомогательного коэффициента K_m
                alldata[i].K_m = 14.5M;

                //определение коэффициента смещения x_n1
                double cosBm = Math.Pow(Math.Cos(Convert.ToDouble(alldata[i].beta_m) * Math.PI / 180.0), 2); //cos^2(B_m)
                alldata[i].x_n1 = 2M * Convert.ToDecimal(1 - (1 / Math.Pow(Convert.ToDouble(alldata[i].u), 2))) * Convert.ToDecimal(Math.Pow(cosBm / Convert.ToDouble(alldata[i].z1), 1/2));

                //Определение числа зубьев (эквивалентное/биэквивалентное) z_v
                if (alldata[i].TypeTeeth_z.Contains(StaticData.TypeTeeth_z[0]))
                {
                    //если эквивалентное
                    alldata[i].z_v = alldata[i].z1 / Convert.ToDecimal(Math.Cos(Convert.ToDouble(alldata[i].delta1) * Math.PI / 180));
                }
                else
                {
                    //если биэквивалентное
                    alldata[i].z_v = alldata[i].z1 / Convert.ToDecimal(
                                                                        Math.Cos(Convert.ToDouble(alldata[i].delta1) * Math.PI / 180) *
                                                                        Math.Cos(Math.Pow(Convert.ToDouble(alldata[i].beta_m), 3) * Math.PI / 180)
                                                                      );                                
                }

                //определение коэффициента Y_F1
                List<Table3> table3 = dbContext.table3.Where(s => s.Y_F1 != null).ToList();
                decimal z_v = Find_Zv(table3, alldata[i].z_v);
                table3 = table3.Where(x => x.z_v == z_v).ToList();
                decimal x_t1 = Find_Xt1(table3, alldata[i].x_t1);
                alldata[i].Y_F1 = Convert.ToDecimal(table3.FirstOrDefault(x => x.z_v == z_v && x.x_t1 == x_t1).Y_F1);

                //определение коэффициента изменения толщины зума x_t1
                List<Table4> table4 = dbContext.table4.Where(x => x.u_min <= alldata[i].u && alldata[i].u < x.B_max).ToList();
                if(alldata[i].u < 2.5M)
                {
                    table4 = dbContext.table4.Where(x => x.u_min == 2.5M).ToList();
                }
                if(alldata[i].u > 6.3M)
                {
                    table4 = dbContext.table4.Where(x => x.u_max == 6.3M).ToList();
                }

                table4 = table4.Where(x => x.B_min <= alldata[i].beta_m && alldata[i].beta_m < x.B_max).ToList();
                if (table4.Count != 0)
                {
                    alldata[i].x_t1 = table4[0].x_t1;
                }
                else
                {
                    //ошибка
                }

                //определение коэффициента, учитывающего форму зуба Y'_F1
                alldata[i].Y_F1r = alldata[i].Y_F1 * Convert.ToDecimal(Math.Pow(Convert.ToDouble((2.2M + alldata[i].x_t1) / 2.2M), 3));

                //определение коэффициента ширины венца шестерни относительно среднего делительного диаметра psi_bd
                alldata[i].psi_bd = alldata[i].K_be / ((2M - alldata[i].K_be) * Convert.ToDecimal(Math.Sin(Convert.ToDouble(alldata[i].delta1) * Math.PI / 180.0)));

                //определение показателя степени mF
                int m_F = 0;
                if(alldata[i].HB > 350)
                {
                    //если HB > 350
                    alldata[i].m_F = 9;
                    m_F = 9;
                }
                else
                {
                    //если HB <= 350
                    alldata[i].m_F = 6;
                    m_F = 6;
                }

                //определение коэффициента долговечности K_FL
                double K_FL = Math.Pow(Convert.ToDouble(alldata[i].N_FO / alldata[i].N_FE), 1 / Convert.ToDouble(alldata[i].m_F));
                if (alldata[i].N_FE >= alldata[i].N_FO)
                {
                    K_FL = 1;
                }
                else
                {
                    if(m_F == 9)
                    {
                        //при m_F = 9
                        if(K_FL > 1.63)
                        {
                            K_FL = 1.63;
                        }
                    }
                    else
                    {
                        //при m_F = 6
                        if(K_FL > 2.08)
                        {
                            K_FL = 2.08;
                        }
                    }
                }
                alldata[i].K_FL = Convert.ToDecimal(K_FL);

                //определение допустимого контктного напряжения o_FP
                alldata[i].o_FP = alldata[i].o_FPr * alldata[i].K_FL;

                //определение минимально допустимого среднего нормального модуля m_nm
                alldata[i].m_nm = alldata[i].K_m * Convert.ToDecimal(Math.Pow(Convert.ToDouble(
                    (alldata[i].T1 * alldata[i].K_FB * alldata[i].Y_F1r) / 
                    (Convert.ToDecimal(Math.Pow(Convert.ToDouble(alldata[i].z1), 2)) * alldata[i].psi_bd * alldata[i].o_FP)), 1/3.0));
            }
            return alldata;
        }
    }
}
