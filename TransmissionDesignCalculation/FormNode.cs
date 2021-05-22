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
using Базы_данных.Курсовая_работа.Manager;
using Базы_данных.Курсовая_работа.Model;

namespace Базы_данных.Курсовая_работа
{
    public partial class FormNode : Form
    {
        private DataBaseContext dbContext;
        public Node node;
        private FormMain formMain;
        public void UpdateNode()
        {

            if (node.save == false || node.gear.Count == 0)
            {
                button2.Visible = false;
                button3.Visible = false;
                label4.Visible = false;
                dataGridView1.Visible = false;
            }
            if (node.gear.Count != 0)
            {
                dataGridView1.RowCount = node.gear.Count + 1;
                dataGridView1.ColumnCount = 22;
                //заполняем таблицу (шапку)
                dataGridView1.Rows[0].Cells[0].Value = "Id передачи";
                dataGridView1.Rows[0].Cells[1].Value = "Наименование передачи";
                dataGridView1.Rows[0].Cells[2].Value = "Тип механической передачи";
                dataGridView1.Rows[0].Cells[3].Value = "N";
                dataGridView1.Rows[0].Cells[4].Value = "n";
                dataGridView1.Rows[0].Cells[5].Value = "n1";
                dataGridView1.Rows[0].Cells[6].Value = "Вид опоры (шариковая/коликовая)";
                dataGridView1.Rows[0].Cells[7].Value = "Тип нагрузки (реверсивная/нереверсивная)";
                dataGridView1.Rows[0].Cells[8].Value = "Вид нагрузки (постоянная/ступенчаная)";
                dataGridView1.Rows[0].Cells[9].Value = "N_HE (ступенчатая)";
                dataGridView1.Rows[0].Cells[10].Value = "N_FE (ступенчатая)";
                dataGridView1.Rows[0].Cells[11].Value = "Материал";
                dataGridView1.Rows[0].Cells[12].Value = "Марка";
                dataGridView1.Rows[0].Cells[13].Value = "Термообработка";
                dataGridView1.Rows[0].Cells[14].Value = "Вид зубьев";
                dataGridView1.Rows[0].Cells[15].Value = "Вид числа зубьев (эквивалентное/биэквивалентное)";
                dataGridView1.Rows[0].Cells[16].Value = "β_m";
                dataGridView1.Rows[0].Cells[17].Value = "z1";
                dataGridView1.Rows[0].Cells[18].Value = "δ1";
                dataGridView1.Rows[0].Cells[19].Value = "z2";
                dataGridView1.Rows[0].Cells[20].Value = "δ2";
                dataGridView1.Rows[0].Cells[21].Value = "t_ч";

                //заполняем таблицу (строки)
                int i = 1;
                foreach (var gear in node.gear)
                {
                    int j = 0;
                    //код передачи
                    dataGridView1.Rows[i].Cells[j].Value = gear.GearId.ToString();
                    j = j + 1;
                    //наименование передачи
                    dataGridView1.Rows[i].Cells[j].Value = gear.NameGear;
                    j = j + 1;
                    //тип механической передачи
                    dataGridView1.Rows[i].Cells[j].Value = gear.TypeGear;
                    j = j + 1;
                    //мощность
                    dataGridView1.Rows[i].Cells[j].Value = gear.N.ToString();
                    j = j + 1;
                    //частота вращения
                    dataGridView1.Rows[i].Cells[j].Value = gear.n.ToString();
                    j = j + 1;
                    //частота вращения меньшего шкива
                    dataGridView1.Rows[i].Cells[j].Value = gear.n1.ToString();
                    j = j + 1;
                    //вид опоры (шариковая/роликовая)
                    dataGridView1.Rows[i].Cells[j].Value = gear.TypeSupport;
                    j = j + 1;
                    //тип нагрузки (реверсивная/нереверсивная)
                    dataGridView1.Rows[i].Cells[j].Value = gear.TypeLoad_r;
                    j = j + 1;
                    //вид нагрузки (постоянная/ступенчатая)
                    dataGridView1.Rows[i].Cells[j].Value = gear.TypeLoad_p;
                    j = j + 1;
                    //если ступенчатая, то число циклов перемены напряжений при ступенчатой нагрузки N_HE
                    if (gear.N_HE != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = gear.N_HE.ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "-";
                    }
                    j = j + 1;
                    //если ступенчатая, то эквивалентное число циклов перемены напряжений при ступенчатой нагрузки N_FE
                    if (gear.N_FE != null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = gear.N_FE.ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "-";
                    }
                    j = j + 1;
                    //материал
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.Material;
                    j = j + 1;
                    //марка
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.Mark;
                    j = j + 1;
                    //термообработка
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.TypeHardening;
                    j = j + 1;
                    //вид зубьев
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.TypeTeeth;
                    j = j + 1;
                    //вид числа зубьев
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.TypeTeeth_z;
                    j = j + 1;
                    //угол наклона линии зуба
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.beta_m.ToString();
                    j = j + 1;
                    //число зубьев шестерни
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.z1.ToString();
                    j = j + 1;
                    //угол делительного диаметра шестерни
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.delta1.ToString();
                    j = j + 1;
                    //число зубьев колеса
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.z2.ToString();
                    j = j + 1;
                    //угол делительного диаметра колеса
                    dataGridView1.Rows[i].Cells[j].Value = gear.detail.delta2.ToString();
                    j = j + 1;
                    //полное число работы передачи
                    dataGridView1.Rows[i].Cells[j].Value = gear.t_r.ToString();

                    i = i + 1;
                }
                button2.Visible = true;
                button3.Visible = true;
                label4.Visible = true;
                dataGridView1.Visible = true;
            }
        }
        private void FormNode_FormClosing(object sender, EventArgs e)
        {
            //Handle event here
            System.Windows.Forms.Application.Exit();
        }
        public FormNode(FormMain formMain, DataBaseContext dbContext, ref Node node)
        {
            //this.Closing += new CancelEventHandler(FormNode_FormClosing);

            this.dbContext = dbContext;
            this.node = node;
            this.formMain = formMain;
            InitializeComponent();
            if (node.save == false)
            {
                node.NodeId = Guid.NewGuid();
            }
            label3.Text = node.NodeId.ToString();

            UpdateNode();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //результат
        private void button4_Click(object sender, EventArgs e)
        {
            if (node.gear.Count != 0)
            {
                node.save = true;
                FormResult formResult = new FormResult(formMain, dbContext, ref node);
                formResult.Show();
                this.Close();
            }
            else
            {
                string text = "В узле не задано передач! Добавьте передачи.";
                ErrorManager.InfoOK(text);
            }
        }
        //добавить деталь
        private void button1_Click(object sender, EventArgs e)
        {
           
            Gear gear = new Gear();
            FormGear formGear = new FormGear(this, dbContext, ref gear);
            this.Hide();
            formGear.Show();
        }
        //редактирование передачи
        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row == -1)
            {
                string text = "Не выбрана передача для редактирования данных";
                ErrorManager.InfoOK(text);
            }
            else
            {
                if (row != 0)
                {
                    Gear gear = node.gear.FirstOrDefault(x => x.GearId == Guid.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString()));
                    FormGear formGear = new FormGear(this, dbContext, ref gear, "изменить");
                    formGear.Show();
                    this.Hide();
                }
                else
                {
                    string text = "Выбрана недопустимая строка!";
                    ErrorManager.InfoOK(text);
                }
            }
        }
        //удаление передачи
        private void button2_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if(row == -1)
            {
                string text = "Не выбрана передача для удаления";
                ErrorManager.InfoOK(text);
            }
            if(row != 0)
            {
                Guid GearId = Guid.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                string text = "Вы действительно хотите удалить передачу " + GearId.ToString() + " ?";
                string error = "Удаление";
                DialogResult result = ErrorManager.InfoYesNo(text, error);
                if(result == DialogResult.Yes)
                {
                    Gear gear = node.gear.FirstOrDefault(s => s.GearId == GearId);
                    node.gear.Remove(gear);
                    UpdateNode();
                }
                if(node.gear.Count == 0)
                {
                    button2.Visible = false;
                    button3.Visible = false;
                    label4.Visible = false;
                    dataGridView1.Visible = false;
                    dataGridView1.ColumnCount = 0;
                    dataGridView1.RowCount = 0;
                }

            }
            else
            {
                string text = "Выбрана недопустимая строка!";
                ErrorManager.InfoOK(text);
            }
        }
        //выйти в главное меню
        private void button6_Click(object sender, EventArgs e)
        {
            string text = "Вы уверены, что хотите выйти в главное меню? Данные не будут сохранены! Для сохранения данных выполните операцию 'произвести расчет' и сохраните результаты в файл!";
            string error = "Выйти в главное меню?";
            DialogResult result = ErrorManager.InfoYesNo(text, error);
            if(result == DialogResult.Yes)
            {
                formMain.UpdateRecordFile();
                formMain.Show();
                this.Close();
            }
        }
    }
}
