using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormComponent
{
    public class ConvertDate
    {
       static List<string> Months = new List<string>
        {
            "",
            "فروردین",
            "اردیبهشت",
            "خرداد",
            "تیر",
            "مرداد",
            "شهریور",
            "مهر",
            "آبان",
            "آذر",
            "دی",
            "بهمن",
            "اسفند",
        };
        static public string MiladiToShamsiWithMonthName (DateTime dateTime)
        {
            PersianCalendar g = new PersianCalendar();
            string Shamsi;/*string.Format("{0}/{1}/{2}", g.GetYear(dateTime), g.GetMonth(dateTime), g.GetDayOfMonth(dateTime));*/
            string year = g.GetYear(dateTime).ToString();
            string month = Months[g.GetMonth(dateTime)];
            string day = g.GetDayOfMonth(dateTime).ToString();
            Shamsi = day + month + year;
            return Shamsi;
        }

        static public string MiladiToShamsiNumberDate(DateTime dateTime)
        {
            PersianCalendar g = new PersianCalendar();
            string year = g.GetYear(dateTime).ToString();
            string month = g.GetMonth(dateTime).ToString() ;
            string day = g.GetDayOfMonth(dateTime).ToString();
           string  Shamsi = year + "/"+ month + "/" +day ;
            return Shamsi;
        }
    }
}
