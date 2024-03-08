using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using PeFileUtils.Business.Interfaces;
using PeFileUtils.Entities;
using PeFileUtils.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PeFileUtils.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private static int NbHexBytesInColumn = 5;
    private static int NbHexBytesShown = NbHexBytesInColumn * 15;

    private readonly IFileService _fileService;
    private readonly IHexUtils _hexUtils;
    private readonly IUiService _uiService;
    private List<HexByte> HexBytes = new List<HexByte>();
    private int _nbHexBytesSkipped = 0;
    private HexByte? ByteInfo1 = null;
    private HexByte? ByteInfo2 = null;

    public MainWindow()
    {
        _fileService = App.Current.Services.GetService<IFileService>();
        _hexUtils = App.Current.Services.GetService<IHexUtils>();
        _uiService = App.Current.Services.GetService<IUiService>();

        _uiService.RegisterFileContentDisplayer(new IUiService.FileContentDisplayerDelegate(RefreshFileContent));
        _uiService.RegisterFindResultDisplayer(new IUiService.FindResultDisplayerDelegate(ShowFindResult));
        _uiService.RegisterByteInfoShower(new IUiService.ShowByteInfoDelegate(ShowByteInfo));

        InitializeComponent();
    }

    private void mnuNew_Open(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == true)
        {
            HexBytes = new List<HexByte>();
            _nbHexBytesSkipped = 0;
            HexBytes.AddRange(_hexUtils.ToHex(_fileService.OpenFile(openFileDialog.FileName)));
            icHexBytes.ItemsSource = GroupByAddress(HexBytes.Take(NbHexBytesShown));
            scvScrollBar.SmallChange = ((double)NbHexBytesShown / (double)HexBytes.Count) * 0.1;
        }
    }

    private void mnuNew_Find(object sender, RoutedEventArgs e)
    {
        var findWindow = new FindWindow();
        findWindow.Show();
    }

    private void scvScrollBar_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
    {
        var nbHexBytesSkipped = (HexBytes.Count * e.NewValue);
        nbHexBytesSkipped = ((int)((int) nbHexBytesSkipped / (int) NbHexBytesInColumn)) * NbHexBytesInColumn;
        _nbHexBytesSkipped = (int) Math.Max(0, nbHexBytesSkipped);
        icHexBytes.ItemsSource = GroupByAddress(HexBytes.Skip(_nbHexBytesSkipped).Take(NbHexBytesShown));
    }

    private void RefreshFileContent()
    {
        HexBytes = new List<HexByte>();
        HexBytes.AddRange(_hexUtils.ToHex(_fileService.GetOpenedFileContent()));
        icHexBytes.ItemsSource = GroupByAddress(HexBytes.Skip(_nbHexBytesSkipped).Take(NbHexBytesShown));
    }

    private void ShowFindResult(int position)
    {
        var nbHexBytesSkipped = ((int)((int)position / (int)NbHexBytesInColumn)) * NbHexBytesInColumn;
        _nbHexBytesSkipped = (int)Math.Max(0, nbHexBytesSkipped);
        RefreshFileContent();
        scvScrollBar.Value = (double)_nbHexBytesSkipped / (double)HexBytes.Count;
  }

    private IEnumerable<AddressAndHexBytesViewModel> GroupByAddress(IEnumerable<HexByte> hexBytes)
    {
        var addressesAndBytes = new List<AddressAndHexBytesViewModel>();
        for(int i = 0; i < hexBytes.Count(); i = i + 5)
        {
            var byte1 = hexBytes.ElementAt(i + 0);
            var byte2 = hexBytes.Count() > i + 1 ?  hexBytes.ElementAt(i + 1) : null;
            var byte3 = hexBytes.Count() > i + 2 ? hexBytes.ElementAt(i + 2) : null;
            var byte4 = hexBytes.Count() > i + 3 ? hexBytes.ElementAt(i + 3) : null;
            var byte5 = hexBytes.Count() > i + 4 ? hexBytes.ElementAt(i + 4) : null;
            var byteAddress = new ByteAddress();
            byteAddress.Address = $"0x{_hexUtils.ToHex(byte1.PositionInStream).ToString().PadLeft(8, '0')}";
            var viewModel = new AddressAndHexBytesViewModel()
            {
                Address = byteAddress,
                HexByte1 = byte1,
                HexByte2 = byte2,
                HexByte3 = byte3,
                HexByte4 = byte4,
                HexByte5 = byte5,
            };
            addressesAndBytes.Add(viewModel);
        }
        return addressesAndBytes;
    }

    private void ShowByteInfo(ByteInfoNumber byteInfoNumber, HexByte hexByte)
    {
        switch (byteInfoNumber)
        {
            case ByteInfoNumber.First:
                {
                    lblShowByteInfo1.Content = hexByte.Address;
                    ByteInfo1 = hexByte;
                    break;
                }
            case ByteInfoNumber.Second:
                {
                    lblShowByteInfo2.Content = hexByte.Address;
                    ByteInfo2 = hexByte;
                    break;
                }
            default:
                {
                    break;
                }
        }
        lblShowByteDifference.Content = _hexUtils.AddressDifference(ByteInfo1, ByteInfo2);
    }
}
