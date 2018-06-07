using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Infrastructure;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class TeacherController : ApiController
    {

        private ApiDBContext _db;

        public TeacherController()
        {
            this._db = new ApiDBContext();
        }


        /**
         * @api (Post) Tạo một giáo viên mới
         * @apiName CreateTeacher
         * @apigroup Teacher
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

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(CreateTeacherModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MaGV))
            {
                errors.Add("Mã giáo viên là trường bắt buộc");
            }

            if (string.IsNullOrEmpty(model.TenGV))
            {
                errors.Add("Tên giáo viên là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                Teacher gv = new Teacher();
                gv.MaGV = model.MaGV;
                gv.TenGV = model.TenGV;
                gv = _db.Teacher.Add(gv);

                this._db.SaveChanges();

                TeacherModel viewModel = new TeacherModel(gv);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }

            return httpActionResult;
        }


        /**
         * @api (Post) Cập nhập thông tin Giáo Viên
         * @apiName EditTeacher
         * @apigroup Teacher
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
        [System.Web.Http.HttpPut]
        public IHttpActionResult Update(UpdateTeacherModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            Teacher gv = this._db.Teacher.FirstOrDefault(x => x.Id == model.Id);

            if (gv == null)
            {
                errors.Add("Không tìm thấy giáo viên này");
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                gv.MaGV = model.MaGV ?? model.MaGV;
                gv.TenGV = model.TenGV ?? model.TenGV;
                this._db.Entry(gv).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new TeacherModel(gv));
            }

            return httpActionResult;
        }
        /**
                 * @api (Get) Lấy danh sách giáo viên
                 * @apiName GetAllTeacher
                 * @apigroup Teacher
                 * @apiPermission none
             *
                 * @apiSuccess {Object[]} DanhSachGiaoVien Danh sách giáo viên 
                 * 
                 * @apiSuccessExample Success-Response:
                 *     HTTP/1.1 200 OK
                 * [
                    *   DanhSachGiaoVien
             *	{
             *	
                "MaGV": "GV001",
             *	
                "TenGV": "GiaoVien 01",
             *	
                "Id": 1
            
             *	},

             *	{
             *	
                "MaGV": "GV002",
             *	
                "TenGV": "GiaoVien 02",
            
         *	        "Id": 2
            
             *	}

             * ]
                 * 
                 * @apiError Not Found {string[]} Errors Mảng các lỗi
                 * 
                 * @apiErrorExample Error-Response:
                 *     HTTP/1.1 404 Not Found
                 * {
                 *      "Errors" : [
                 *          "Không tìm thấy giáo viên này"
                 *      ]
                 * }
                 * 
                 * 
                 */





        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAllTeacher()
        {
            var listStudent = this._db.Teacher.Select(x => new TeacherModel()
            {
                MaGV = x.MaGV,
                TenGV = x.TenGV,
                Id = x.Id
            });

            return Ok(listStudent);
        }
        /**
         * @api (Get) Lấy giáo viên theo ID
         * @apiName GetTeacherById
         * @apigroup Teacher
         * @apiPermission none
	     *
         * @apiSuccess teacher Danh sách giáo viên 
         * 
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         *
	     * {
	     *     "MaGV": "GV001",
         *     "TenGV": "GiaoVien 01",
         *     "Id": 1
         * }
	     *
         * 
         * @apiError Not Found {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy giáo viên này"
         *      ]
         * }
         * 
         * 
         */
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.Teacher.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy Giáo viên này");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new TeacherModel(gv));
            }

            return httpActionResult;
        }

        



     	 /** @apiName GetListClassCN
         * @apigroup Teacher
         * @apiPermission none
	     *
         * @apiSuccess {Object[]} teacher Lấy danh sách lớp chủ nhiệm theo ID giáo viên
         *
         * @apiSuccessExample Success-Response:
         * HTTP/1.1 200 OK
         * {    

         *	"DanhSachLopChuNhiem" : [
	     *		{	
         *	        "MaLop" : "CNTT001",	
         *	        "TenLop": "Công nghệ thông tin",
         *	        "Id": 1
	     *		},
         *		{	
         *          "MaLop": "KT001",
         *          "TenLop": "Kế toán",
         *        	"Id": 2
         *		}
         *	 ]
         * }
         *
         * @apiError Not Found {string[]} Errors Mảng các lỗi
         *
         * @apiErrorExample Error-Response:
         * HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy Giáo viên này"
         *      ]
         * }
         *
         *
         */

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetListClassCN(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.Teacher.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy Giáo viên này");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new GetListClassCNModel(gv.DanhSachLopChuNhiem));
            }

            return httpActionResult;
        }


        



     	/** @apiName GetListClass
         * @apigroup Teacher
         * @apiPermission none
	     *
         * @apiSuccess {Object[]} teacher Lấy danh sách lớp dạy theo ID giáo viên
         *
         * @apiSuccessExample Success-Response:
         * HTTP/1.1 200 OK
         * {    
         *
         *	"DanhSachLopDay": [
	     *		{
         *   	    "MaLop" : "CNTT001",
         *	        "TenLop": "Công nghệ thông tin",
         *	        "Id": 1
	     *		},
         *		{	
         *	        "MaLop": "KT001",	
         *	        "TenLop": "Kế toán",
         *     	    "Id": 2
         *		}
         *	]
         * }
         *
         * @apiError Not Found {string[]} Errors Mảng các lỗi
         *
         * @apiErrorExample Error-Response:
         * HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy giáo viên này"
         *      ]
         * }
         *
         *
         */

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetListClass(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.Teacher.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy Giáo viên này");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new GetListClassModel(gv.DanhSachLopDay));
            }

            return httpActionResult;
        }
    }
}