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
    public partial class FormDetail : Form
    {
        private DataBaseContext dbContext;
        private Detail detail;
        private FormGear formGear;
        //задаем материал
        private void installMaterial()
        {

            List<string> material = new List<string>();
            //задаем материал
            for (int i = 0; i < dbContext.table1.Count; i++)
            {
                bool flag = material.All(s => s != dbContext.table1[i].Material);
                if (flag)
                {
                    material.Add(dbContext.table1[i].Material);
                }
            }
            foreach (var mat in material)
            {
                comboBox1.Items.Add(mat);
            }
            comboBox1.SelectedIndex = 0;
        }
        //задем марку материала
        private void installMark()
        {
            List<string> list = new List<string>();
            foreach (var str in dbContext.table1)
            {
                if (str.Material.Contains(comboBox1.SelectedItem.ToString()))
                {
                    bool flag = list.All(s => s != str.Mark);
                    if (flag)
                    {
                        list.Add(str.Mark);
                    }
                }
            }
            foreach(var s in list)
            {
                comboBox2.Items.Add(s);
            }
            comboBox2.SelectedIndex = 0;
        }
        //задаем вид термообработки
        private void installTypeHardening()
        {
            List<string> list = new List<string>();
            foreach (var str in dbContext.table1)
            {
                if (str.Material.Contains(comboBox1.SelectedItem.ToString()) && str.Mark.Contains(comboBox2.SelectedItem.ToString()))
                {
                    bool flag = list.All(s => s != str.TypeHardening);
                    if (flag)
                    {
                        list.Add(str.TypeHardening);
                    }
                }
            }
            foreach (var s in list)
            {
                comboBox3.Items.Add(s);
            }
            comboBox3.SelectedIndex = 0;
        }
        private void FormDetail_FormClosing(object sender, EventArgs e)
        {
            //Handle event here
            System.Windows.Forms.Application.Exit();
        }
        public FormDetail(FormGear formGear, DataBaseContext dbContext, ref Detail detail_)
        {
            InitializeComponent();
            //this.Closing += new CancelEventHandler(FormDetail_FormClosing);
            this.dbContext = dbContext;
            this.detail = detail_;
            this.formGear = formGear;

            //код шестерни
            if (detail.save == false)
            {
                detail.gearId = Guid.NewGuid();
                //код колеса
                detail.wheelId = Guid.NewGuid();
            }

            label3.Text = detail.gearId.ToString();
            label15.Text = detail.wheelId.ToString();

            //вид зубьев
            comboBox6.Items.Add(StaticData.TypeTeeth);
            comboBox6.SelectedIndex = 0;

            //вид числа зубьев
            comboBox4.Items.Add(StaticData.TypeTeeth_z[0]);
            comboBox4.Items.Add(StaticData.TypeTeeth_z[1]);
            comboBox4.SelectedIndex = 0;

            //задаем материал
            installMaterial();
            //задаем марку материала
            comboBox2.Items.Clear();
            installMark();
            //задаем вид термообработки
            comboBox3.Items.Clear();
            installTypeHardening();

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        public FormDetail(FormGear formGear, DataBaseContext dbContext, ref Detail detail_, string text)
        {
            //this.Closing += new CancelEventHandler(FormDetail_FormClosing);
            this.dbContext = dbContext;
            this.detail = detail_;
            this.formGear = formGear;

            InitializeComponent();

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            if (text.Contains("изменить"))
            {
                button1.Text = "Изменить";
                //код шестерни
                label3.Text = detail.gearId.ToString();
                //код колеса
                label15.Text = detail.wheelId.ToString();

                //количество зубьев шестерни
                textBox2.Text = detail.z1.ToString();
                //уголделительного конуса шестерни
                textBox4.Text = detail.delta1.ToString();

                //количество зубьев колеса
                textBox5.Text = detail.z2.ToString();
                //угол делительного конуса колеса
                textBox3.Text = detail.delta2.ToString();

                //вид зубьев
                comboBox6.Items.Add(detail.TypeTeeth);
                comboBox6.SelectedIndex = 0;

                //вид числа зубьев
                comboBox4.Items.Add(StaticData.TypeTeeth_z[0]);
                comboBox4.Items.Add(StaticData.TypeTeeth_z[1]);
                if (StaticData.TypeTeeth_z[0] == detail.TypeTeeth_z)
                {
                    comboBox4.SelectedIndex = 0;
                }
                else
                {
                    comboBox4.SelectedIndex = 1;
                }

                textBox6.Text = detail.beta_m.ToString();

                //материал
                comboBox1.Items.Clear();
                installMaterial();
                int cout = comboBox1.Items.Count;
                for(int i = 0; i < cout; i++)
                {
                    //if (detail.Material.Contains(comboBox1.Items[i].ToString()))
                    if (detail.Material == comboBox1.Items[i].ToString())
                    {
                        comboBox1.SelectedIndex = i;
                        break;
                    }
                }

                //марка
                comboBox2.Items.Clear();
                installMark();
                cout = comboBox2.Items.Count;
                for(int i = 0; i < cout; i++)
                {
                    //if (detail.Mark.Contains(comboBox2.Items[i].ToString()))
                    if (detail.Mark == comboBox2.Items[i].ToString())
                    {
                        comboBox2.SelectedIndex = i;
                        break;
                    }
                }

                //устанавливаем вид термообработки
                comboBox3.Items.Clear();
                installTypeHardening();
                cout = comboBox3.Items.Count;
                for(int i = 0; i < cout; i++)
                {
                    //if (detail.TypeHardening.Contains(comboBox3.Items[i].ToString()))
                    if (detail.TypeHardening == comboBox3.Items[i].ToString())
                    {
                        comboBox3.SelectedIndex = i;
                    }
                }
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FormDetail_Load(object sender, EventArgs e)
        {

        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int number;
            decimal number2;

            string text = "";
            bool flag_error = false;

            flag = int.TryParse(textBox2.Text.Replace(".", ","), out number);
            if (flag)
            {
                detail.z1 = number;
            }
            else
            {
                text += "Неверный формат данных (Число зубьев шестерни). ";
                flag_error = true;
            }

            flag = decimal.TryParse(textBox4.Text.Replace(".", ","), out number2);
            if (flag) 
            {
                detail.delta1 = number2;
            }
            else
            {
                text += "Неверный формат данных (Угол делительного конуса шестерни). ";
                flag_error = true;
            }

            flag = int.TryParse(textBox5.Text.Replace(".", ","), out number);
            if (flag)
            {
                detail.z2 = number;
            }
            else
            {
                text += "Неверный формат данных (Число зубьев колеса). ";
                flag_error = true;
            }

            flag = decimal.TryParse(textBox3.Text.Replace(".", ","), out number2);
            if (flag)
            {
                detail.delta2 = number2;
            }
            else
            {
                text += "Неверный формат данных (Угол делительного конуса колеса). ";
                flag_error = true;
            }

            flag = decimal.TryParse(textBox6.Text.Replace(".", ","), out number2);
            if (flag)
            {
                detail.beta_m = number2;
            }
            else
            {
                text += "Неверный формат данных (Угол наклона линии зуба). ";
                flag_error = true;
            }

            detail.Material = comboBox1.SelectedItem.ToString();
            detail.Mark = comboBox2.SelectedItem.ToString();
            detail.TypeHardening = comboBox3.SelectedItem.ToString();
            detail.TypeTeeth = comboBox6.SelectedItem.ToString();
            detail.TypeTeeth_z = comboBox4.SelectedItem.ToString();

            if (flag_error)
            {
                ErrorManager.InfoOK(text);
            }
            else
            {
                bool f_error = false;
                text = "";
                if(detail.z1 <= 0)
                {
                    text += "Число зубьев шестерни должно быть больше 0. ";
                    f_error = true;
                }
                if (detail.z2 <= 0)
                {
                    text += "Число зубьев колеса должно быть больше 0. ";
                    f_error = true;
                }
                if (!(detail.delta2 >= 70 && detail.delta2 <= 80))
                {
                    text += "Угол делительного конуса колеса должен быть в пределах от 70 до 80 градусов. ";
                    f_error = true;
                }
                if(!(detail.delta1 <= 30 && detail.delta1 >= 20))
                {
                    text += "Угол делительного конуса шестерни должен быть в пределах от 20 до 30 градусов. ";
                    f_error = true;
                }
                if(!(detail.beta_m >= 25 && detail.beta_m <= 40))
                {
                    text += "Угол наклона линии зуба должен быть в пределах от 25 до 40. ";
                    f_error = true;
                }
                if (f_error)
                {
                    ErrorManager.InfoOK(text);
                }
                else {
                    detail.MaterialId = dbContext.table1.FirstOrDefault(s => s.Material.Contains(detail.Material) &&
                                                         s.Mark.Contains(detail.Mark) &&
                                                         s.TypeHardening.Contains(detail.TypeHardening)).Id;

                    detail.save = true;
                    formGear.UpdateGear();
                    formGear.Show();
                    this.Close();
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            installMark();
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            installTypeHardening();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = "Несохраненные данные будут утеряны!";
            string error = "Закрыть текущее окно?";

            DialogResult result = ErrorManager.InfoYesNo(text, error);
            if (result == DialogResult.Yes)
            {
                formGear.UpdateGear();
                formGear.Show();
                this.Close();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
