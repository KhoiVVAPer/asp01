using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class Student: Entity<int>
	{
		public string HoTen { get; set; }
		public DateTime NgaySinh { get; set; }
		public string DiaChi { get; set; }
        [Required]
        public string MSSV { get; set; }
        
        public virtual Classes Class { get; set; }
	}
}
