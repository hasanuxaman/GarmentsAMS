using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.ExportShipment
{
    public class ExportShipmentDetails
    {
        public int ExportShipmentDetailsId { get; set; }
        public int AccountLeadId { get; set; }
        public string AccountLeadName { get; set; }
        public string PortOfLoading { get; set; }
        public string GoodsDescription { get; set; }
        public int ModeOfShipmentId { get; set; }
        public string ModeOfShipment { get; set; }
        public int ForwarderOrCarrierId { get; set; }
        public string ForwarderOrCarrierName { get; set; }
        public string HBLorHAWBNo { get; set; }
        public string BLorAWABDt { get; set; }
        public DateTime _BLorAWABDt { get; set; }
        public string LCNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal ValueInUSD { get; set; }
        public decimal GrWeightInKg { get; set; }
        public decimal Quantity { get; set; }
        public int UnitId { get; set; }
        public string ETD { get; set; }
        public DateTime _ETD { get; set; }
        public string ETA { get; set; }
        public DateTime _ETA { get; set; }
        public string BerthingDate { get; set; }
        public DateTime _BerthingDate { get; set; }
        public string CBM { get; set; }
        public DateTime _CBM { get; set; }
        public int AssesmentStatusId { get; set; }
        public string AssesmentStatusName { get; set; }
        public string OTTDt { get; set; }
        public DateTime _OTTDt { get; set; }
        public string PCD { get; set; }
        public DateTime _PCD { get; set; }
        public string TentativeDeliveryDate { get; set; }
        public DateTime _TentativeDeliveryDate { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public int ContainerTypeId { get; set; }
        public string ContainerTypeName { get; set; }
        public string ContainerSizeName { get; set; }
        public string ICUnitName { get; set; }
        public string AssesmentStatus { get; set; }
        public int ContainerSizeId { get; set; }
        public string CreateDate { get; set; }
        public DateTime _CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public List<ExportShipmentFile> ExportShipmentFiles { get; set; }

        public string GetAssesmentStatusName(int id)
        {
            switch(id)
            {
                case 1:
                    return "Done";
                default:
                    return "---";
            }
        }
        
        public string GetModeOfShipment(int id)
        {
            switch(id)
            {
                case 1:
                    return "Sea";
                case 2:
                    return "Air";
                case 3:
                    return "Sea & Air";
                default:
                    return "---";
            }
        }
    }
}