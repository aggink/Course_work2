using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Базы_данных.Курсовая_работа.Model;

namespace Базы_данных.Курсовая_работа.Entity
{
    public class DataBaseContext
    {
        public List<Table1> table1 { get; set; }
        public List<Table2> table2 { get; set; }
        public List<Table3> table3 { get; set; }
        public List<Table4> table4 { get; set; }

        public bool Error { get; }
        public List<string> TextError { get; }

        private async void Read()
        {
            //имя файлос с таблицами данных
            string file1 = ".\\DataTables\\Table1R.xml";
            string file2 = ".\\DataTables\\Table2R.xml";
            string file3 = ".\\DataTables\\Table3R.xml";
            string file4 = ".\\DataTables\\Table4R.xml";

            await Task.Run(() => ReadFile1(file1));
            await Task.Run(() => ReadFile2(file2));
            await Task.Run(() => ReadFile3(file3));
            await Task.Run(() => ReadFile4(file4));
        }
        private void ReadFile1(string file1)
        {
            List<Table1> table = new List<Table1>();

            XmlDocument xDoc1 = new XmlDocument();
            xDoc1.Load(file1);
            //получаем корневой элемент
            XmlElement xRoot1 = xDoc1.DocumentElement;
            //обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot1)
            {
                Table1 record = new Table1();

                //обходим все дочернии узлы элемента record
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    //если узел - ...
                    if (childnode.Name == "id")
                    {
                        record.Id = int.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "material")
                    {
                        record.Material = childnode.InnerText;
                    }
                    if (childnode.Name == "mark")
                    {
                        record.Mark = childnode.InnerText;
                    }
                    if (childnode.Name == "TypeHardening")
                    {
                        record.TypeHardening = childnode.InnerText;
                    }
                    if (childnode.Name == "HBmin")
                    {
                        record.HBmin = decimal.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "HBmax")
                    {
                        record.HBmax = decimal.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "TypeLoad")
                    {
                        record.TypeLoad = childnode.InnerText;
                    }
                    if (childnode.Name == "oFP")
                    {
                        record.o_FP = decimal.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "N_FO")
                    {
                        record.N_FO = decimal.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "O_HP")
                    {
                        record.o_HP = decimal.Parse(childnode.InnerText);
                    }
                    if (childnode.Name == "N_HO")
                    {
                        record.N_HO = decimal.Parse(childnode.InnerText);
                    }
                }
                table.Add(record);
            }
            this.table1 = table;
        }
        private void ReadFile2(string file)
        {
            List<Table2> table = new List<Table2>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);

            //получаем корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            //обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                Table2 record = new Table2();

                //обходим все дочернии узлы элемента record
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "id")
                    {
                        record.Id = int.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "TypeSupport")
                    {
                        record.TypeSupport = childnode.InnerText;
                    }
                    if(childnode.Name == "TypeTeeth")
                    {
                        record.TypeTeeth = childnode.InnerText;
                    }
                    if(childnode.Name == "HB_min")
                    {
                        decimal number;
                        bool flag = decimal.TryParse(childnode.InnerText.Replace(".", ","), out number);
                        if(flag == false)
                        {
                            record.HB_min = null;
                        }
                        else
                        {
                            record.HB_min = number;
                        }
                    }
                    if (childnode.Name == "HB_max")
                    {
                        decimal number;
                        bool flag = decimal.TryParse(childnode.InnerText.Replace(".", ","), out number);
                        if (flag == false)
                        {
                            record.HB_max = null;
                        }
                        else
                        {
                            record.HB_max = number;
                        }
                    }
                    if(childnode.Name == "L_FB")
                    {
                        record.L_FB = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if (childnode.Name == "K_HB")
                    {
                        decimal number;
                        bool flag = decimal.TryParse(childnode.InnerText.Replace(".", ","), out number);
                        if (flag == false)
                        {
                            record.K_HB = null;
                        }
                        else
                        {
                            record.K_HB = number;
                        }
                    }
                    if (childnode.Name == "K_FB")
                    {
                        decimal number;
                        bool flag = decimal.TryParse(childnode.InnerText.Replace(".", ","), out number);
                        if (flag == false)
                        {
                            record.K_FB = null;
                        }
                        else
                        {
                            record.K_FB = number;
                        }
                    }
                }
                table.Add(record);
            }
            this.table2 = table;
        }
        private void ReadFile3(string file)
        {
            List<Table3> table = new List<Table3>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);

            //получаем корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            //обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                Table3 record = new Table3();

                //обходим все дочернии узлы элемента record
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if(childnode.Name == "id")
                    {
                        record.Id = int.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "z_v")
                    {
                        record.z_v = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "x_t1")
                    {
                        record.x_t1 = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "Y_F1")
                    {
                        decimal number;
                        bool flag = decimal.TryParse(childnode.InnerText.Replace(".", ","), out number);
                        if (flag == false)
                        {
                            record.Y_F1 = null;
                        }
                        else
                        {
                            record.Y_F1 = number;
                        }
                    }
                }
                table.Add(record);
            }
             this.table3 = table;
        }
        private void ReadFile4(string file)
        {
            List<Table4> table = new List<Table4>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(file);

            //получаем корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            //обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                Table4 record = new Table4();

                //обходим все дочернии узлы элемента record
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if(childnode.Name == "id")
                    {
                        record.Id = int.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "u_min")
                    {
                        record.u_min = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "u_max")
                    {
                        record.u_max = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "B_min")
                    {
                        record.B_min = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "B_max")
                    {
                        record.B_max = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                    if(childnode.Name == "x_t1")
                    {
                        record.x_t1 = decimal.Parse(childnode.InnerText.Replace(".", ","));
                    }
                }
                table.Add(record);
            }
            this.table4 = table;
        }
        
        public DataBaseContext()
        {
            Read();
        }
    }
}
