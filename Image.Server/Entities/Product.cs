using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Entities
{
    public class Product
    {
        [Key]
        public uint Id { get; set; }
        [Column("IsDiscontinued")]
        public byte Discontinued { get; set; }
        [Column("AssociatedCategoryId")]
        public uint? Category { get; set; }
        [Column("AssociatedSnapshotTypeId")]
        public uint? Snapshot { get; set; }
        [Column("AssociatedGroupId")]
        public uint? Group { get; set; }
        [Column("AssociatedScreenId")]
        public uint? Screen { get; set; }
        //Key
        [Column("AssociatedImageId")]
        public uint? Image { get; set; }
        [Column("AssociatedRecycleId")]
        public uint? RecycleNumber { get; set; }
        public string MerchantNumber { get; set; }
        public string ProductDescription { get; set; }
        public string AiPartNumber { get; set; }
        public string ManufactureNumber { get; set; }
        public string ManufactureName { get; set; }
        public string MfgUrl { get; set; }
        public string MfgManualUrl { get; set; }
        [Column("AssociatedPrimaryVendorId")]
        public uint? PrimaryVendor { get; set; }
        [Column("AssociatedSecondaryVendorId")]
        public uint? SecondaryVendor { get; set; }
        [Column("AssociatedTertiaryVendorId")]
        public uint? TertiaryVendor { get; set; }
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
        public ICollection<ProductImage> ProductImages { get; set; }
            = new List<ProductImage>();
    }
}
