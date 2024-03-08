using PeFileUtils.Business.Interfaces;
using PeFileUtils.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeFileUtils.Business.Services;

public class HexUtils : IHexUtils
{
    public HexByte[] ToHex(byte[] bytes)
    {
        var result = new List<HexByte>();
        for(int i = 0; i < bytes.Length; i++)
        {
            result.Add(new HexByte(bytes[i], i));
        }
        return result.ToArray();
    }

    public HexByte ToHex(string hexString, int positionInStream)
    {
        var b = Convert.ToByte(hexString, 16);
        var hexByte = new HexByte(b, positionInStream);
        return hexByte;
    }

    public string ToHex(int value)
    {
        List<int> digits = new List<int>();
        decimal rest = (decimal)value;
        while(rest > 0)
        {
            var digit = (int) (rest % 16);
            digits.Add(digit);
            rest = (int)rest / 16;
        }
        string result = "";
        foreach(var digit in digits)
        {
            result = string.Format("{0:X1}", Convert.ToByte(digit)) + result;
        }
        return result;
    }

    public string PositionToAddress(int positionInStream)
    {
        return string.Format("{0:X2}", positionInStream);
    }

    public string AddressDifference(HexByte hexByte1, HexByte hexByte2)
    {
        if (hexByte1 is null || hexByte2 is null) { return ""; }

        return string.Format("{0:X2}", hexByte2.PositionInStream - hexByte1.PositionInStream);
    }
}