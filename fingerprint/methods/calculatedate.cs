using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fingerprint.methods
{
    static class calculatedate
    {
    public  static void  calulatechosendates(DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2, List<string> weekends)
        {
            for (DateTime date = dateTimePicker1.Value.Date; date < dateTimePicker2.Value.Date; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    string[] parts = date.ToShortDateString().Split('/');
                    string finisheddate = $"{parts[2]}-{parts[1]}-{parts[0]}";
                    weekends.Add(finisheddate);
                }
            }
        }
    }
}
