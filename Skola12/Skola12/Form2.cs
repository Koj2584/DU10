using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Skola12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tabulka = new DataTable();
            StreamReader ctenar = new StreamReader("knihy.txt", Encoding.GetEncoding("windows-1250"));
            string prvni = ctenar.ReadLine();
            foreach (string data in prvni.Split(';')) 
                tabulka.Columns.Add(data);
            while (!ctenar.EndOfStream)
            {
                tabulka.Rows.Add(ctenar.ReadLine().Split(';'));
            }
            ctenar.Close();
            StreamWriter zapis1 = new StreamWriter("knihy1.txt", true, Encoding.GetEncoding("windows-1250"));
            StreamWriter zapis2 = new StreamWriter("knihy2.txt", true, Encoding.GetEncoding("windows-1250"));

            zapis1.WriteLine(prvni);
            zapis2.WriteLine(prvni);
            foreach (DataRow row in tabulka.Rows)
            {
                if (int.Parse(row.ItemArray[row.ItemArray.Length-1].ToString()) > 1950)
                    zapis1.WriteLine(string.Join(";", row.ItemArray));
                else
                    zapis2.WriteLine(string.Join(";", row.ItemArray));
            }
            zapis1.Close();
            zapis2.Close();
            dataGridView1.DataSource = tabulka;
        }
    }
}
