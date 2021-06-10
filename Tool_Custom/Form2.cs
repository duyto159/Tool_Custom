using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_Custom
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Read File
        private void button1_Click(object sender, EventArgs e)
        {
            //string v_strFile_Name = "test1.txt";
            //StreamReader v_objStream = new StreamReader(v_strFile_Name, true);
            //richTextBox1.Clear();
            //richTextBox1.Text = v_objStream.ReadToEnd().ToString();
            //v_objStream.Close();

            string v_strPath = txtLink.Text;
            StreamReader v_objStream = new StreamReader(v_strPath, true);
            richTextBox1.Clear();
            richTextBox1.Text = v_objStream.ReadToEnd().ToString();
            v_objStream.Close();
        }

        // Write File
        private void button2_Click(object sender, EventArgs e)
        {
            //string v_strFile_Name = "test1.txt";
            //StreamWriter v_objStream = new StreamWriter(v_strFile_Name, true);
            //v_objStream.WriteLine(richTextBox2.Text);
            //v_objStream.Close();

            string v_strPath = txtLink.Text;

            StreamWriter v_objStream = new StreamWriter(v_strPath, true);
            v_objStream.WriteLine(richTextBox2.Text);
            v_objStream.Close();

        }

        // Choose File
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog v_objOpenFileDialog = new OpenFileDialog();
            v_objOpenFileDialog.Filter = "|*.txt"; // lấy đuôi txt;
            if(v_objOpenFileDialog.ShowDialog() == DialogResult.OK) // bật cửa sổ chọn file
            {
                txtLink.Text = v_objOpenFileDialog.FileName;
                StreamReader v_objReader = new StreamReader(v_objOpenFileDialog.FileName);
                richTextBox1.Text = v_objReader.ReadToEnd();
                v_objReader.Close();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog v_objSaveFileDialog = new SaveFileDialog();
            v_objSaveFileDialog.Filter = "|*.txt"; // lưu dưới dạng txt
            v_objSaveFileDialog.RestoreDirectory = true; // cho phép ghi đè file;
            if(v_objSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter v_objWriter = new StreamWriter(v_objSaveFileDialog.FileName, true);
                v_objWriter.WriteLine(richTextBox2.Text);
                v_objWriter.Close();
            }
        }
    }
}
