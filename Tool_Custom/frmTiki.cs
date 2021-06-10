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

namespace Tool_Custom
{
    public partial class frmTiki : Form
    {
        HttpClient m_httpClient;

        public frmTiki()
        {
            InitializeComponent();
            m_httpClient = new HttpClient();
            txtLink.Text = "https://tiki.vn/thiet-bi-kts-phu-kien-so/c1815";

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            string v_strHtml_Source = CrawlDataFromURL(txtLink.Text.Trim());
            string v_strPattern = @"<a class=""product-item(.*)?</a>";
            string v_strPattern2 = @"<a class=""product-item"" data-view-index=""\d+""(.*?)</a>";
            var v_arrProduct = Regex.Matches(v_strHtml_Source, v_strPattern2);

            StringBuilder v_sbResult = new StringBuilder();

            foreach (var item in v_arrProduct)
            {
                string v_strName = Regex.Match(item.ToString(), @"<div class=""name(.*?)</span></div>").Value.Replace("<div>", "");
                //v_sbResult.AppendLine(item.ToString() + "\n");
                string v_strName_Key = Regex.Replace(v_strName, @"(<div (.*?)>)|(<span>)|(</span></div>)", "");
                v_sbResult.AppendLine(v_strName_Key + "\n");
            }


            rtbData.Text = v_sbResult.ToString();


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
    }
}
