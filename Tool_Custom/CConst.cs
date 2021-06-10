using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool_Custom
{
    public class CConst
    {
        public const int INT_VALUE_NULL = 0;
        public const int FLT_VALUE_NULL = 0;
        public const double DB_VALUE_NULL = 0;
        public const string STR_VALUE_NULL = "";
        public static DateTime DTM_VALUE_NULL = Convert_String_To_Datetime("01/01/1900", "dd/MM/yyyy");
        public const int INT_VALUE_ALL = -5;
        public const bool BL_VALUE_NULL = false;

        private static DateTime Convert_String_To_Datetime(string p_strDate, string p_strFormat)
        {
            if (p_strDate == "")
                return CConst.DTM_VALUE_NULL;

            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(p_strDate, p_strFormat, provider);
        }
    }
}
