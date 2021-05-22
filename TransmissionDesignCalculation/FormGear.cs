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
    public partial class FormGear : Form
    {
        private DataBaseContext dbContext;
        private Gear gear;
        private FormNode formNode;
        private void WriteTable()
        {
            button1.Text = "Изменить параметры деталей";
            label9.Visible = true;
            dataGridView1.RowCount = 15;
            dataGridView1.ColumnCount = 2;

            dataGridView1.Rows[0].Cells[0].Value = "Наименование параметра";
            dataGridView1.Rows[0].Cells[1].Value = "Значение";

            dataGridView1.Rows[1].Cells[0].Value = "Материал";
            dataGridView1.Rows[1].Cells[1].Value = gear.detail.Material;

            dataGridView1.Rows[2].Cells[0].Value = "Марка";
            dataGridView1.Rows[2].Cells[1].Value = gear.detail.Mark;

            dataGridView1.Rows[3].Cells[0].Value = "Термообработка";
            dataGridView1.Rows[3].Cells[1].Value = gear.detail.TypeHardening;

            dataGridView1.Rows[4].Cells[0].Value = "Вид зубьев";
            dataGridView1.Rows[4].Cells[1].Value = gear.detail.TypeTeeth;

            dataGridView1.Rows[5].Cells[0].Value = "Вид числа зубьев";
            dataGridView1.Rows[5].Cells[1].Value = gear.detail.TypeTeeth_z;

            dataGridView1.Rows[6].Cells[0].Value = "Угол наклона линии зуба";
            dataGridView1.Rows[6].Cells[1].Value = gear.detail.beta_m.ToString();

            dataGridView1.Rows[7].Cells[0].Value = "Наименование детали";
            dataGridView1.Rows[7].Cells[1].Value = "Шестерня";

            dataGridView1.Rows[8].Cells[0].Value = "Код детали (шестерня)";
            dataGridView1.Rows[8].Cells[1].Value = gear.detail.gearId.ToString();

            dataGridView1.Rows[9].Cells[0].Value = "Число зубьев шестерни";
            dataGridView1.Rows[9].Cells[1].Value = gear.detail.z1.ToString();

            dataGridView1.Rows[10].Cells[0].Value = "Угол делительного конуса шестерни";
            dataGridView1.Rows[10].Cells[1].Value = gear.detail.delta1.ToString();

            dataGridView1.Rows[11].Cells[0].Value = "Наименование детали";
            dataGridView1.Rows[11].Cells[1].Value = "колесо";

            dataGridView1.Rows[12].Cells[0].Value = "Код детали (колесо)";
            dataGridView1.Rows[12].Cells[1].Value = gear.detail.wheelId.ToString();

            dataGridView1.Rows[13].Cells[0].Value = "Число зубьев колеса";
            dataGridView1.Rows[13].Cells[1].Value = gear.detail.z2.ToString();

            dataGridView1.Rows[14].Cells[0].Value = "Угол делительного конуса колеса";
            dataGridView1.Rows[14].Cells[1].Value = gear.detail.delta2.ToString();

            dataGridView1.Visible = true;
        }
        private void FormGear_FormClosing(object sender, EventArgs e)
        {
            //Handle event here
            System.Windows.Forms.Application.Exit();
        }
        public FormGear(FormNode formNode, DataBaseContext dbContext, ref Gear gear)
        {
            //this.Closing += new CancelEventHandler(FormGear_FormClosing);
            this.dbContext = dbContext;
            this.gear = gear;
            this.formNode = formNode;

            InitializeComponent();

            button4.Text = "Сохранить";

            //код сборочной единицы
            if (gear.save == false)
            {
                gear.GearId = Guid.NewGuid();
            }
            label11.Text = gear.GearId.ToString();

            comboBox4.Items.Clear();
            //тип механической передачи
            comboBox4.Items.Add(StaticData.TypeTransmition);
            comboBox4.SelectedIndex = 0;

            comboBox1.Items.Clear();
            //вид опоры
            comboBox1.Items.Add(StaticData.TypeSupport[0]);
            comboBox1.Items.Add(StaticData.TypeSupport[1]);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            //тип нагрузки (постоянная/ступенчатая)
            comboBox2.Items.Add(StaticData.TypeLoad_p[0]);
            comboBox2.Items.Add(StaticData.TypeLoad_p[1]);
            comboBox2.SelectedIndex = 0;

            comboBox3.Items.Clear();
            //вид нагрузки (реверсивная/нереверсивная)
            comboBox3.Items.Add(StaticData.TypeLoad_r[0]);
            comboBox3.Items.Add(StaticData.TypeLoad_r[1]);
            comboBox3.SelectedIndex = 0;

            //если есть информация о шестерне и колесе
            if(gear.detail.save == true)
            {
                WriteTable();
            }
            else
            {
                button1.Text = "Добавить деталь";
                label9.Visible = false;
                dataGridView1.Visible = false;
            }

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }
        public void UpdateGear()
        {
            //код передачи
            label11.Text = gear.GearId.ToString();
            textBox1.Text = gear.N.ToString();
            textBox2.Text = gear.n.ToString();
            textBox3.Text = gear.n1.ToString();
            textBox6.Text = gear.t_r.ToString();
            //тип механической передачи
            comboBox4.Items.Clear();
            comboBox4.Items.Add(StaticData.TypeTransmition);
            comboBox4.SelectedIndex = 0;

            //вид опоры
            comboBox1.Items.Clear();
            comboBox1.Items.Add(StaticData.TypeSupport[0]);
            comboBox1.Items.Add(StaticData.TypeSupport[1]);
            if (gear.TypeSupport != null)
            {
                if (StaticData.TypeSupport[0] == gear.TypeSupport)
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;
                }
            }
            else
            {
                comboBox1.SelectedIndex = 0;
            }

            //вид нагрузки (постоянная/ступенчатая)
            comboBox2.Items.Clear();
            comboBox2.Items.Add(StaticData.TypeLoad_p[0]);
            comboBox2.Items.Add(StaticData.TypeLoad_p[1]);
            if (gear.TypeLoad_p != null)
            {
                if (StaticData.TypeLoad_p[0].ToLower() == gear.TypeLoad_p.ToLower())
                {
                    comboBox2.SelectedIndex = 0;
                    label7.Visible = false;
                    textBox4.Visible = false;
                    label8.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                {
                    comboBox2.SelectedIndex = 1;
                    if(gear.N_FE != null)
                    {
                        textBox5.Text = gear.N_FE.ToString();
                    }
                    if(gear.N_HE != null)
                    {
                        textBox4.Text = gear.N_HE.ToString();
                    }
                    label7.Visible = true;
                    textBox4.Visible = true;
                    label8.Visible = true;
                    textBox5.Visible = true;
                }
            }
            else
            {
                comboBox2.SelectedIndex = 0;
            }

            //тип нагрузки (реверсивная/нереверсивная)
            comboBox3.Items.Clear();
            comboBox3.Items.Add(StaticData.TypeLoad_r[0]);
            comboBox3.Items.Add(StaticData.TypeLoad_r[1]);
            if (gear.TypeLoad_r != null)
            {
                if (StaticData.TypeLoad_r[0] == gear.TypeLoad_r)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    comboBox3.SelectedIndex = 1;
                }
            }
            else
            {
                comboBox3.SelectedIndex = 0;
            }

            if (gear.detail != null && gear.detail.save == true)
            {
                WriteTable();
            }
            else
            {
                label9.Visible = false;
                dataGridView1.Visible = false;
                dataGridView1.ColumnCount = 0;
                dataGridView1.RowCount = 0;
            }
        }
        public FormGear(FormNode formNode, DataBaseContext dbContext, ref Gear gear, string text)
        {
            //this.Closing += new CancelEventHandler(FormGear_FormClosing);
            this.dbContext = dbContext;
            this.gear = gear;
            this.formNode = formNode;

            InitializeComponent();

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            button4.Text = "Изменить";

            if (text.Contains("изменить"))
            {
                UpdateGear();
            }
        }
        private (string, bool) save()
        {
            bool flag = true;
            decimal number;

            string text = "";
            bool flag_error = false;

            //тип механической передачи
            gear.TypeGear = comboBox4.SelectedItem.ToString();

            //мощность
            flag = decimal.TryParse(textBox1.Text.Replace(".", ","), out number);
            if (flag)
            {
                gear.N = number;
            }
            else
            {
                text += "Неверный формат данных (Мощность). ";
                flag_error = true;
            }

            //частота вращения
            flag = decimal.TryParse(textBox2.Text.Replace(".", ","), out number);
            if (flag)
            {
                gear.n = number;
            }
            else
            {
                text += "Неверный формат данных (Частота вращения). ";
                flag_error = true;
            }

            //частота вращения меньшего шкива
            flag = decimal.TryParse(textBox3.Text.Replace(".", ","), out number);
            if (flag)
            {
                gear.n1 = number;
            }
            else
            {
                text += "Неверный формат данных (Частота вращения меньшего шкива). ";
                flag_error = true;
            }
            //полное число работы передачи
            flag = decimal.TryParse(textBox6.Text.Replace(".", ","), out number);
            if (flag) 
            {
                gear.t_r = number;
            }
            else
            {
                text += "Неверный формат данных (Полное число работы передачи). ";
                flag_error = true;
            }
            gear.TypeSupport = comboBox1.SelectedItem.ToString();

            gear.TypeLoad_p = comboBox2.SelectedItem.ToString();

            gear.TypeLoad_r = comboBox3.SelectedItem.ToString();

            if (gear.TypeLoad_p.Contains(StaticData.TypeLoad_p[1]))
            {
                //число циклов перемены напряжений
                flag = decimal.TryParse(textBox4.Text.Replace(".", ","), out number);
                if (flag)
                {
                    gear.N_HE = number;
                }
                else
                {
                    text += "Неверный формат данных (число циклов перемены напряжений). ";
                    flag_error = true;
                }
                //эквивалентное число циклов перемены напряжений
                flag = decimal.TryParse(textBox5.Text.Replace(".", ","), out number);
                if (flag)
                {
                    gear.N_FE = number;
                }
                else
                {
                    text += "Неверный формат данных (эквивалентное число циклов перемены напряжений). ";
                    flag_error = true;
                }
            }
            else
            {
                gear.N_FE = null;
                gear.N_HE = null;
            }
            return (text, flag_error);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            (string text, bool flag_error) = save();

            if (flag_error)
            {
                ErrorManager.InfoOK(text);
            }
            else
            {
                if(gear.detail.save == false)
                {
                    string p = "Данные о шестерне и колесе не добавлены! Добавьте данные о деталях!";
                    ErrorManager.InfoOK(p);
                }
                else
                {
                    text = "";
                    bool e_flag = false;
                    if(gear.N <= 0)
                    {
                        text += "Мощность должны быть больше 0. ";
                        e_flag = true;
                    }
                    if(gear.n <= 0)
                    {
                        text += "Частота вращения должны быть больше 0. ";
                        e_flag = true;
                    }
                    if(gear.n1 <= 0)
                    {
                        text += "Частота вращения меньшего шкива должны быть больше 0. ";
                        e_flag = true;
                    }
                    if(gear.t_r <= 0)
                    {
                        text += "Полное число работы передачи должны быть больше 0. ";
                        e_flag = true;
                    }
                    if(gear.N_HE != null && gear.N_HE <= 0)
                    {
                        text += "Число циклов перемены напряжений должно быть большк нуля. ";
                        e_flag = true;
                    }
                    if (gear.N_FE != null && gear.N_FE <= 0)
                    {
                        text += "Эквивалентное число циклов перемены напряжений должно быть большк нуля. ";
                        e_flag = true;
                    }
                    if (e_flag)
                    {
                        ErrorManager.InfoOK(text);
                    }
                    else
                    {
                        gear.save = true;
                        if (formNode.node.gear.FirstOrDefault(s => s.GearId == gear.GearId) == null)
                        {
                            formNode.node.gear.Add(gear);
                        }
                        formNode.UpdateNode();
                        formNode.node.save = true;
                        formNode.Show();
                        this.Close();
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                (string text, bool flag_error) = save();
                if (flag_error)
                {
                    ErrorManager.InfoOK(text);
                }

            }
            if(gear.detail.save == false)
            {
                FormDetail formDetail = new FormDetail(this, dbContext, ref gear.detail);
                this.Visible = false;
                formDetail.Show();
            }
            else
            {
                FormDetail formDetail = new FormDetail(this, dbContext, ref gear.detail, "изменить");
                this.Visible = false;
                formDetail.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (gear.detail.save == true)
            {
                string text = "Вы действительно хотите удалить информацию о деталях?";
                string error = "Удаление";
                DialogResult result = ErrorManager.InfoYesNo(text, error);
                if (result == DialogResult.Yes)
                {
                    gear.detail = new Detail();
                    label9.Visible = false;
                    dataGridView1.Visible = false;
                    dataGridView1.RowCount = 0;
                    dataGridView1.ColumnCount = 0;

                    button1.Text = "Добавить деталь";
                }
            }
            else
            {
                string text = "Нет данных о деталях!";
                ErrorManager.InfoOK(text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (gear.save == true && gear.detail.save == true)
            {
                string text = "Несохраненные данные будут утеряны!";
                string error = "Закрыть текущее окно?";
                DialogResult result = ErrorManager.InfoYesNo(text, error);
                if (result == DialogResult.Yes)
                {
                    formNode.UpdateNode();
                    formNode.Show();
                    this.Close();
                }
            }
            else
            {
                string text = "Несохраненные данные будут утеряны!";
                string error = "Закрыть текущее окно?";
                DialogResult result = ErrorManager.InfoYesNo(text, error);
                if (result == DialogResult.Yes)
                {
                    formNode.UpdateNode();
                    formNode.Show();
                    this.Close();
                }
                //string text = "";
                //if (gear.save != true)
                //{
                //    text = "Заполните информацию о передаче!";
                //}
                //if(gear.detail.save != true)
                //{
                //    text = "Заполните информацию о деталях";
                //}
                //DialogResult result = ErrorManager.InfoOK(text);
            }
        }

        private void FormGear_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //если постоянная
            if (StaticData.TypeLoad_p[0] == comboBox2.SelectedItem.ToString())
            {
                //число циклов перемены напряжений
                label7.Visible = false;
                textBox4.Visible = false;
                textBox4.Text = "";
                //эквивалентное число циклов перемены напряжений
                label8.Visible = false;
                textBox5.Visible = false;
                textBox5.Text = "";
            }
            //если ступенчатая
            if (StaticData.TypeLoad_p[1] == comboBox2.SelectedItem.ToString())
            {
                //число циклов перемены напряжений
                textBox4.Text = "";
                label7.Visible = true;
                textBox4.Visible = true;
                //эквивалентное число циклов перемены напряжений
                textBox5.Text = "";
                label8.Visible = true;
                textBox5.Visible = true;
            }
        }
    }
}
