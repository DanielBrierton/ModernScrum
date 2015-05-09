using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernScrum
{
    class ListItem
    {
        private string _number;

        public string Number
        {
            get
            {
                return _number;
            }
        }

        private int _index;

        public int Index
        {
            get
            {
                return _index;
            }
        }

        public ListItem(int index, string number) {
            this._index = index;
            this._number = number;
        }


    }
}
