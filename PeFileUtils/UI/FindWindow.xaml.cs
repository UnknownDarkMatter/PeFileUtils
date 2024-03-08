using Microsoft.Extensions.DependencyInjection;
using PeFileUtils.Business.Interfaces;
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
using System.Windows.Shapes;

namespace PeFileUtils.UI
{
    /// <summary>
    /// Interaction logic for FindWindow.xaml
    /// </summary>
    public partial class FindWindow : Window
    {
        private readonly IFileService _fileService;
        private readonly IUiService _uiService;
        private int _position = 0;

        public FindWindow()
        {
            _fileService = App.Current.Services.GetService<IFileService>();
            _uiService = App.Current.Services.GetService<IUiService>();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _position = Math.Max(_position, 0);
            int nextPosition = _fileService.Find(TextToFind.Text, _position);
            if (nextPosition < 0) {
                _position = 0;
                MessageBox.Show("End of file reached without results");
                return;
            }

            _uiService.ShowFindResult(nextPosition);
            _position = nextPosition + TextToFind.Text.Length;
        }
    }
}
