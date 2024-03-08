using Microsoft.Extensions.DependencyInjection;
using PeFileUtils.Business.Interfaces;
using PeFileUtils.Entities;
using PeFileUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PeFileUtils.UI
{
    /// <summary>
    /// Interaction logic for HexByteEdit.xaml
    /// </summary>
    public partial class HexByteEdit : Window
    {
        private readonly IFileService _fileService;
        private readonly IHexUtils _hexUtils;
        private readonly IUiService _uiService;

        private HexByte _hexByte;

        public HexByte HexByte
        {
            get
            {
                return _hexByte;
            }
            set
            {
                _hexByte = value;
                HexByteViewModel.HexByteAsString = value.ToString();
            }
        }


        public HexByteViewModel HexByteViewModel { get; set; }

        public HexByteEdit()
        {
            _fileService = App.Current.Services.GetService<IFileService>();
            _hexUtils = App.Current.Services.GetService<IHexUtils>();
            _uiService = App.Current.Services.GetService<IUiService>();

            HexByteViewModel = new HexByteViewModel();
            InitializeComponent();
            DataContext = HexByteViewModel;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            var hexByte = _hexUtils.ToHex(HexByteViewModel.HexByteAsString, _hexByte.PositionInStream);
            _fileService.SetByte(hexByte.Byte, hexByte.PositionInStream);
            _uiService.RefreshFileContent();
            this.Close();
        }
    }
}
