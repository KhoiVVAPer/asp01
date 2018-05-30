using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
	public class ClassModel
	{   
		public string MaLop { get; set; }
		public string TenLop { get; set; }
		public int Id { get; set; }
        public int GVCN_Id { get; set; }

		public ClassModel() { }
		public ClassModel(Classes lop)
		{
			this.MaLop = lop.Malop;
			this.TenLop = lop.Tenlop;
			this.Id = lop.Id;
            this.GVCN_Id = lop.GiaoVienChuNhiem.Id;
		}
	}

	public class CreateClassModel
	{
		public string MaLop { get; set; }
		public string TenLop { get; set; }  
        public int GVCN_Id { get; set; } 

	}

	public class UpdateClassModel : CreateClassModel
	{
		public int Id { get; set; }
	}
}