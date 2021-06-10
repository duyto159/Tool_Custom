using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool_Custom.Entities;
namespace Tool_Custom
{
    public partial class frmTiki : Form
    {
        HttpClient m_httpClient;
        List<CProduct> m_arrProduct;

        public frmTiki()
        {
            InitializeComponent();
            m_httpClient = new HttpClient();
            m_arrProduct = new List<CProduct>();
            txtLink.Text = "https://tiki.vn/thiet-bi-kts-phu-kien-so/c1815";

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            m_arrProduct = new List<CProduct>();

            string v_strHtml_Source = CrawlDataFromURL(txtLink.Text.Trim());
            //string v_strPattern = @"<a class=""product-item(.*)?</a>";
            string v_strPattern2 = @"<a class=""product-item"" data-view-index=""\d+""(.*?)</a>";
            var v_arrProduct = Regex.Matches(v_strHtml_Source, v_strPattern2);

            StringBuilder v_sbResult = new StringBuilder();

            foreach (var item in v_arrProduct)
            {
                string v_strName = Regex.Match(item.ToString(), @"<div class=""name(.*?)</span></div>").Value.Replace("<div>", "");
                //v_sbResult.AppendLine(item.ToString() + "\n");
                string v_strName_Key = Regex.Replace(v_strName, @"(<div (.*?)>)|(<span>)|(</span></div>)", "");
                v_sbResult.AppendLine(v_strName_Key + "\n");

                m_arrProduct.Add(new CProduct { Name = v_strName_Key});
            }


            rtbData.Text = v_sbResult.ToString();


            DataGridViewImageColumn img = new DataGridViewImageColumn();
            Image image = Image.FromFile(@"F:\Code_Team_2021\Tool_Custom\Tool_Custom\Images\62e166121af858dcea5156c0808250ac.jpg");
            img.Image = image;
            dataGridView1.Columns.Add(img);
            img.HeaderText = "Image";
            img.Name = "img";

            dataGridView1.DataSource = m_arrProduct;

        }

        private string CrawlDataFromURL(string p_strUrl)
        {
            string v_strHtml = "";

            v_strHtml = m_httpClient.GetStringAsync(p_strUrl).Result;

            return v_strHtml;
        }

        private void frmTiki_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    btnGet_Click(sender, e);
            //    //Thread.Sleep(5000);
            //}
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Image")
            {
                // Your code would go here - below is just the code I used to test
                e.Value = (Bitmap)System.Drawing.Image.FromFile(@"F:\Code_Team_2021\Tool_Custom\Tool_Custom\Images\62e166121af858dcea5156c0808250ac.jpg");
                //dataGridView1.Rows[0].Cells[2].Value = Properties.Resources.image01;
            }
        }
    }
}
