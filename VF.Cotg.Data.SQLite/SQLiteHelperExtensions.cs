using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data.SQLite
{
    static class SQLiteHelperExtensions
    {

        public static string DateTimeSQLite(this DateTime dateTime)
        {
            string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
            return string.Format(dateTimeFormat, 
                dateTime.Year, 
                dateTime.Month, 
                dateTime.Day, 
                dateTime.Hour, 
                dateTime.Minute, 
                dateTime.Second, 
                dateTime.Millisecond);
        }

    }
}
