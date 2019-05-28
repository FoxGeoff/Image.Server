using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Image.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public byte Discontinued { get; set; }
        public int? Category { get; set; }
        public int? Snapshot { get; set; }
        public int? Group { get; set; }
        public int? Screen { get; set; }
        public int? Image { get; set; }
        public int? RecycleNumber { get; set; }
        public string MerchantNumber { get; set; }
        public string ProductDescription { get; set; }
        public string AiPartNumber { get; set; }
        public string ManufactureNumber { get; set; }
        public string ManufactureName { get; set; }
        public string MfgUrl { get; set; }
        public string MfgManualUrl { get; set; }
        public int? PrimaryVendor { get; set; }
        public int? SecondaryVendor { get; set; }
        public int? TertiaryVendor { get; set; }
        public double? Retail { get; set; }
        public double? Cost { get; set; }
        public byte AdditionalCost { get; set; }
        public double? DefaultPriority { get; set; }
        public byte? Taxable { get; set; }
        public byte RecycleFee { get; set; }
        public string ItemsAssociated { get; set; }
        public sbyte ExcludedDesAiNum { get; set; }
        public int CostVerification { get; set; }
        //navigation properties
        public ProductImage ProductImage { get; set; }
    }
}
