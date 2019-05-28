using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Models
{
    public class Product
    {
        //[Key]
        public int Id { get; set; }
        //[Column("IsDiscontinued")]
        //public byte Discontinued { get; set; }
        //[Column("AssociatedCategoryId")]
        //public int? Category { get; set; }
        //[Column("AssociatedSnapshotTypeId")]
        //public int? Snapshot { get; set; }
        //[Column("AssociatedGroupId")]
        //public int? Group { get; set; }
        //[Column("AssociatedScreenId")]
        //public int? Screen { get; set; }
        //[ForeignKey("ProductImage")]
        //[Column("AssociatedImageId")]
        //public int? Image { get; set; }
        //[Column("AssociatedRecycleId")]
        //public int? RecycleNumber { get; set; }
        public string MerchantNumber { get; set; }
        public string ProductDescription { get; set; }
        public string AiPartNumber { get; set; }
        public string ManufactureNumber { get; set; }
        public string ManufactureName { get; set; }
        public string MfgUrl { get; set; }
        public string MfgManualUrl { get; set; }
        //[Column("AssociatedPrimaryVendorId")]
        //public int? PrimaryVendor { get; set; }
        //[Column("AssociatedSecondaryVendorId")]
        //public int? SecondaryVendor { get; set; }
        //[Column("AssociatedTertiaryVendorId")]
        //public int? TertiaryVendor { get; set; }
        public double? Retail { get; set; }
        public double? Cost { get; set; }
        public byte AdditionalCost { get; set; }
        public double? DefaultPriority { get; set; }
        [Column("IsTaxable")]
        public byte? Taxable { get; set; }
        [Column("IsRecycleFee")]
        public byte RecycleFee { get; set; }
        public string ItemsAssociated { get; set; }
        [Column("IsExcludedDesAinumOverrwrite")]
        public sbyte ExcludedDesAiNum { get; set; }
        [Column("CostVerificationBy")]
        public int CostVerification { get; set; }

        //navigation properties
        public ProductImage ProductImage { get; set; }
    }
}
