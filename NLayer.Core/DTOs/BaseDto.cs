using System;
using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
	public class BaseDto
	{
		public int Id { get; set; }
		[JsonIgnore]
		public DateTime? CreatedDate { get; set; } 
		[JsonIgnore]
		public DateTime? UpdatedDate { get; set; } 
	}
}

