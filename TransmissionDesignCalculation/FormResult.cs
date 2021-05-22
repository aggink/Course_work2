using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Базы_данных.Курсовая_работа.Entity;
using Базы_данных.Курсовая_работа.Manager;
using Базы_данных.Курсовая_работа.Model;

namespace Базы_данных.Курсовая_работа
{
    public partial class FormResult : Form
    {
        private DataBaseContext dbCondext;
        private FormMain formMain;

        private Node node;
        private List<AllData> alldata;
        private List<string> Param = new List<string>();
        private List<bool> Pbool= new List<bool>();

        //задать параметры
        private void WriteParam()
        {
            this.Param.Add("Id передачи"); 
            this.Param.Add("Тип механической передачи");
            this.Param.Add("N");
            this.Param.Add("n");
            this.Param.Add("n1");
            this.Param.Add("t_ч");
            this.Param.Add("Вид опоры (шариковая/коликовая)");
            this.Param.Add("Тип нагрузки (реверсивная/нереверсивная)");
            this.Param.Add("Вид нагрузки (постоянная/ступенчаная)");
            this.Param.Add("N_HE");
            this.Param.Add("N_FE");
            this.Param.Add("Материал");
            this.Param.Add("Марка");
            this.Param.Add("Термообработка");
            this.Param.Add("Вид зубьев");
            this.Param.Add("Вид числа зубьев (эквивалентное/биэквивалентное)");
            this.Param.Add("β_m");
            this.Param.Add("z1");
            this.Param.Add("δ1");
            this.Param.Add("z2");
            this.Param.Add("δ2");

            this.Param.Add("T1");
            this.Param.Add("u");
            this.Param.Add("HB");
            this.Param.Add("K_be");
            this.Param.Add("L_FB");
            this.Param.Add("K_HB");
            this.Param.Add("K_d");
            this.Param.Add("K_R");
            this.Param.Add("N_H0");
            this.Param.Add("N_HE");
            this.Param.Add("K_HL");
            this.Param.Add("o'_HP");
            this.Param.Add("o_HP");
            this.Param.Add("K_m");
            this.Param.Add("K_FB");
            this.Param.Add("x_n1");
            this.Param.Add("z_v");
            this.Param.Add("Y_F1");
            this.Param.Add("x_t1");
            this.Param.Add("Y'_F1");
            this.Param.Add("psi_bd");
            this.Param.Add("o'_FP");
            this.Param.Add("N_F0");
            this.Param.Add("m_F");
            this.Param.Add("N_FE");
            this.Param.Add("K_FL");
            this.Param.Add("o_FP");
            this.Param.Add("R_e");
            this.Param.Add("d_e1");
            this.Param.Add("d_e2");
            this.Param.Add("m_nm");

            for(int i  = 0; i < Param.Count; i++)
            {
                Pbool.Add(false);
            }
        }
        //отобразить данные
        private void WriteData()
        {

            //таблица параметры узла
            dataGridView1.ColumnCount = 52;
            dataGridView1.RowCount = alldata.Count() + 1;

            //заполняем таблицу (шапку) - обяхательные не удаляемые параметры
            for(int j = 0; j < Param.Count; j++)
            {
                dataGridView1.Rows[0].Cells[j].Value = Param[j];
            }
           

            int i = 1;
            foreach(var gear in alldata)
            {
                dataGridView1.Rows[i].Cells[0].Value = gear.GearId.ToString();
                dataGridView1.Rows[i].Cells[1].Value = gear.TypeGear.ToString();
                dataGridView1.Rows[i].Cells[2].Value = gear.N.ToString();
                dataGridView1.Rows[i].Cells[3].Value = gear.n.ToString();
                dataGridView1.Rows[i].Cells[4].Value = gear.n1.ToString();
                dataGridView1.Rows[i].Cells[5].Value = gear.t_r.ToString();
                dataGridView1.Rows[i].Cells[6].Value = gear.TypeSupport;
                dataGridView1.Rows[i].Cells[7].Value = gear.TypeLoad_r;
                dataGridView1.Rows[i].Cells[8].Value = gear.TypeLoad_p;
                dataGridView1.Rows[i].Cells[9].Value = gear.N_HE.ToString();
                dataGridView1.Rows[i].Cells[10].Value = gear.N_FE.ToString();
                dataGridView1.Rows[i].Cells[11].Value = gear.Material;
                dataGridView1.Rows[i].Cells[12].Value = gear.Mark;
                dataGridView1.Rows[i].Cells[13].Value = gear.TypeHardening;
                dataGridView1.Rows[i].Cells[14].Value = gear.TypeTeeth;
                dataGridView1.Rows[i].Cells[15].Value = gear.TypeTeeth_z;
                dataGridView1.Rows[i].Cells[16].Value = gear.beta_m;
                dataGridView1.Rows[i].Cells[17].Value = gear.z1;
                dataGridView1.Rows[i].Cells[18].Value = gear.delta1;
                dataGridView1.Rows[i].Cells[19].Value = gear.z2;
                dataGridView1.Rows[i].Cells[20].Value = gear.delta2;

                dataGridView1.Rows[i].Cells[21].Value = Math.Round(gear.T1, 3).ToString();
                dataGridView1.Rows[i].Cells[22].Value = Math.Round(gear.u, 3).ToString();
                dataGridView1.Rows[i].Cells[23].Value = Math.Round(gear.HB, 3).ToString();
                dataGridView1.Rows[i].Cells[24].Value = Math.Round(gear.K_be, 3).ToString();
                dataGridView1.Rows[i].Cells[25].Value = Math.Round(gear.L_FB, 3).ToString();
                dataGridView1.Rows[i].Cells[26].Value = Math.Round(gear.K_HB, 3).ToString();
                dataGridView1.Rows[i].Cells[27].Value = Math.Round(gear.K_d, 3).ToString();
                dataGridView1.Rows[i].Cells[28].Value = Math.Round(gear.K_R, 3).ToString();
                dataGridView1.Rows[i].Cells[29].Value = Math.Round(gear.N_HO, 3).ToString();
                dataGridView1.Rows[i].Cells[30].Value = Math.Round(Decimal.Parse(gear.N_HE.ToString()), 3).ToString();
                dataGridView1.Rows[i].Cells[31].Value = Math.Round(gear.K_HL, 3).ToString();
                dataGridView1.Rows[i].Cells[32].Value = Math.Round(gear.o_HPr, 3).ToString();
                dataGridView1.Rows[i].Cells[33].Value = Math.Round(gear.o_HP, 3).ToString();
                dataGridView1.Rows[i].Cells[34].Value = Math.Round(gear.K_m, 3).ToString();
                dataGridView1.Rows[i].Cells[35].Value = Math.Round(gear.K_FB, 3).ToString();
                dataGridView1.Rows[i].Cells[36].Value = Math.Round(gear.x_n1, 3).ToString();
                dataGridView1.Rows[i].Cells[37].Value = Math.Round(gear.z_v, 3).ToString();
                dataGridView1.Rows[i].Cells[38].Value = Math.Round(gear.Y_F1, 3).ToString();
                dataGridView1.Rows[i].Cells[39].Value = Math.Round(gear.x_t1, 3).ToString();
                dataGridView1.Rows[i].Cells[40].Value = Math.Round(gear.Y_F1r, 3).ToString();
                dataGridView1.Rows[i].Cells[41].Value = Math.Round(gear.psi_bd, 3).ToString();
                dataGridView1.Rows[i].Cells[42].Value = Math.Round(gear.o_FPr, 3).ToString();
                dataGridView1.Rows[i].Cells[43].Value = Math.Round(gear.N_FO, 3).ToString();
                dataGridView1.Rows[i].Cells[44].Value = Math.Round(gear.m_F, 3).ToString();
                dataGridView1.Rows[i].Cells[45].Value = Math.Round(Decimal.Parse(gear.N_FE.ToString()), 3).ToString();
                dataGridView1.Rows[i].Cells[46].Value = Math.Round(gear.K_FL, 3).ToString();
                dataGridView1.Rows[i].Cells[47].Value = Math.Round(gear.o_FP, 3).ToString();
                dataGridView1.Rows[i].Cells[48].Value = Math.Round(gear.R_e, 3).ToString();
                dataGridView1.Rows[i].Cells[49].Value = Math.Round(gear.d_e1, 3).ToString();
                dataGridView1.Rows[i].Cells[50].Value = Math.Round(gear.d_e2, 3).ToString();
                dataGridView1.Rows[i].Cells[51].Value = Math.Round(gear.m_nm, 3).ToString();

                i = i + 1;
            }
        }
        public FormResult(FormMain formMain, DataBaseContext dbContext, ref Node node)
        {
            //this.FormClosing += FormResult_Closing;
            this.dbCondext = dbContext;
            this.formMain = formMain;
            this.node = node;
            InitializeComponent();

            WriteParam();
            //редактировать параметры узла
            label3.Visible = false;
            dataGridView1.Visible = false;
            this.alldata = new List<AllData>();
            foreach(var gear in node.gear)
            {
                AllData data = new AllData(node.NodeId, gear);
                alldata.Add(data);
            }

            Decision decision = new Decision(dbContext, alldata);
            //произвели расчет
            this.alldata = decision.Result();

            WriteData();
            label3.Visible = true;
            dataGridView1.Visible = true;

            //заполняем критерии сортировки
            foreach (var s in Param)
            {
                comboBox2.Items.Add(s);
            }
            comboBox2.SelectedIndex = 0;

            //заполянем критерии поиска
            comboBox1.Items.Add("критерий поиска");
            comboBox1.Items.Add(this.Param[0]);
            comboBox1.Items.Add(this.Param[6]);
            comboBox1.Items.Add(this.Param[7]);
            comboBox1.Items.Add(this.Param[8]);
            comboBox1.Items.Add(this.Param[11]);
            comboBox1.Items.Add(this.Param[12]);
            comboBox1.Items.Add(this.Param[13]);
            comboBox1.Items.Add(this.Param[15]);
            comboBox1.SelectedIndex = 0;

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
        }
        private void button6_Click(object sender, EventArgs e)
        {

        }
        //удалить строку
        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row != 0)
            {
                AllData data = alldata[row - 1];

                string text = "Вы действительно хотите удалить передачу " + data.GearId.ToString() + " ?";
                string error = "Удаление передачи";
                DialogResult result = ErrorManager.InfoYesNo(text, error);
                if (result == DialogResult.Yes)
                {
                    if (node.gear.Count != 0 && alldata.Count != 0)
                    {
                        dataGridView1.Visible = false;
                        node.gear.Remove(node.gear.FirstOrDefault(x => x.GearId == data.GearId));

                        this.alldata.Remove(data);

                        for (int i = row; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i + 1].Cells[j].Value;
                            }
                        }
                        dataGridView1.RowCount = dataGridView1.RowCount - 1;
                        dataGridView1.Visible = true;
                        if(this.alldata.Count == 0)
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                        }
                    }
                    else
                    {

                        string text1 = "Все передачи удалены!";
                        ErrorManager.InfoOK(text1);
                       
                    }
                }
            }
            else
            {
                if (node.gear.Count == 0)
                {
                    ErrorManager.InfoOK("Все передачи удалены!");
                }
                else
                {
                    string text = "Вы не можете удалить эту строку!";
                    ErrorManager.InfoOK(text);
                }
            }
        }
        //удалить столбец
        private void button4_Click(object sender, EventArgs e)
        {
            if (node.gear.Count != 0)
            {
                int col = dataGridView1.CurrentCell.ColumnIndex;
                if (col >= 0)
                {
                    dataGridView1.Visible = false;
                    for (int j = col; j < dataGridView1.ColumnCount - 1; j++)
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j + 1].Value;
                        }
                    }
                    dataGridView1.ColumnCount = dataGridView1.ColumnCount - 1;
                    dataGridView1.Visible = true;
                }
                else
                {
                    string text = "Все переменные скрыты!";
                    ErrorManager.InfoOK(text);
                }
            }
            else
            {
                string text = "Информация о всех передачах удалена";
                ErrorManager.InfoOK(text);
            }
        }
        //запись в файд
        private void WriteFile()
        {
            string file = ".\\DataTables\\DataTable.xml";
            XDocument xDoc = XDocument.Load(file);
            //получаем корневой элемент
            XElement xRoot = xDoc.Element("data");

            //true - если текущий узел имеет дочернии узлы
            if (xRoot.HasElements)
            {
                foreach (XElement node in xRoot.Elements("node").ToList())
                {
                    if (node.Attribute("id").Value.Contains(this.node.NodeId.ToString()))
                    {
                        node.Remove();
                        break;
                    }
                }
                WriteFile_(xDoc, xRoot);
            }
            else
            {
                WriteFile_(xDoc, xRoot);
            }
            xDoc.Save(file);
        }
        //записть в данных в файл
        private void WriteFile_(XDocument xDoc, XElement xRoot)
        {
            //создаем новый узел node
            XElement node = new XElement("node");
            XAttribute nodeid = new XAttribute("id", this.node.NodeId.ToString());
            node.Add(nodeid);

            foreach (var x in this.node.gear)
            {
                //создание нового узла gear
                XElement Gear_ = new XElement("Gear"); //главный
                XAttribute GearId = new XAttribute("GearId", x.GearId.ToString());
                Gear_.Add(GearId);

                XElement N = new XElement("N", x.N.ToString());
                XElement n = new XElement("n", (x.n.ToString()));
                XElement n1 = new XElement("n1", x.n1.ToString());
                XElement t_r = new XElement("t_r", x.t_r.ToString());
                XElement N_FE = new XElement("N_FE", x.N_FE.ToString());
                XElement N_HE = new XElement("N_HE", x.N_HE.ToString());
                XElement TypeGear = new XElement("TypeGear", x.TypeGear);
                XElement TypeLoad_p = new XElement("TypeLoad_p", x.TypeLoad_p);
                XElement TypeLoad_r = new XElement("TypeLoad_r", x.TypeLoad_r);
                XElement TypeSupport = new XElement("TypeSupport", x.TypeSupport);


                Gear_.Add(N);
                Gear_.Add(n);
                Gear_.Add(n1);
                Gear_.Add(t_r);
                Gear_.Add(N_FE);
                Gear_.Add(N_HE);
                Gear_.Add(TypeGear);
                Gear_.Add(TypeLoad_p);
                Gear_.Add(TypeLoad_r);
                Gear_.Add(TypeSupport);

                //создание нового узла - detail
                XElement Detail = new XElement("Detail");

                XElement DGearId = new XElement("DGearId", x.detail.gearId.ToString());
                XElement z1 = new XElement("z1", x.detail.z1.ToString());
                XElement delta1 = new XElement("delta1", x.detail.delta1.ToString());
                XElement wheelId = new XElement("wheelId", x.detail.wheelId.ToString());
                XElement z2 = new XElement("z2", x.detail.z2.ToString());
                XElement delta2 = new XElement("delta2", x.detail.delta2.ToString());

                XElement MaterialId = new XElement("MaterialId", x.detail.MaterialId.ToString());
                XElement Material = new XElement("Material", x.detail.Material);
                XElement Mark = new XElement("Mark", x.detail.Mark);
                XElement TypeHardening = new XElement("TypeHardening", x.detail.TypeHardening);
                XElement TypeTeeth = new XElement("TypeTeeth", x.detail.TypeTeeth);
                XElement TypeTeeth_z = new XElement("TypeTeeth_z", x.detail.TypeTeeth_z);
                XElement beta_m = new XElement("beta_m", x.detail.beta_m.ToString());

                Detail.Add(DGearId);
                Detail.Add(z1);
                Detail.Add(delta1);
                Detail.Add(wheelId);
                Detail.Add(z2);
                Detail.Add(delta2);
                Detail.Add(MaterialId);
                Detail.Add(Material);
                Detail.Add(Mark);
                Detail.Add(TypeHardening);
                Detail.Add(TypeTeeth);
                Detail.Add(TypeTeeth_z);
                Detail.Add(beta_m);

                Gear_.Add(Detail);

                node.Add(Gear_);
            }
            xRoot.Add(node);
        }
        //сохранить в файл
        private async void button2_Click(object sender, EventArgs e)
        {
            if (node.gear.Count != 0 && alldata.Count != 0)
            {
                await Task.Run(() => WriteFile());
                ErrorManager.InfoOK("Сохранение в файл выполнено успешно!");
            }
            else
            { 
                ErrorManager.InfoOK("Все данные о передачах были удалены!!");
            }
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            string text = "Вы действительно хотите выйти в главное меню? Внесенные изменения будут утеряны!";
            string error = "Выйти?";
            DialogResult result = ErrorManager.InfoYesNo(text, error);
            if (result == DialogResult.Yes)
            {
                formMain.UpdateRecordFile();
                formMain.Show();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormTable formTable = new FormTable(dbCondext);
            formTable.Show();
        }

        private void FormResult_Load(object sender, EventArgs e)
        {

        }
        //сортировать
        private void button7_Click(object sender, EventArgs e)
        {
            if (alldata.Count != 0 && node.gear.Count != 0)
            {
                dataGridView1.Visible = false;
                string sort = comboBox2.SelectedItem.ToString();
                //GearId
                if (sort == Param[0])
                {
                    if (!Pbool[0])
                    {
                        alldata = alldata.OrderBy(x => x.GearId).ToList();
                        Pbool[0] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.GearId).ToList();
                        Pbool[0] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeGear
                if (sort == Param[1])
                {
                    if (!Pbool[1])
                    {
                        alldata = alldata.OrderBy(x => x.TypeGear).ToList();
                        Pbool[1] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeGear).ToList();
                        Pbool[1] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N
                if (sort == Param[2])
                {
                    if (!Pbool[2])
                    {
                        alldata = alldata.OrderBy(x => x.N).ToList();
                        Pbool[2] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N).ToList();
                        Pbool[2] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //n
                if (sort == Param[3])
                {
                    if (!Pbool[3])
                    {
                        alldata = alldata.OrderBy(x => x.n).ToList();
                        Pbool[3] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.n).ToList();
                        Pbool[3] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //n1
                if (sort == Param[4])
                {
                    if (!Pbool[4])
                    {
                        alldata = alldata.OrderBy(x => x.n1).ToList();
                        Pbool[4] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.n1).ToList();
                        Pbool[4] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }

                //t_r
                if (sort == Param[5])
                {
                    if (!Pbool[5])
                    {
                        alldata = alldata.OrderBy(x => x.t_r).ToList();
                        Pbool[5] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.t_r).ToList();
                        Pbool[5] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeSupport
                if (sort == Param[6])
                {
                    if (!Pbool[6])
                    {
                        alldata = alldata.OrderBy(x => x.TypeSupport).ToList();
                        Pbool[6] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeSupport).ToList();
                        Pbool[6] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeLoad_r
                if (sort == Param[7])
                {
                    if (!Pbool[7])
                    {
                        alldata = alldata.OrderBy(x => x.TypeLoad_r).ToList();
                        Pbool[7] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeLoad_r).ToList();
                        Pbool[7] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeLoad_p
                if (sort == Param[8])
                {
                    if (!Pbool[8])
                    {
                        alldata = alldata.OrderBy(x => x.TypeLoad_p).ToList();
                        Pbool[8] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeLoad_p).ToList();
                        Pbool[8] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N_HE
                if (sort == Param[9])
                {
                    if (!Pbool[9])
                    {
                        alldata = alldata.OrderBy(x => x.N_HE).ToList();
                        Pbool[9] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N_HE).ToList();
                        Pbool[9] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N_FE
                if (sort == Param[10])
                {
                    if (!Pbool[10])
                    {
                        alldata = alldata.OrderBy(x => x.N_FE).ToList();
                        Pbool[10] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N_FE).ToList();
                        Pbool[10] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //Material
                if (sort == Param[11])
                {
                    if (!Pbool[11])
                    {
                        alldata = alldata.OrderBy(x => x.Material).ToList();
                        Pbool[11] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.Material).ToList();
                        Pbool[11] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //Mark
                if (sort == Param[12])
                {
                    if (!Pbool[12])
                    {
                        alldata = alldata.OrderBy(x => x.Mark).ToList();
                        Pbool[12] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.Mark).ToList();
                        Pbool[12] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeHardening
                if (sort == Param[13])
                {
                    if (!Pbool[13])
                    {
                        alldata = alldata.OrderBy(x => x.TypeHardening).ToList();
                        Pbool[13] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeHardening).ToList();
                        Pbool[13] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeTeeth
                if (sort == Param[14])
                {
                    if (!Pbool[14])
                    {
                        alldata = alldata.OrderBy(x => x.TypeTeeth).ToList();
                        Pbool[14] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeTeeth).ToList();
                        Pbool[14] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //TypeTeeth_z
                if (sort == Param[15])
                {
                    if (!Pbool[15])
                    {
                        alldata = alldata.OrderBy(x => x.TypeTeeth_z).ToList();
                        Pbool[15] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.TypeTeeth_z).ToList();
                        Pbool[15] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //beta_m
                if (sort == Param[16])
                {
                    if (!Pbool[16])
                    {
                        alldata = alldata.OrderBy(x => x.beta_m).ToList();
                        Pbool[16] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.beta_m).ToList();
                        Pbool[16] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //z1
                if (sort == Param[17])
                {
                    if (!Pbool[17])
                    {
                        alldata = alldata.OrderBy(x => x.z1).ToList();
                        Pbool[17] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.z1).ToList();
                        Pbool[17] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //delta1
                if (sort == Param[18])
                {
                    if (!Pbool[18])
                    {
                        alldata = alldata.OrderBy(x => x.delta1).ToList();
                        Pbool[18] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.delta1).ToList();
                        Pbool[18] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //z2
                if (sort == Param[19])
                {
                    if (!Pbool[19])
                    {
                        alldata = alldata.OrderBy(x => x.z2).ToList();
                        Pbool[19] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.z2).ToList();
                        Pbool[19] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //delta2
                if (sort == Param[20])
                {
                    if (!Pbool[20])
                    {
                        alldata = alldata.OrderBy(x => x.delta2).ToList();
                        Pbool[20] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.delta2).ToList();
                        Pbool[20] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //T1
                if (sort == Param[21])
                {
                    if (!Pbool[21])
                    {
                        alldata = alldata.OrderBy(x => x.T1).ToList();
                        Pbool[21] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.T1).ToList();
                        Pbool[21] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //u
                if (sort == Param[22])
                {
                    if (!Pbool[22])
                    {
                        alldata = alldata.OrderBy(x => x.u).ToList();
                        Pbool[22] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.u).ToList();
                        Pbool[22] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //HB
                if (sort == Param[23])
                {
                    if (!Pbool[23])
                    {
                        alldata = alldata.OrderBy(x => x.HB).ToList();
                        Pbool[23] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.HB).ToList();
                        Pbool[23] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_be
                if (sort == Param[24])
                {
                    if (!Pbool[24])
                    {
                        alldata = alldata.OrderBy(x => x.K_be).ToList();
                        Pbool[24] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_be).ToList();
                        Pbool[24] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //L_FB
                if (sort == Param[25])
                {
                    if (!Pbool[25])
                    {
                        alldata = alldata.OrderBy(x => x.L_FB).ToList();
                        Pbool[25] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.L_FB).ToList();
                        Pbool[25] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_HB
                if (sort == Param[26])
                {
                    if (!Pbool[26])
                    {
                        alldata = alldata.OrderBy(x => x.K_HB).ToList();
                        Pbool[26] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_HB).ToList();
                        Pbool[26] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_d
                if (sort == Param[27])
                {
                    if (!Pbool[27])
                    {
                        alldata = alldata.OrderBy(x => x.K_d).ToList();
                        Pbool[27] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_d).ToList();
                        Pbool[27] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_r
                if (sort == Param[28])
                {
                    if (!Pbool[28])
                    {
                        alldata = alldata.OrderBy(x => x.K_R).ToList();
                        Pbool[28] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_R).ToList();
                        Pbool[28] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N_HO
                if (sort == Param[29])
                {
                    if (!Pbool[29])
                    {
                        alldata = alldata.OrderBy(x => x.N_HO).ToList();
                        Pbool[29] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N_HO).ToList();
                        Pbool[29] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N_HE
                if (sort.Contains(Param[30]))
                {
                    if (!Pbool[30])
                    {
                        alldata = alldata.OrderBy(x => x.N_HE).ToList();
                        Pbool[30] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N_HE).ToList();
                        Pbool[30] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_HL
                if (sort == Param[31])
                {
                    if (!Pbool[31])
                    {
                        alldata = alldata.OrderBy(x => x.K_HL).ToList();
                        Pbool[31] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_HL).ToList();
                        Pbool[31] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //o_HPr
                if (sort == Param[32])
                {
                    if (!Pbool[32])
                    {
                        alldata = alldata.OrderBy(x => x.o_HPr).ToList();
                        Pbool[32] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.o_HPr).ToList();
                        Pbool[32] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //o_HP
                if (sort == Param[33])
                {
                    if (!Pbool[33])
                    {
                        alldata = alldata.OrderBy(x => x.o_HP).ToList();
                        Pbool[33] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.o_HP).ToList();
                        Pbool[33] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_m
                if (sort == Param[34])
                {
                    if (!Pbool[34])
                    {
                        alldata = alldata.OrderBy(x => x.K_m).ToList();
                        Pbool[34] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_m).ToList();
                        Pbool[34] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_FB
                if (sort == Param[35])
                {
                    if (!Pbool[35])
                    {
                        alldata = alldata.OrderBy(x => x.K_FB).ToList();
                        Pbool[35] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_FB).ToList();
                        Pbool[35] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //x_n1
                if (sort == Param[36])
                {
                    if (!Pbool[36])
                    {
                        alldata = alldata.OrderBy(x => x.x_n1).ToList();
                        Pbool[36] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.x_n1).ToList();
                        Pbool[36] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //z_v
                if (sort == Param[37])
                {
                    if (!Pbool[37])
                    {
                        alldata = alldata.OrderBy(x => x.z_v).ToList();
                        Pbool[37] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.z_v).ToList();
                        Pbool[37] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //Y_F1
                if (sort == Param[38])
                {
                    if (!Pbool[38])
                    {
                        alldata = alldata.OrderBy(x => x.Y_F1).ToList();
                        Pbool[38] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.Y_F1).ToList();
                        Pbool[38] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //x_t1
                if (sort == Param[39])
                {
                    if (!Pbool[39])
                    {
                        alldata = alldata.OrderBy(x => x.x_t1).ToList();
                        Pbool[39] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.x_t1).ToList();
                        Pbool[39] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //Y_F1r
                if (sort == Param[40])
                {
                    if (!Pbool[40])
                    {
                        alldata = alldata.OrderBy(x => x.Y_F1r).ToList();
                        Pbool[40] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.Y_F1r).ToList();
                        Pbool[40] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //psi_bd
                if (sort == Param[41])
                {
                    if (!Pbool[41])
                    {
                        alldata = alldata.OrderBy(x => x.psi_bd).ToList();
                        Pbool[41] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.psi_bd).ToList();
                        Pbool[41] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //o_FPr
                if (sort == Param[42])
                {
                    if (!Pbool[42])
                    {
                        alldata = alldata.OrderBy(x => x.o_FPr).ToList();
                        Pbool[42] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.o_FPr).ToList();
                        Pbool[42] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N_F0
                if (sort == Param[43])
                {
                    if (!Pbool[43])
                    {
                        alldata = alldata.OrderBy(x => x.N_FO).ToList();
                        Pbool[43] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N_FO).ToList();
                        Pbool[43] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //m_f
                if (sort == Param[44])
                {
                    if (!Pbool[44])
                    {
                        alldata = alldata.OrderBy(x => x.m_F).ToList();
                        Pbool[44] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.m_F).ToList();
                        Pbool[44] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //N_FE
                if (sort == Param[45])
                {
                    if (!Pbool[45])
                    {
                        alldata = alldata.OrderBy(x => x.N_FE).ToList();
                        Pbool[45] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.N_FE).ToList();
                        Pbool[45] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //K_FL
                if (sort == Param[46])
                {
                    if (!Pbool[46])
                    {
                        alldata = alldata.OrderBy(x => x.K_FL).ToList();
                        Pbool[46] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.K_FL).ToList();
                        Pbool[46] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //o_FP
                if (sort == Param[47])
                {
                    if (!Pbool[47])
                    {
                        alldata = alldata.OrderBy(x => x.o_FP).ToList();
                        Pbool[47] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.o_FP).ToList();
                        Pbool[47] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //R_e
                if (sort == Param[48])
                {
                    if (!Pbool[48])
                    {
                        alldata = alldata.OrderBy(x => x.R_e).ToList();
                        Pbool[48] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.R_e).ToList();
                        Pbool[48] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //d_e1
                if (sort == Param[49])
                {
                    if (!Pbool[49])
                    {
                        alldata = alldata.OrderBy(x => x.d_e1).ToList();
                        Pbool[49] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.d_e1).ToList();
                        Pbool[49] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //d_e2
                if (sort == Param[50])
                {
                    if (!Pbool[50])
                    {
                        alldata = alldata.OrderBy(x => x.d_e2).ToList();
                        Pbool[50] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.d_e2).ToList();
                        Pbool[50] = false;
                    }
                    WriteData();
                    dataGridView1.Visible = true;
                    return;
                }
                //m_nm
                if (sort == Param[51])
                {
                    if (!Pbool[51])
                    {
                        alldata = alldata.OrderBy(x => x.m_nm).ToList();
                        Pbool[51] = true;
                    }
                    else
                    {
                        alldata = alldata.OrderByDescending(x => x.m_nm).ToList();
                        Pbool[51] = false;
                    }
                    WriteData();
                    label3.Visible = true;
                    dataGridView1.Visible = true;
                    return;
                }
            }
            else
            {
                string text = "Список передач пуст!";
                ErrorManager.InfoOK(text);
            }
        }
        //найти
        private void button8_Click(object sender, EventArgs e)
        {
            if (alldata.Count != 0 && node.gear.Count != 0)
            {
                if(comboBox1.SelectedItem.ToString() == "критерий поиска")
                {
                    if (this.alldata.Count != 0)
                    {
                        ErrorManager.InfoOK("Выберите критерий поиска");
                        return;
                    }
                    else
                    {
                        label3.Visible = false;
                        dataGridView1.Visible = false;
                        ErrorManager.InfoOK("Все данные удалены!");
                    }
                    return;
                }
                if (textBox1.Text != "")
                {

                    List<AllData> calldata;
                    List<AllData> FFFdata;
                    string text = textBox1.Text.ToString().ToLower();
                    string name = comboBox1.SelectedItem.ToString();
                    //GearId
                    if(name == Param[0])
                    {
                        calldata = alldata.Where(x => x.GearId.ToString().ToLower().Contains(text)).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                    //Material
                    if (name == Param[11])
                    {
                        calldata = alldata.Where(x => x.Material.ToLower().Contains(text)).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                    //Mark
                    if (name == Param[12])
                    {
                        calldata = alldata.Where(x => x.Mark.ToLower().Contains(text)).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                    //TypeSupport
                    if (name == Param[6])
                    {
                        calldata = alldata.Where(x => x.TypeSupport.ToLower().Contains(text)).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                    //TypeLoad_p
                    if (name == Param[8])
                    {
                        calldata = alldata.Where(x => x.TypeLoad_p.ToLower().Contains(text)).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                    //TypeLoad_r
                    if (name == Param[7])
                    {
                        calldata = alldata.Where(x => x.TypeLoad_r.ToLower() == text).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        };
                        return;
                    }
                    //TypeHardening
                    if (name == Param[13])
                    {
                        calldata = alldata.Where(x => x.TypeHardening.ToLower().Contains(text)).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                    //TypeTeeth_z
                    if (name == Param[15])
                    {
                        calldata = alldata.Where(x => x.TypeTeeth_z.ToLower() == text).ToList();
                        if (calldata.Count == 0)
                        {
                            ErrorManager.InfoOK("Данные не найдены!");
                        }
                        else
                        {
                            label3.Visible = false;
                            dataGridView1.Visible = false;
                            FFFdata = this.alldata;
                            alldata = calldata;
                            WriteData();
                            this.alldata = FFFdata;
                            label3.Visible = true;
                            dataGridView1.Visible = true;
                        }
                        return;
                    }
                }
                else
                {
                    string text = "Укажите параметр поиска и введите слово или предложение в строку поиска!";
                    ErrorManager.InfoOK(text);
                }
            }
            else
            {
                string text = "Список передач пуст!";
                ErrorManager.InfoOK(text);
            }
        }
        private void FormResult_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Handle event here
            System.Windows.Forms.Application.Exit();
        }
        //редактировать параметры узла
        private void button1_Click_1(object sender, EventArgs e)
        {
            FormNode formNode = new FormNode(formMain, this.dbCondext, ref this.node);
            formNode.Show();
            this.Close();
        }
        //показать все переменные
        private void button9_Click(object sender, EventArgs e)
        {
            if(this.node.gear.Count != 0)
            {
                label3.Visible = false;
                dataGridView1.Visible = false;
                WriteData();
                label3.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                string text = "Список передач пуст!";
                ErrorManager.InfoOK(text);
            }
        }
    }
}
