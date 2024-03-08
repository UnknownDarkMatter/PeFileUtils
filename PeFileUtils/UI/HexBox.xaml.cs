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

namespace PeFileUtils.UI;

/// <summary>
/// Interaction logic for HexBox.xaml
/// </summary>
public partial class HexBox : UserControl
{
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
        }
    }
    public static DependencyProperty HexByteProperty = DependencyProperty.Register("HexByte", typeof(HexByte), typeof(HexBox));

    public HexBox()
    {
        InitializeComponent();

        _uiService = App.Current.Services.GetService<IUiService>();
    }

    private void Edit_OnClick(object sender, RoutedEventArgs e)
    {
        MenuItem menu = sender as MenuItem;
        var hexByte = (HexByte)((TextBox)menu.CommandParameter).Tag;
        var window = new HexByteEdit();
        window.HexByte = hexByte;
        window.Show();
    }

    private void ShowByteInfoNumber1_OnClick(object sender, RoutedEventArgs e)
    {
        MenuItem menu = sender as MenuItem;
        var hexByte = (HexByte)((TextBox)menu.CommandParameter).Tag;
        _uiService.ShowByteInfo(ByteInfoNumber.First, hexByte);
    }

    private void ShowByteInfoNumber2_OnClick(object sender, RoutedEventArgs e)
    {
        MenuItem menu = sender as MenuItem;
        var hexByte = (HexByte)((TextBox)menu.CommandParameter).Tag;
        _uiService.ShowByteInfo(ByteInfoNumber.Second, hexByte);
    }

    private void txbHexByte_MouseDown(object sender, MouseButtonEventArgs e)
    {

    }
}
