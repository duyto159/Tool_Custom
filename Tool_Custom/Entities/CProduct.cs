using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Custom.Entities
{
    public class CProduct
    {
        private string m_strName;
        private string m_strLink;
        private string m_strImage;
        private double m_dblPrice;
        private string m_strPrice_Text;
        private double m_dblDiscount;
        private string m_strDiscount_Text;
        private string m_strQty_Sold;

        public CProduct()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_strName = CConst.STR_VALUE_NULL;
            m_strLink = CConst.STR_VALUE_NULL;
            m_strImage = CConst.STR_VALUE_NULL;
            m_dblPrice = CConst.DB_VALUE_NULL;
            m_strPrice_Text = CConst.STR_VALUE_NULL;
            m_dblDiscount = CConst.DB_VALUE_NULL;
            m_strDiscount_Text = CConst.STR_VALUE_NULL;
            m_strQty_Sold = CConst.STR_VALUE_NULL;

        }

        public string Name { get => m_strName; set => m_strName = value; }

        public string Link { get => m_strLink; set => m_strLink = value; }

        public string Image { get => m_strImage; set => m_strImage = value; }

        public double Price { get => m_dblPrice; set => m_dblPrice = value; }

        public string Price_Text { get => m_strPrice_Text; set => m_strPrice_Text = value; }

        public double Discount { get => m_dblDiscount; set => m_dblDiscount = value; }

        public string Discount_Text { get => m_strDiscount_Text; set => m_strDiscount_Text = value; }

        public string Qty_Sold { get => m_strQty_Sold; set => m_strQty_Sold = value; }

        [NotMapped]
        public Image Picture
        {
            get
            {
                if (!string.IsNullOrEmpty(Image))
                {
                    if (File.Exists(Image))
                        return System.Drawing.Image.FromFile(Image);
                }
                return null;
            }
        }
    }
}
