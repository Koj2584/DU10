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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fName = "", obsah = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            if(file.ShowDialog() == DialogResult.OK)
            {
                ListBox lb = new ListBox();
                lb.Width = 200;
                lb.Height = 130;
                lb.Location = new Point(20, 20);
                lb.Enabled = true;
                lb.Visible = true;
                this.Controls.Add(lb);
                fName = file.FileName;
                StreamReader ctenar = new StreamReader(fName, Encoding.GetEncoding("windows-1250"));
                while (!ctenar.EndOfStream)
                    lb.Items.Add(ctenar.ReadLine());
                ctenar.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader ctenar = new StreamReader(fName, Encoding.GetEncoding("windows-1250"));
            obsah = ctenar.ReadToEnd().ToString();
            ctenar.Close();
            StreamWriter zapis = new StreamWriter(fName, false, Encoding.GetEncoding("windows-1250"));
            if (comboBox1.SelectedItem.ToString() == "Velká na malá")
            {
                zapis.Write(obsah.ToLower());
            } else if(comboBox1.SelectedItem.ToString() == "Malá na velká")
            {
                zapis.Write(obsah.ToUpper());
            } else
                MessageBox.Show("Musíte něco vybrat");
            zapis.Close();
            ctenar = new StreamReader(fName, Encoding.GetEncoding("windows-1250"));
            ListBox ld = new ListBox();
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == Type.GetType("ListBox"))
                    ld = (ListBox)c;
            }
            ld.Items.Clear();
            while (!ctenar.EndOfStream)
                ld.Items.Add(ctenar.ReadLine());
            ctenar.Close();
        }


    }
}
