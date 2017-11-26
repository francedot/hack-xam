using System.IO;

namespace EyeCare.Shared.Extensions
{
    public static class ByteExtensions
    {
        public static MemoryStream ToStream(this byte[] imageData)
        {
            return new MemoryStream(imageData);
        }
    }
}