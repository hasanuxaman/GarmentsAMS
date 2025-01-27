using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json;

namespace SQInventory.Models.FGWH
{
	[Serializable]
	public class ModelCartonCreate
	{

		#region Properties

		
		public int CartonID { get; set; }


	
		public string BuyerID { get; set; }



		public string BusinessUnitID { get; set; }
		


		public string PO { get; set; }



		public string Style { get; set; }



		public string ORDER_QTY { get; set; }



		public string WinShip_Quty { get; set; }



		public string PLUSE { get; set; }


		public string PERCENTAGE { get; set; }



		public string TOTAL_CTN { get; set; }


		public string DESTIN { get; set; }



		public string Solid_Colour { get; set; }


		public string Solid_Size { get; set; }


		public string CartonMeasurement { get; set; }



		
		public DateTime? CreateDate { get; set; }


		public string CreateBy { get; set; }



		//[JsonConverter(typeof(Core.DateTimeConverter))]
		public DateTime? UpdateDate { get; set; }


		public string UpdateBy { get; set; }

		public string BuyerName { get; set; }
		public string BusinessUnitName { get; set;}
		public List<CartonDetails> cartonDetails { get; set; }
		

		#endregion

		

	}
}