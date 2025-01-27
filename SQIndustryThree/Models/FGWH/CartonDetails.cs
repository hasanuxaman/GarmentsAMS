using System;
using System.Collections.Generic;
using System.ComponentModel;

using Newtonsoft.Json;

namespace SQInventory.Models.FGWH
{
	[Serializable]
	public class CartonDetails 
	{

		#region Properties

		public int CartonDetailsID { get; set; }
		
		public int CartonID { get; set; }
		
	

		
		public string CartonNo { get; set; }

		public string Color { get; set; }

		public string SizeXS { get; set; }


		public string SizeS { get; set; }

		public string SizeM { get; set; }

		public string SizeL { get; set; }

		public string SizeXL { get; set; }

		public string SizeXX { get; set; }


		public string SizeXXX { get; set; }


		public decimal? Quentity { get; set; }

		public decimal? NET_WEIGHT { get; set; }


		public decimal? GROSS_WEIGHT { get; set; }


		public string CreateBy { get; set; }

		//[JsonConverter(typeof(Core.DateTimeConverter))]
		public DateTime? CreateDate { get; set; }

		public string UpdateBy { get; set; }



		
		
		public DateTime? UpdateDate { get; set; }
		
		

		#endregion

	

	}
}