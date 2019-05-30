using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Models
{
    public class ProductImageForCreation
    {
        public string FileName { get; set; }

        public byte[] ImageThumb { get; set; }

        public byte[] ImageFull { get; set; }

        public int ProductId { get; set; }
    }
}
