using System;

class Bits
{
    private readonly bool[] bits;

    public Bits(bool[] bits)
    {
        this.bits = bits;
    }

    public static implicit operator Bits(long value)
    {
        return new Bits(ConvertToBits(value, sizeof(long) * 8));
    }

    public static implicit operator Bits(int value)
    {
        return new Bits(ConvertToBits(value, sizeof(int) * 8));
    }

    public static implicit operator Bits(byte value)
    {
        return new Bits(ConvertToBits(value, sizeof(byte) * 8));
    }

    private static bool[] ConvertToBits(long value, int length)
    {
        bool[] result = new bool[length];
        for (int i = length - 1; i >= 0; i--)
        {
            result[i] = (value & (1 << (length - i - 1))) != 0;
        }
        return result;
    }

    public void DisplayBits()
    {
        foreach (bool bit in bits)
        {
            Console.Write(bit ? "1" : "0");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        long longValue = 123456789012345;
        int intValue = 12345;
        byte byteValue = 123;

        Bits bitsFromLong = longValue;
        Bits bitsFromInt = intValue;
        Bits bitsFromByte = byteValue;

        Console.WriteLine("Bits long:");
        bitsFromLong.DisplayBits();

        Console.WriteLine("Bits int:");
        bitsFromInt.DisplayBits();

        Console.WriteLine("Bits byte:");
        bitsFromByte.DisplayBits();
    }
}