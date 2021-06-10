using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_Custom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void Get_From(int p_iKey_Shop)
        {
            switch (p_iKey_Shop)
            {
                case (int)EShop.Tiki:
                    frmTiki frm = new frmTiki();
                    frm.Show();
                    break;
                case (int)EShop.Shoppe:
                    frmShoppe frm2 = new frmShoppe();
                    frm2.Show();
                    break;
                case (int)EShop.Lazada:
                    frmShoppe frm3 = new frmShoppe();
                    frm3.Show();
                    break;
                default:
                    break;
            }
        }

        private void btnShoppe_Click(object sender, EventArgs e)
        {
            Get_From((int)EShop.Shoppe);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Get_From((int)EShop.Lazada);
        }

        private void btnDuy_Click(object sender, EventArgs e)
        {
            Get_From((int)EShop.Tiki);
        }
    }
}
