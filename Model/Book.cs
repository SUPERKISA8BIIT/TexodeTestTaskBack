using System;
using System.IO;

namespace Model
{
    public class Book
    {
        public string BookName { get; set; }

        public byte[] ImageByte ;
        public string Image 
        {
            get => Convert.ToBase64String(ImageByte);
            set => ImageByte = Convert.FromBase64String(value);
        }
        
    }
}
