using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Business.Interfaces;

public interface IFileService
{
    public byte[] OpenFile(string path);
    public byte[] GetOpenedFileContent();
    public void SetByte(byte b, int positionInStream);
    public int Find(string text, int position);
}
