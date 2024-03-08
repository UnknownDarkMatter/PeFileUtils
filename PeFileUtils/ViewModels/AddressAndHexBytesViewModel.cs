using PeFileUtils.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.ViewModels
{
    public class AddressAndHexBytesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ByteAddress _address;
        public ByteAddress Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                RaisePropertyChanged();
            }
        }

        private HexByte _hexByte1;
        public HexByte HexByte1
        {
            get
            {
                return _hexByte1;
            }
            set
            {
                _hexByte1 = value;
                RaisePropertyChanged();
            }
        }

        private HexByte _hexByte2;
        public HexByte HexByte2
        {
            get
            {
                return _hexByte2;
            }
            set
            {
                _hexByte2 = value;
                RaisePropertyChanged();
            }
        }

        private HexByte _hexByte3;
        public HexByte HexByte3
        {
            get
            {
                return _hexByte3;
            }
            set
            {
                _hexByte3 = value;
                RaisePropertyChanged();
            }
        }

        private HexByte _hexByte4;
        public HexByte HexByte4
        {
            get
            {
                return _hexByte4;
            }
            set
            {
                _hexByte4 = value;
                RaisePropertyChanged();
            }
        }

        private HexByte _hexByte5;
        public HexByte HexByte5
        {
            get
            {
                return _hexByte5;
            }
            set
            {
                _hexByte5 = value;
                RaisePropertyChanged();
            }
        }

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
