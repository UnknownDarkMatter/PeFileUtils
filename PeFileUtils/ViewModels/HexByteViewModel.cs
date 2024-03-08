using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PeFileUtils.ViewModels
{
    public class HexByteViewModel :  INotifyPropertyChanged
    {
        private string _hexByteAsString;
        public string HexByteAsString
        {
            get
            {
                return _hexByteAsString;
            }
            set
            {
                _hexByteAsString = value;
                RaisePropertyChanged();
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        

    }
}
