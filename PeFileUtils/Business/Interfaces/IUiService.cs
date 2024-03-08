using PeFileUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Business.Interfaces
{
    public interface IUiService
    {
        public delegate void FileContentDisplayerDelegate();
        public void RegisterFileContentDisplayer(FileContentDisplayerDelegate fileContentDisplayerDelegate);
        public void RefreshFileContent();


        public delegate void FindResultDisplayerDelegate(int position);
        public void RegisterFindResultDisplayer(FindResultDisplayerDelegate findResultDisplayerDelegateDelegate);
        public void ShowFindResult(int position);


        public delegate void ShowByteInfoDelegate(ByteInfoNumber byteInfoNumber, HexByte hexByte);
        public void RegisterByteInfoShower(ShowByteInfoDelegate showByteInfoDelegate);
        public void ShowByteInfo(ByteInfoNumber byteInfoNumber, HexByte hexByte);
    }
}
