using Microsoft.Extensions.DependencyInjection;
using PeFileUtils.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Entities;

[Bindable(true)]
public class HexByte : INotifyPropertyChanged
{
    private readonly IHexUtils _hexUtils;

    public readonly byte Byte;
    public readonly int PositionInStream;

    public event PropertyChangedEventHandler? PropertyChanged;

    public HexByte(byte binary, int positionInStream)
    {
        _hexUtils = App.Current.Services.GetService<IHexUtils>();
        Byte = binary;
        PositionInStream = positionInStream;
    }
    public HexByte Value
    {
        get { return this; }
    }

    public string Address
    {
        get
        {
            return _hexUtils.PositionToAddress(PositionInStream);
        }
    }

    public override string ToString()
    {
        return string.Format("{0:X2}", Byte);
    }
}
