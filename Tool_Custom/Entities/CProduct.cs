using System;
using System.Collections.Generic;
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
        }


        public string Name { get => m_strName; set => m_strName = value; }
        public string Link { get => m_strLink; set => m_strLink = value; }
        public string Image { get => m_strImage; set => m_strImage = value; }
        public double Price { get => m_dblPrice; set => m_dblPrice = value; }


    }
}
