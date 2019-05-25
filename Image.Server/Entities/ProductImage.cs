using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Entities
{
    public class ProductImage //: AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
        [MaxLength(50)]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [MaxLength(50000)]
        [Display(Name = "Thumb")]
        public byte[] ImageThumb { get; set; }
        [MaxLength(150000)]
        [Display(Name = "Full Image")]
        public byte[] ImageFull { get; set; }
        //navigation properties
        public ICollection<Product> Products { get; set; }
            = new List<Product>();

        public string GetImageThumb()
        {
            var base64 = Convert.ToBase64String(ImageThumb);

            return String.Format("data:image/gif;base64,{0}", base64);
        }

        public string GetImageFull()
        {
            var base64 = Convert.ToBase64String(ImageFull);

            return String.Format("data:image/gif;base64,{0}", base64);
        }
    }
}
