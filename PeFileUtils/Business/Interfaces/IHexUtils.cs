using PeFileUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Business.Interfaces;

public interface IHexUtils
{
    public HexByte[] ToHex(byte[] bytes);
    public HexByte ToHex(string hexString, int positionInStream);
    public string ToHex(int value);
    public string PositionToAddress(int positionInStream);
    public string AddressDifference(HexByte hexByte1, HexByte hexByte2);
}
