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
        int count = 0;
        public frmTiki()
        {
            InitializeComponent();
            m_httpClient = new HttpClient();
            m_arrProduct = new List<CProduct>();
            txtLink.Text = "https://tiki.vn/sua-cho-be-duoi-24-thang/c2601?src=c.2601.hamburger_menu_fly_r";
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            Crawl_DataAsync();
        }

        private void Crawl_DataAsync()
        {
            int page = 1;
            //m_arrProduct = new List<CProduct>();
            for (int i = page; i < 2; i++)
            {
                string v_strHtml_Source = CrawlDataFromURL(txtLink.Text.Trim(), i);
                string v_strPattern2 = @"<a class=""product-item"" data-view-index=""\d+""(.*?)</a>";
                var v_arrProduct = Regex.Matches(v_strHtml_Source, v_strPattern2);

                StringBuilder v_sbResult = new StringBuilder();

                Thread t = new Thread(() =>
                {

                    foreach (var item in v_arrProduct)
                    {
                        CProduct v_objProduct = new CProduct();

                        // Get Link
                        string v_strLink = "https://tiki";
                        GroupCollection v_groupLink_Regex = Regex.Match(item.ToString(), @"href=""(.*?)""").Groups;
                        v_strLink += v_groupLink_Regex[1];
                        v_objProduct.Link = v_strLink;

                        // Get Image
                        //<img src="(.*?)" alt="(.*?)"\/>
                        string v_strImage = "";
                        GroupCollection v_groupImage_Regex = Regex.Match(item.ToString(), @"<img src=""(.*?)"" alt=""(.*?)""\/>").Groups;
                        v_strImage += v_groupImage_Regex[1];
                        //v_objProduct.Image = v_strImage;

                        v_objProduct.Image = "F:/Code_Team_2021/Tool_Custom/Tool_Custom/Images/62e166121af858dcea5156c0808250ac.jpg";

                        // Get Name SKU
                        string v_strName_Regex = Regex.Match(item.ToString(), @"<div class=""name(.*?)</span></div>").Value.Replace("<div>", "");
                        string v_strName = Regex.Replace(v_strName_Regex, @"(<div (.*?)>)|(<span>)|(</span></div>)", "");
                        v_objProduct.Name = v_strName;

                        // Get Price and Discount SKU
                        GroupCollection v_greoupPrice = Regex.Match(item.ToString(), @"<div class=""price-discount""><div class=""price-discount__price"">(.*?)<\/div><div class=""price-discount__discount"">(.*?)<\/div><\/div>").Groups;

                        string v_strPrice_Text = v_greoupPrice[1].Value;
                        string v_strDiscount_Text = Regex.Match(v_greoupPrice[2].Value, @"[0-9]+").Value;

                        v_objProduct.Price_Text = v_strPrice_Text;
                        v_objProduct.Discount_Text = "-" + v_strDiscount_Text + "%";

                        v_sbResult.AppendLine(v_strName + "\n" + "Price: " + v_strPrice_Text.ToString() + "\n Discount: " + v_strDiscount_Text);

                        m_arrProduct.Add(v_objProduct);
                        count++;
                        lblValue.Text = count.ToString();
                        //Thread.Sleep(TimeSpan.FromSeconds(1));
                        //dataGridView1.Rows.Add(v_objProduct);
                    }

                    dataGridView1.Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = m_arrProduct;

                        Format_GridView();
                    }));

                });
                t.IsBackground = true;
                t.Start();

                //Thread.Sleep(1000);
            }

        }

        private string CrawlDataFromURL(string p_strUrl, int page)
        {
            string v_strHtml = "";
            p_strUrl += "&page=" + page;

            v_strHtml = m_httpClient.GetStringAsync(p_strUrl).Result;

            return v_strHtml;
        }

        private void frmTiki_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Image")
            {
                // Your code would go here - below is just the code I used to test
                //DataGridViewImageColumn ic = new DataGridViewImageColumn();
                //e.CellStyle = new DataGridViewCellStyle();

                //e.Value = (Bitmap)System.Drawing.Image.FromFile(@"F:\Code_Team_2021\Tool_Custom\Tool_Custom\Images\62e166121af858dcea5156c0808250ac.jpg");

            }
        }

        public void Format_GridView()
        {
            if (dataGridView1.Columns["Name"] != null)
            {
                dataGridView1.Columns["Name"].HeaderText = "Name";
                dataGridView1.Columns["Name"].Width = 30 * dataGridView1.Width / 100;
            }

            if (dataGridView1.Columns["Price"] != null)
            {
                dataGridView1.Columns["Price"].HeaderText = "Price";
                dataGridView1.Columns["Price"].Width = 30 * dataGridView1.Width / 100;
                dataGridView1.Columns["Price"].Visible = false; // ẩn
            }

            if (dataGridView1.Columns["Price_Text"] != null)
            {
                dataGridView1.Columns["Price_Text"].HeaderText = "Price Text";
                dataGridView1.Columns["Price_Text"].Width = 30 * dataGridView1.Width / 100;
            }

            if (dataGridView1.Columns["Discount"] != null)
            {
                dataGridView1.Columns["Discount"].HeaderText = "Discount";
                dataGridView1.Columns["Discount"].Width = 10 * dataGridView1.Width / 100;
                dataGridView1.Columns["Discount"].Visible = false; // ẩn
            }

            if (dataGridView1.Columns["Discount_Text"] != null)
            {
                dataGridView1.Columns["Discount_Text"].HeaderText = "Discount Text";
                dataGridView1.Columns["Discount_Text"].Width = 30 * dataGridView1.Width / 100;
            }

            if (dataGridView1.Columns["Image"] != null)
            {
                dataGridView1.Columns["Image"].HeaderText = "Image";
                dataGridView1.Columns["Image"].Width = 30 * dataGridView1.Width / 100;
            }

            if (dataGridView1.Columns["Link"] != null)
            {
                dataGridView1.Columns["Link"].HeaderText = "Link";
                dataGridView1.Columns["Link"].Width = 30 * dataGridView1.Width / 100;

            }
            //m_strQty_Sold

            if (dataGridView1.Columns["Qty_Sold"] != null)
            {
                dataGridView1.Columns["Qty_Sold"].HeaderText = "Qty Sold";
                dataGridView1.Columns["Qty_Sold"].Width = 30 * dataGridView1.Width / 100;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //    foreach (DataGridViewRow r in dataGridView1.Rows)
            //    {
            //        if (System.Uri.IsWellFormedUriString(r.Cells["Link"].Value.ToString(), UriKind.Absolute))
            //        {
            //            r.Cells["Link"] = new DataGridViewLinkCell();
            //            // Note that if I want a different link colour for example it must go here
            //            DataGridViewLinkCell c = r.Cells["Link"] as DataGridViewLinkCell;
            //            c.LinkColor = Color.Green;
            //        }
            //    }
        }
    }
}
