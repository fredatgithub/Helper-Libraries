using WinLab.Windows.Helpers.IO.Enums;

namespace WinLab.Windows.Helpers.IO.Models
{
    public class FileSize
    {
        private long bytes = 0;

        private const long BitsInByte = 8;
        private const long BytesInKilobyte = 1024;
        private const long BytesInMegabyte = BytesInKilobyte * BytesInKilobyte;
        private const long BytesInGigabyte = BytesInMegabyte * BytesInKilobyte;
        private const long BytesInTerabyte = BytesInGigabyte * BytesInKilobyte;

        public FileSize(long size, FileSizeType fileSizeType)
        {
            Initialize(size, fileSizeType);
        }

        private void Initialize(long size, FileSizeType fileSizeType)
        {
            switch (fileSizeType)
            {
                case FileSizeType.Bit:
                    bytes = size / BitsInByte;
                    break;

                case FileSizeType.Byte:
                    bytes = size;
                    break;

                case FileSizeType.KiloByte:
                    bytes = size * BytesInKilobyte;
                    break;

                case FileSizeType.MegaByte:
                    bytes = size * BytesInMegabyte;
                    break;

                case FileSizeType.GigaByte:
                    bytes = size * BytesInGigabyte;
                    break;

                case FileSizeType.TeraByte:
                    bytes = size * BytesInTerabyte;
                    break;
            }
        }

        public long Bits { get { return bytes * BitsInByte; } }

        public long Bytes { get { return bytes; } }

        public long Kilobytes { get { return bytes / BytesInKilobyte; } }

        public long Megabytes { get { return bytes / BytesInMegabyte; } }

        public long Gigabytes { get { return bytes / BytesInGigabyte; } }

        public long Terabytes { get { return bytes / BytesInTerabyte; } }

        public override bool Equals(object fileSize)
        {
            return fileSize is FileSize ? Bytes == ((FileSize)fileSize).Bytes : false;
        }

        public override int GetHashCode()
        {
            return Bits.GetHashCode();
        }

        public static FileSize operator +(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return new FileSize(fileSizeOne.Bytes + fileSizeTwo.Bytes, FileSizeType.Byte);
        }

        public static FileSize operator -(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return new FileSize(fileSizeOne.Bytes - fileSizeTwo.Bytes, FileSizeType.Byte);
        }

        public static FileSize operator ++(FileSize fileSize)
        {
            return new FileSize(fileSize.Bytes + 1, FileSizeType.Byte);
        }

        public static FileSize operator --(FileSize fileSize)
        {
            return new FileSize(fileSize.Bytes - 1, FileSizeType.Byte);
        }

        public static bool operator ==(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return fileSizeOne.Bits == fileSizeTwo.Bits;
        }

        public static bool operator !=(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return fileSizeOne.Bits != fileSizeTwo.Bits;
        }

        public static bool operator <(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return fileSizeOne.Bits < fileSizeTwo.Bits;
        }

        public static bool operator <=(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return fileSizeOne.Bits <= fileSizeTwo.Bits;
        }

        public static bool operator >(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return fileSizeOne.Bits > fileSizeTwo.Bits;
        }

        public static bool operator >=(FileSize fileSizeOne, FileSize fileSizeTwo)
        {
            return fileSizeOne.Bits >= fileSizeTwo.Bits;
        }
    }
}