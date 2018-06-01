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
        /**
         * @api (Post) /Class/TaoLop Tạo một lớp mới
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiParam {string} Malop Mã của lớp mới
         * @apiParam {string} Tenlop Tên của lớp mới
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      "Malop" : "abc123",
         *      "Tenlop" : "Công nghệ thông tin"
         * }
         * 
         * @apiSuccess {string} Malop Mã của lớp vừa tạo
         * @apiSuccess {string} Tenlop Tên của lớp vừa tạo
         * @apiSuccess {int} Id Id của lớp mới
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      "Id" : "1",
         *      "Malop" : "bcd123",
         *      "Tenlop" : "Công nghệ thông tin 2"
         * }
         * 
         * @apiError (Error 400) {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample: {json}
         * {
         *      "Errors" : [
         *          "Mã lớp là trường bắt buộc",
         *          "Tên lớp là trường bắt buộc"
         *      ]
         * }
         * 
         * 
         * 
         * 
         */

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

        [HttpPost]
        public IHttpActionResult AddGV(AddTeacherModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();
            
            
            if (errors.Errors.Count == 0)
            {

                Teacher t = new Teacher();
                t = _db.Teacher.FirstOrDefault(m => m.Id == model.Id_GV);
                Classes l = new Classes();
                l = _db.Class.FirstOrDefault(m => m.Id == model.Id_Lop);
                l.DanhSachGV = new List<Teacher>();
                l.DanhSachGV.Add(t);
                this._db.SaveChanges();

                ClassModel viewModel = new ClassModel(l);

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