using WinLab.Windows.Helpers.IO.Enums;
using WinLab.Windows.Helpers.IO.Models;

namespace WinLab.Windows.Helpers.IO.Extensions
{
    public static class FileSizeExtensions
    {
        public static string ConvertToBits(this FileSize size, FileSizeSymbolType type) => size.Bits + (type == FileSizeSymbolType.Short ? " b" : " bits");

        public static string ConvertToBytes(this FileSize size, FileSizeSymbolType type) => size.Bytes + (type == FileSizeSymbolType.Short ? " B" : " bytes");

        public static string ConvertToKiloBytes(this FileSize size, FileSizeSymbolType type) => size.Kilobytes + (type == FileSizeSymbolType.Short ? " KB" : " kilobytes");

        public static string ConvertToMegaBytes(this FileSize size, FileSizeSymbolType type) => size.Megabytes + (type == FileSizeSymbolType.Short ? " MB" : " megabytes");

        public static string ConvertToGigaBytes(this FileSize size, FileSizeSymbolType type) => size.Gigabytes + (type == FileSizeSymbolType.Short ? " GB" : " gigabytes");

        public static string ConvertToTeraBytes(this FileSize size, FileSizeSymbolType type) => size.Terabytes + (type == FileSizeSymbolType.Short ? " TB" : " terabytes");

        public static int CompareTo(this FileSize fileSizeOne, FileSize fileSizeTwo) => fileSizeOne.Bits.CompareTo(fileSizeTwo.Bits);
    }
}