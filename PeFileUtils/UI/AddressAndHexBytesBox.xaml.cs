using PeFileUtils.ViewModels;
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
    /// Interaction logic for AddressAndHexBytesBox.xaml
    /// </summary>
    public partial class AddressAndHexBytesBox : UserControl
    {
        private AddressAndHexBytesViewModel _addressAndHexBytesViewModel;
        public AddressAndHexBytesViewModel AddressAndHexBytesViewModel
        {
            get
            {
                return _addressAndHexBytesViewModel;
            }
            set
            {
                _addressAndHexBytesViewModel = value;
            }
        }

        public static DependencyProperty AddressAndHexBytesViewModelProperty = DependencyProperty.Register("AddressAndHexBytesViewModel", typeof(AddressAndHexBytesViewModel), typeof(AddressAndHexBytesBox));

        public AddressAndHexBytesBox()
        {
            InitializeComponent();
        }
    }
}
