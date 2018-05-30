using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
	public class ClassController : ApiController
	{
		private ApiDBContext _db;

		public ClassController()
		{
			this._db = new ApiDBContext();
		}

		[HttpPost]
		public IHttpActionResult Create(CreateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			if (string.IsNullOrEmpty(model.MaLop))
			{
				errors.Add("Mã lớp là trường bắt buộc");
			}

			if (string.IsNullOrEmpty(model.TenLop))
			{
				errors.Add("Tên lớp là trường bắt buộc");
			}
            if (_db.Teacher.FirstOrDefault(m => m.Id == model.GVCN_Id) == null)
            {
                errors.Add("ID Giáo viên trống hoặc không tồn tại");
            }

            if (errors.Errors.Count == 0)
			{
				Classes lop = new Classes();
				lop.Malop = model.MaLop;
				lop.Tenlop = model.TenLop;
                lop.GiaoVienChuNhiem = _db.Teacher.FirstOrDefault(m => m.Id == model.GVCN_Id);
                lop = _db.Class.Add(lop);

				this._db.SaveChanges();

				ClassModel viewModel = new ClassModel(lop);

				httpActionResult = Ok(viewModel);
			}
			else
			{
				httpActionResult = Ok(errors);
			}
            
			return httpActionResult;
		} 
        
		[HttpPut]
		public IHttpActionResult Update(UpdateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			Classes lop = this._db.Class.FirstOrDefault(x => x.Id == model.Id);

			if (lop == null)
			{
				errors.Add("Không tìm thấy lớp");

				httpActionResult = Ok(errors);
			}
			else
			{
				lop.Malop = model.MaLop ?? model.MaLop;
				lop.Tenlop = model.TenLop ?? model.TenLop;
                lop.GiaoVienChuNhiem = _db.Teacher.FirstOrDefault(m => m.Id == model.GVCN_Id);
                this._db.Entry(lop).State = System.Data.Entity.EntityState.Modified;

				this._db.SaveChanges();

				httpActionResult = Ok(new ClassModel(lop));
			}

			return httpActionResult;
		}

		[HttpGet]
		public IHttpActionResult GetAll()
		{
            var listLops = this._db.Class.Select(x => new ClassModel()
			{
				MaLop = x.Malop,
				TenLop = x.Tenlop,
				Id  = x.Id,
                GVCN_Id = x.GiaoVienChuNhiem.Id
            });

			return Ok(listLops);
		}
        
		[HttpGet]
		public IHttpActionResult GetById(int id)
		{
			IHttpActionResult httpActionResult; 
			var lop = _db.Class.FirstOrDefault(x => x.Id == id);

			if (lop == null)
			{
				ErrorModel errors = new ErrorModel();
				errors.Add("Không tìm thấy lớp");

				httpActionResult = Ok(errors);
			}
			else
			{
				httpActionResult = Ok(new ClassModel(lop));
			}

			return httpActionResult;
		}
	}
}