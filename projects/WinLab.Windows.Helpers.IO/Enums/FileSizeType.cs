using System.Runtime.InteropServices;

namespace WinLab.Windows.Helpers.IO.Enums
{
    [Guid("C5A57F69-FE1A-4822-886D-9826A7EF97C6")]
    public enum FileSizeType
    {
        Bit = 1,
        Byte = 2,
        KiloByte = 4,
        MegaByte = 8,
        GigaByte = 16,
        TeraByte = 32
    }
}