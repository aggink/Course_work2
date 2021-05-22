using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Базы_данных.Курсовая_работа.Entity;
using Базы_данных.Курсовая_работа.Manager;
using Базы_данных.Курсовая_работа.Model;

namespace Базы_данных.Курсовая_работа
{
    public partial class FormMain : Form
    {
        private DataBaseContext dbContext;
        private string NameFile = ".\\DataTables\\DataTable.xml";

        public void UpdateRecordFile()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("не задано");
            comboBox1.SelectedIndex = 0;

            XDocument xDoc = XDocument.Load(NameFile);
            XElement root = xDoc.Element("data");
            foreach (var node in root.Elements("node").ToList())
            {
                comboBox1.Items.Add(node.Attribute("id").Value);
            }
        }
        private void formMain()
        {
            UpdateRecordFile();
        }
        public FormMain(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            formMain();
        }
        public FormMain()
        {
            this.dbContext = new DataBaseContext();
            InitializeComponent();
            formMain();
        }
        //запустить
        private void button2_Click(object sender, EventArgs e)
        {
            Node node = new Node();
            FormNode formNode = new FormNode(this, dbContext, ref node);
            formNode.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = "Вы действительно хотите выйти?";
            string error = "Завершить работу?";
            DialogResult result = ErrorManager.InfoYesNo(text, error);
            if(DialogResult.Yes == result)
            {
                Application.Exit();
            }
        }
        //открыть созданный ранее файл
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != 0)
            {
                XDocument xDoc = XDocument.Load(NameFile);
                XElement root = xDoc.Element("data");
                XElement n = root.Elements("node").ToList().FirstOrDefault(x => x.Attribute("id").Value.Contains(comboBox1.SelectedItem.ToString()));

                //распарсить документ и передать в FormNode
                Node node = new Node();
                node.save = true;
                node.NodeId = Guid.Parse(n.Attribute("id").Value);

                foreach(var g in n.Elements("Gear").ToList())
                {
                    Gear gear = new Gear();
                    gear.GearId = Guid.Parse(g.Attribute("GearId").Value);

                    gear.N = Decimal.Parse(g.Element("N").Value);
                    gear.n = Decimal.Parse(g.Element("n").Value);
                    gear.n1 = Decimal.Parse(g.Element("n1").Value);
                    gear.t_r = decimal.Parse(g.Element("t_r").Value);
                    gear.TypeGear = g.Element("TypeGear").Value;
                    gear.TypeLoad_p = g.Element("TypeLoad_p").Value;
                    if (gear.TypeLoad_p.Contains(StaticData.TypeLoad_p[0]))
                    {
                        gear.N_FE = null;
                        gear.N_HE = null;
                    }
                    else
                    {
                        gear.N_FE = Decimal.Parse(g.Element("N_FE").Value);
                        gear.N_HE = Decimal.Parse(g.Element("N_HE").Value);
                    }
                    gear.TypeLoad_r = g.Element("TypeLoad_r").Value;
                    gear.TypeSupport = g.Element("TypeSupport").Value;
                    gear.save = true;

                    XElement d = g.Element("Detail");
                    gear.detail = new Detail();
                    gear.detail.gearId = Guid.Parse(d.Element("DGearId").Value);
                    gear.detail.z1 = int.Parse(d.Element("z1").Value);
                    gear.detail.delta1 = Decimal.Parse(d.Element("delta1").Value);
                    gear.detail.wheelId = Guid.Parse(d.Element("wheelId").Value);
                    gear.detail.z2 = int.Parse(d.Element("z2").Value);
                    gear.detail.delta2 = Decimal.Parse(d.Element("delta2").Value);

                    gear.detail.MaterialId = int.Parse(d.Element("MaterialId").Value);
                    gear.detail.Material = d.Element("Material").Value;
                    gear.detail.Mark = d.Element("Mark").Value;
                    gear.detail.TypeHardening = d.Element("TypeHardening").Value;
                    gear.detail.TypeTeeth = d.Element("TypeTeeth").Value;
                    gear.detail.TypeTeeth_z = d.Element("TypeTeeth_z").Value;
                    gear.detail.beta_m = Decimal.Parse(d.Element("beta_m").Value);
                    gear.detail.save = true;

                    node.gear.Add(gear);
                }

                FormNode formNode = new FormNode(this, dbContext, ref node);
                this.Hide();
                formNode.Show();
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    string text = "Просмотрите список доступных файлов!";
                    ErrorManager.InfoOK(text);
                }
                else
                {
                    string text = "У вас нету сохраненных файлов!";
                    ErrorManager.InfoOK(text);
                }
            }
        }
        //удалить созданный ранее файл
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                XDocument xDoc = XDocument.Load(NameFile);
                XElement root = xDoc.Element("data");
                var node = root.Elements("node").ToList().Where(x => x.Attribute("id").Value.Contains(comboBox1.SelectedItem.ToString()));
                node.Remove();

                comboBox1.Items.Clear();
                comboBox1.Items.Add("не задано");
                foreach (var n in root.Elements("node").ToList())
                {
                    comboBox1.Items.Add(n.Attribute("id").Value);
                }
                comboBox1.SelectedIndex = 0;
                xDoc.Save(NameFile);
            }
            else
            {
                string text = "У вас нету сохраненных файлов!";
                ErrorManager.InfoOK(text);
            }
        }
    }
}
