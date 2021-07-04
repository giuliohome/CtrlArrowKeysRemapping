using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiulioMVVM;

namespace WpfHorizPage
{
    class MainVM : ViewModelBase
    {
        private Record[] records = Record.ProduceRandomList(20).ToArray();

        public Record[] Records
        {
            get { return records; }
            set { records = value; OnPropertyChanged(); }
        }

    }
}
