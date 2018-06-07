using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Api.Models;
using WebApplication2.Infrastructure;
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
         * @api (Post) Tạo một lớp mới
         * @apiName CreateTeacher
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
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * {
         *      "Id" : "1",
         *      "Malop" : "bcd123",
         *      "Tenlop" : "Công nghệ thông tin 2"
         * }
         * 
         * @apiError BadRequest {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 400 Bad Request
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
                errors.Add("ID Giáo viên chủ nhiệm trống hoặc không tồn tại");
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
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }
            
			return httpActionResult;
		}
        /**
         * @api (Post) Thêm giáo viên vào lớp
         * @apiName AddTeacher
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiParam {int} Id_GV ID của giáo viên
         * @apiParam {int} Id_Lop ID của lớp
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      "Id_GV" : "1",
         *      "Id_Lop" : "2"
         * }
         * 
         * @apiSuccess {int} Id_GV ID của giáo viên vừa thêm
         * @apiSuccess {int} Id_Lop ID của lớp vừa được thêm giáo viên
         * 
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * {
         *      "Id_GV" : "1",
         *      "Id_Lop" : "2",
         * }
         * 
         * @apiError NotFound {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy giáo viên ",
         *          "Không xác định được lớp "
         *      ]
         * }
         * 
         * 
         * 
         */
        [HttpPost]
        public IHttpActionResult AddGV(AddTeacherModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();
            
           
            Teacher t = new Teacher();
            t = _db.Teacher.FirstOrDefault(m => m.Id == model.Id_GV);
            Classes l = new Classes();
            l = _db.Class.FirstOrDefault(m => m.Id == model.Id_Lop);
            if (t == null)
            {
                errors.Add("Không tìm thấy Giáo viên có ID là : " + model.Id_GV);
            }
            if (l == null)
            {
                errors.Add("Không tìm thấy Lớp có ID là : " + model.Id_Lop);

            }
            if (errors.Errors.Count == 0)
            {
                l.DanhSachGV.Add(t);
                this._db.SaveChanges();

                ClassModel viewModel = new ClassModel(l);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }

            return httpActionResult;
        }

        /**
         * @api (Put) Cập nhập thông tin lớp
         * @apiName EditTeacher
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiParam {int} Id Id của lớp cần cập nhập
         * @apiParam {string} MaLop Mã lớp mới
         * @apiParam {string} Tenlop Tên lớp mới
         * @apiParam {int} GVCN_Id Id của giáo viên chủ nhiệm
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      "Id" : "1",
         *      "MaLop" : "15DTH",
         *      "Tenlop" : "Công nghệ thông tin 2",
         *      "GVCN_Id" : 2
         * }
         * 
         * @apiSuccess {int} Id ID của lớp vừa cập nhập
         * @apiSuccess {string} Malop Mã của lớp vừa cập nhập
         * @apiSuccess {string} Tenlop Tên của lớp vừa cập nhập
         * @apiSuccess {int} GVCN_Id Id của giáo viên chủ nhiệm lớp này
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * {
         *      "Id" : "1",
         *      "Malop" : "15DTH",
         *      "Tenlop" : "Công nghệ thông tin 2",
         *      "GVCN_Id" : "2"
         * }
         * 
         * @apiError NotFound {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy lớp "
         *      ]
         * }
         * 
         * 
         * 
         */
        [HttpPut]
		public IHttpActionResult Update(UpdateClassModel model)
		{
			IHttpActionResult httpActionResult;
			ErrorModel errors = new ErrorModel();

			Classes lop = this._db.Class.FirstOrDefault(x => x.Id == model.Id);

			if (lop == null)
			{
				errors.Add("Không tìm thấy lớp");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
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

        /**
         * @api (Get) Lấy danh sách lớp
         * @apiName GetAllClass
         * @apigroup Class
         * @apiPermission none
         * 
         * 
         * @apiSuccess {int} Id ID của lớp
         * @apiSuccess {string} Malop Mã của lớp 
         * @apiSuccess {string} Tenlop Tên của lớp
         * @apiSuccess {int} GVCN_Id Id của giáo viên chủ nhiệm lớp
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * [
         *      {
         *          "Id" : "1",
         *          "Malop" : "15DTH",
         *          "Tenlop" : "Công nghệ thông tin 2",
         *          "GVCN_Id" : "2"
         *      },
         *      {
         *          "Id" : "2",
         *          "Malop" : "15DTH02",
         *          "Tenlop" : "Kế toán",
         *          "GVCN_Id" : "1"
         *      }
         * ]
         * 
         * 
         * 
         */
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

        /**
         * @api (Get) Tìm lớp theo ID
         * @apiName GetById
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiSuccess {int} Id ID của lớp
         * @apiSuccess {string} Malop Mã của lớp 
         * @apiSuccess {string} Tenlop Tên của lớp
         * @apiSuccess {int} GVCN_Id Id của giáo viên chủ nhiệm lớp
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         *  {
         *      "Id" : "1",
         *      "Malop" : "15DTH",
         *      "Tenlop" : "Công nghệ thông tin 2",
         *      "GVCN_Id" : "2"
         *  }
         * 
         * 
         * 
         * @apiError NotFound {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy lớp "
         *      ]
         * } 
         */
        [HttpGet]
		public IHttpActionResult GetById(int id)
		{
			IHttpActionResult httpActionResult; 
			var lop = _db.Class.FirstOrDefault(x => x.Id == id);

			if (lop == null)
			{
				ErrorModel errors = new ErrorModel();
				errors.Add("Không tìm thấy lớp");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
			else
			{
				httpActionResult = Ok(new ClassModel(lop));
			}
             
			return httpActionResult;
		}

        /**
         * @api (Get) Lấy danh sách giáo viên dạy lớp
         * @apiName GetListTeacherById
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiSuccess {Teacher[]} DanhSachGiaoVien Danh sách giáo viên của lớp đó
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * {
         *      "DanhSachGiaoVien": [
         *          {
         *              "MaGV": "GV001",
         *              "TenGV": "GiaoVien 01",
         *              "Id": 1
         *          },
         *          {
         *              "MaGV": "GV002",
         *              "TenGV": "GiaoVien 02",
         *              "Id": 2
         *          }
         *      ]
         * }
         * 
         * 
         * @apiError NotFound {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy lớp "
         *      ]
         * } 
         */
        [HttpGet]
        public IHttpActionResult GetListTeacherById(int id)
        {
            IHttpActionResult httpActionResult;
            var lop = _db.Class.FirstOrDefault(x => x.Id == id);

            if (lop == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy lớp");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new GetClassTeachersModel(lop));
            }

            return httpActionResult;
        }

        /**
         * @api (Get) Lấy danh sách sinh viên của lớp
         * @apiName GetListTeacherById
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiSuccess {List} Danh sách sinh viên của lớp đó
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * {
         *       "DanhSachSinhVien": [
         *           {
         *               "HoTen": "anh khoi",
         *               "NgaySinh": "1996-05-05T00:00:00",
         *               "DiaChi": "15 To Ngoc Van",
         *               "MSSV": "1511060526",
         *               "Id": 1,
         *               "LOP_ID": 1
         *           },
         *           {
         *               "HoTen": "SV02",
         *               "NgaySinh": "1996-05-05T00:00:00",
         *               "DiaChi": "15 To Ngoc Van",
         *               "MSSV": "151231",
         *               "Id": 2,
         *               "LOP_ID": 1
         *           }
         *       ]
         * }
         * 
         * 
         * @apiError NotFound {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy lớp "
         *      ]
         * } 
         */
        [HttpGet]
        public IHttpActionResult GetListStudentById(int id)
        {
            IHttpActionResult httpActionResult;
            var lop = _db.Class.FirstOrDefault(x => x.Id == id);
                
            if (lop == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy lớp");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new GetClassStudentsModel(lop));
            }

            return httpActionResult;
        }
    }
}