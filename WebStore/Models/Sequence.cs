using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStore.Models
{
	public class Sequence
	{
		[Key]
		public int OrderID { get; set; }
	}
}