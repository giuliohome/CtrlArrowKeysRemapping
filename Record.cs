using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHorizPage
{
    public class Record
    {
        public string Field01 { get; set; }
        public string Field02 { get; set; }
        public string Field03 { get; set; }
        public string Field04 { get; set; }
        public string Field05 { get; set; }
        public string Field06 { get; set; }
        public string Field07 { get; set; }
        public string Field08 { get; set; }
        public string Field09 { get; set; }
        public string Field10 { get; set; }
        public string Field11 { get; set; }
        public string Field12 { get; set; }

        public static Record ProduceRandomRec()
        {
            var rec = new Record();
            rec.Field01 = Utility.RandomString(11);
            rec.Field02 = Utility.RandomString(12);
            rec.Field03 = Utility.RandomString(13);
            rec.Field04 = Utility.RandomString(14);
            rec.Field05 = Utility.RandomString(15);
            rec.Field06 = Utility.RandomString(16);
            rec.Field07 = Utility.RandomString(17);
            rec.Field08 = Utility.RandomString(18);
            rec.Field09 = Utility.RandomString(19);
            rec.Field10 = Utility.RandomString(20);
            rec.Field11 = Utility.RandomString(21);
            rec.Field12 = Utility.RandomString(22);
            return rec;
        }
        public static List<Record> ProduceRandomList(int n)
        {
            var list = new List<Record>();
            for (int i = 0; i < n; i++)
            {
                list.Add(ProduceRandomRec());
            }
            return list;
        }
    }
}
