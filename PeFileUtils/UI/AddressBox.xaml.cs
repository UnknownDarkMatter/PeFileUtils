using Microsoft.Extensions.DependencyInjection;
using PeFileUtils.Business.Interfaces;
using PeFileUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeFileUtils.UI
{
    /// <summary>
    /// Interaction logic for AddressBox.xaml
    /// </summary>
    public partial class AddressBox : UserControl
    {
        private ByteAddress _byteAddress;
        public ByteAddress ByteAddress
        {
            get
            {
                return _byteAddress;
            }
            set
            {
                _byteAddress = value;
            }
        }
        public static DependencyProperty ByteAddressProperty = DependencyProperty.Register("ByteAddress", typeof(ByteAddress), typeof(AddressBox));

        public AddressBox()
        {
            InitializeComponent();
        }
    }
}
