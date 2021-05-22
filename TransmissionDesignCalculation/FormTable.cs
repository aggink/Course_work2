using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Базы_данных.Курсовая_работа.Entity;

namespace Базы_данных.Курсовая_работа
{
    public partial class FormTable : Form
    {
        private DataBaseContext dbContext;
        private void none()
        {
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            label2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = dbContext.table1.Count + 1;

            dataGridView1.Rows[0].Cells[0].Value = "Материал";
            dataGridView1.Rows[0].Cells[1].Value = "Марка";
            dataGridView1.Rows[0].Cells[2].Value = "Вид упрочнения";
            dataGridView1.Rows[0].Cells[3].Value = "Твердость HB, min";
            dataGridView1.Rows[0].Cells[4].Value = "Твердость HB, max";
            dataGridView1.Rows[0].Cells[5].Value = "Вид нагрузки";
            dataGridView1.Rows[0].Cells[6].Value = "o'_FP";
            dataGridView1.Rows[0].Cells[7].Value = "N_F0";
            dataGridView1.Rows[0].Cells[8].Value = "o'_HP";
            dataGridView1.Rows[0].Cells[9].Value = "N_H0";

            int i = 1;
            foreach (var x in dbContext.table1)
            {
                dataGridView1.Rows[i].Cells[0].Value = x.Material;
                dataGridView1.Rows[i].Cells[1].Value = x.Mark;
                dataGridView1.Rows[i].Cells[2].Value = x.TypeHardening;
                dataGridView1.Rows[i].Cells[3].Value = x.HBmin.ToString();
                dataGridView1.Rows[i].Cells[4].Value = x.HBmax.ToString();
                dataGridView1.Rows[i].Cells[5].Value = x.TypeLoad;
                dataGridView1.Rows[i].Cells[6].Value = x.o_FP.ToString();
                dataGridView1.Rows[i].Cells[7].Value = x.N_FO.ToString();
                dataGridView1.Rows[i].Cells[8].Value = x.o_HP.ToString();
                dataGridView1.Rows[i].Cells[9].Value = x.N_HO.ToString();

                i = i + 1;
            }
            dataGridView1.Visible = true;
        }
        public FormTable(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();

            none();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //таблица 1
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Таблица 1";
            none();
        }
        //таблица 2
        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            label1.Text = "Таблица 2";
            label3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowCount = dbContext.table2.Count + 1;

            dataGridView1.Rows[0].Cells[0].Value = "Вид опоры";
            dataGridView1.Rows[0].Cells[1].Value = "Вид зубьев";
            dataGridView1.Rows[0].Cells[2].Value = "Твердость рабочей поверхности, min_HB";
            dataGridView1.Rows[0].Cells[3].Value = "Твердость рабочей поверхности, max_HB";
            dataGridView1.Rows[0].Cells[4].Value = "Относительная ширина эквивалентного конического колеса";
            dataGridView1.Rows[0].Cells[5].Value = "Контактная прочность K_HB";
            dataGridView1.Rows[0].Cells[6].Value = "Изгибная прочность K_FB";

            int i = 1;
            foreach (var x in dbContext.table2)
            {
                dataGridView1.Rows[i].Cells[0].Value = x.TypeSupport;
                dataGridView1.Rows[i].Cells[1].Value = x.TypeTeeth;
                if(x.HB_min == null) 
                {
                    dataGridView1.Rows[i].Cells[2].Value = "-";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = x.HB_min.ToString();
                }
                if(x.HB_max == null)
                {
                    dataGridView1.Rows[i].Cells[3].Value = "-";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[3].Value = x.HB_max.ToString();
                }
                dataGridView1.Rows[i].Cells[4].Value = x.L_FB.ToString();
                if (x.K_HB == null)
                {
                    dataGridView1.Rows[i].Cells[5].Value = "x";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = x.K_HB.ToString();
                }
                if (x.K_FB == null)
                {
                    dataGridView1.Rows[i].Cells[6].Value = "x";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[6].Value = x.K_FB.ToString();
                }

                i = i + 1;
            }
            dataGridView1.Visible = true;
        }
        //таблица 3
        private void button3_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = false;

            label1.Text = "Таблица 3";
            label4.Visible = true;
            dataGridView1.Visible = false;

            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = dbContext.table3.Count + 1;

            dataGridView1.Rows[0].Cells[0].Value = "Эквивалентное число зубьев z_v";
            dataGridView1.Rows[0].Cells[1].Value = "Коэффициент смещения x_t1";
            dataGridView1.Rows[0].Cells[2].Value = "Y_F1";

            int i = 1;
            foreach (var x in dbContext.table3)
            {
                dataGridView1.Rows[i].Cells[0].Value = x.z_v.ToString();
                dataGridView1.Rows[i].Cells[1].Value = x.x_t1.ToString();
                if (x.Y_F1 == null)
                {
                    dataGridView1.Rows[i].Cells[2].Value = "x";
                }
                else
                {
                    dataGridView1.Rows[i].Cells[2].Value = x.Y_F1.ToString();
                }

                i = i + 1;
            }

            dataGridView1.Visible = true;
        }
        //таблица 4
        private void button4_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            label1.Text = "Таблица 4";
            label5.Visible = true;
            dataGridView1.Visible = false;

            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = dbContext.table4.Count + 1;

            dataGridView1.Rows[0].Cells[0].Value = "Передаточное число u, min";
            dataGridView1.Rows[0].Cells[1].Value = "Передачтояное число u, max";
            dataGridView1.Rows[0].Cells[2].Value = "Угол наклона линии зуба betta_m, min";
            dataGridView1.Rows[0].Cells[3].Value = "Угол наклона линии зуба betta_m, max";
            dataGridView1.Rows[0].Cells[4].Value = "Коэффициент изменения толщины зуба x_t1";
            int i = 1;
            foreach (var x in dbContext.table4)
            {
                dataGridView1.Rows[i].Cells[0].Value = x.u_min.ToString();
                dataGridView1.Rows[i].Cells[1].Value = x.u_max.ToString();
                dataGridView1.Rows[i].Cells[2].Value = x.B_min.ToString();
                dataGridView1.Rows[i].Cells[3].Value = x.B_max.ToString();
                dataGridView1.Rows[i].Cells[4].Value = x.x_t1.ToString();

                i = i + 1;
            }

            dataGridView1.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
