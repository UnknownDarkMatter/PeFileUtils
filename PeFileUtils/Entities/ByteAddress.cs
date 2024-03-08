using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Entities
{
    public class ByteAddress
    {
        private string _address;
        public string Address
        {
            get { return _address; }   
            set { _address = value; }
        }

        public override string ToString()
        {
            return Address;
        }
    }
}
