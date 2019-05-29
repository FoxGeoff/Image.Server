using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        //public DateTime? DateUpdated { get; set; }
        public string FileName { get; set; }
        public byte[] ImageThumb { get; set; }
        public byte[] ImageFull { get; set; }
        //navigation properties
        public ICollection<Product> Products { get; set; }
    }
}
