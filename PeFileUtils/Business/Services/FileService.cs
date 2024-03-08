using PeFileUtils.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace PeFileUtils.Business.Services;

public class FileService : IFileService
{
    private string _filePath = null;
    private byte[] _fileStream = new byte[0];
    private readonly IHexUtils _hexUtils;

    public FileService()
    {
        _hexUtils = App.Current.Services.GetService<IHexUtils>();
    }

    public byte[] GetOpenedFileContent()
    {
        _fileStream = File.ReadAllBytes(_filePath);
        return _fileStream;
    }

    public byte[] OpenFile(string path)
    {
        _filePath = path;
        _fileStream =  File.ReadAllBytes(path);
        return _fileStream;
    }

    public void SetByte(byte b, int positionInStream)
    {
        _fileStream[positionInStream] = b;
        File.WriteAllBytes(_filePath, _fileStream);
    }
    public int Find(string text, int position)
    {
        position = position * 2;
        var hexBytes = _hexUtils.ToHex(_fileStream);
        var hexBytesAsString = string.Join("", hexBytes.Select(m => m.ToString()));
        if(position>= hexBytesAsString.Length) { return -1; }

        var newPosition = hexBytesAsString.ToUpper().IndexOf(text.ToUpper(), position);
        if (newPosition < 0) { return -1; }
        newPosition = newPosition / 2;

        return newPosition;
    }
}
