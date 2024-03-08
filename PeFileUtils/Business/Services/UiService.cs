using PeFileUtils.Business.Interfaces;
using PeFileUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Business.Services
{
    public class UiService : IUiService
    {
        private List<IUiService.FileContentDisplayerDelegate> _fileContentDisplayerDelegates = new List<IUiService.FileContentDisplayerDelegate>();
        private List<IUiService.FindResultDisplayerDelegate> _findResultDisplayerDelegates = new List<IUiService.FindResultDisplayerDelegate>();
        private List<IUiService.ShowByteInfoDelegate> _showByteInfoDelegates = new List<IUiService.ShowByteInfoDelegate>();

        public void RegisterFileContentDisplayer(IUiService.FileContentDisplayerDelegate fileContentDisplayerDelegate)
        {
            _fileContentDisplayerDelegates.Add(fileContentDisplayerDelegate);
        }

        public void RefreshFileContent()
        {
            foreach(var displayer in _fileContentDisplayerDelegates)
            {
                displayer.Invoke();
            }
        }

        public void RegisterFindResultDisplayer(IUiService.FindResultDisplayerDelegate findResultDisplayerDelegateDelegate)
        {
            _findResultDisplayerDelegates.Add(findResultDisplayerDelegateDelegate);
        }

        public void ShowFindResult(int position)
        {
            foreach (var displayer in _findResultDisplayerDelegates)
            {
                displayer.Invoke(position);
            }
        }

        public void RegisterByteInfoShower(IUiService.ShowByteInfoDelegate showByteInfoDelegate)
        {
            _showByteInfoDelegates.Add(showByteInfoDelegate);
        }

        public void ShowByteInfo(ByteInfoNumber byteInfoNumber, HexByte hexByte)
        {
            foreach (var displayer in _showByteInfoDelegates)
            {
                displayer.Invoke(byteInfoNumber, hexByte);
            }
        }
    }
}
