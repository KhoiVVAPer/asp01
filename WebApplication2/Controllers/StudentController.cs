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
    public class StudentController : ApiController
    {

        private ApiDBContext _db;

        public StudentController()
        {
            this._db = new ApiDBContext();
        }

        /**
         * @api (Post) Tạo một Sinh viên mới
         * @apiName CreateStudent
         * @apigroup Student
         * @apiPermission none
         * 
         * @apiParam {string} MSSV Mã số sinh viên của Sinh viên
         * @apiParam {string} HoTen Họ và tên của Sinh viên
         * @apiParam {datetime} NgaySinh Ngày sinh của Sinh viên
         * @apiParam {string} DiaChi Địa chỉ của Sinh viên
         * @apiParam {int} LOP_ID ID của lớp Sinh viên học
         * 
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      "MSSV" : "abc123",
         *      "HoTen" : "ABC",
         *      "NgaySinh" : "1997/2/15",
         *      "DiaChi" : "23/asdas",
         *      "LOP_ID" : 1
         * }
         * 
         * @apiSuccess {string} MSSV Mã số sinh viên của Sinh viên
         * @apiSuccess {string} HoTen Họ và tên của Sinh viên
         * @apiSuccess {datetime} NgaySinh Ngày sinh của Sinh viên
         * @apiSuccess {string} DiaChi Địa chỉ của Sinh viên
         * @apiSuccess {int} LOP_ID ID của lớp Sinh viên học
         * 
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         *  {
         *      "MSSV" : "abc123",
         *      "HoTen" : "ABC",
         *      "NgaySinh" : "1997/2/15",
         *      "DiaChi" : "23/asdas",
         *      "LOP_ID" : 1,
         *      "ID" : 1
         * }
         * 
         * @apiError BadRequest {string} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 400 Bad Request
         * {
         *      "Errors" : [
         *          "MSSV là trường bắt buộc"
         *      ]
         * }
         * 
         * @apiError NotFound {string} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "ID Lớp trống hoặc không tồn tại"
         *      ]
         * }
         * 
         * 
         * 
         */

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create(CreateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MSSV))
            {
                errors.Add("MSSV là trường bắt buộc");
            }
            
            if (_db.Class.FirstOrDefault(m => m.Id == model.LOP_ID) == null)
            {
                errors.Add("ID Lớp trống hoặc không tồn tại");
            }

            if (errors.Errors.Count == 0)
            {
                Student sv = new Student();
                sv.HoTen = model.HoTen;
                sv.MSSV = model.MSSV;
                sv.DiaChi = model.DiaChi;
                sv.NgaySinh = model.NgaySinh;
                sv.Class = _db.Class.FirstOrDefault(m => m.Id == model.LOP_ID);
                sv = _db.Students.Add(sv);

                this._db.SaveChanges();

                StudentModel viewModel = new StudentModel(sv);

                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }

            return httpActionResult;
        }

        /**
         * @api (Put) Cập nhập thông tin Sinh viên
         * @apiName EditStudent
         * @apigroup Student
         * @apiPermission none
         * 
         * @apiParam {string} MSSV Mã số sinh viên (mới) của Sinh viên
         * @apiParam {string} HoTen Họ và tên (mới) của Sinh viên
         * @apiParam {datetime} NgaySinh Ngày sinh (mới) của Sinh viên
         * @apiParam {string} DiaChi Địa chỉ (mới) của Sinh viên
         * @apiParam {int} LOP_ID ID của lớp (mới) Sinh viên học
         * @apiParam {int} ID ID của Sinh viên cần sữa
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      "MSSV" : "abc123",
         *      "HoTen" : "ABC",
         *      "NgaySinh" : "1997/2/15",
         *      "DiaChi" : "23/asdas",
         *      "LOP_ID" : 1,
         *      "ID" : 1
         * }
         * 
         * 
         * 
         * @apiSuccess {string} MSSV Mã số sinh viên (mới) của Sinh viên
         * @apiSuccess {string} HoTen Họ và tên (mới) của Sinh viên
         * @apiSuccess {datetime} NgaySinh Ngày sinh (mới) của Sinh viên
         * @apiSuccess {string} DiaChi Địa chỉ (mới) của Sinh viên
         * @apiSuccess {int} LOP_ID ID của lớp (mới) Sinh viên học
         * 
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         *  {
         *      "MSSV" : "abc123",
         *      "HoTen" : "ABC",
         *      "NgaySinh" : "1997/2/15",
         *      "DiaChi" : "23/asdas",
         *      "LOP_ID" : 1,
         *      "ID" : 1
         * }
         * 
         * @apiError BadRequest {string} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 400 Bad Request
         * {
         *      "Errors" : [
         *          "MSSV là trường bắt buộc"
         *      ]
         * }
         * 
         * @apiError NotFound {string} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "ID Sinh viên không tồn tại",
         *          "ID Lớp trống hoặc không tồn tại"
         *      ]
         * }
         * 
         * 
         * 
         */
        [System.Web.Http.HttpPut]
        public IHttpActionResult Update(UpdateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            Student sv = this._db.Students.FirstOrDefault(x => x.Id == model.Id);

            if (sv == null)
            {
                errors.Add("Không tìm thấy Sinh viên");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                sv.HoTen = model.HoTen ?? model.HoTen;
                sv.MSSV = model.MSSV ?? model.MSSV;
                sv.NgaySinh = model.NgaySinh;
                sv.DiaChi = model.DiaChi ?? model.DiaChi;
                sv.Class = _db.Class.FirstOrDefault(m => m.Id == model.LOP_ID);
                this._db.Entry(sv).State = System.Data.Entity.EntityState.Modified;

                this._db.SaveChanges();

                httpActionResult = Ok(new StudentModel(sv));
            }

            return httpActionResult;
        }
        /**
         * @api (Get) Lấy danh sách Sinh viên
         * @apiName GetAllStudents
         * @apigroup Student
         * @apiPermission none
         * 
         * 
         * @apiSuccess {Student[]} Danh sách Sinh viên
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * [
         *      {
         *          "MSSV" : "abc123",
         *          "HoTen" : "ABC",
         *          "NgaySinh" : "1997/2/15",
         *          "DiaChi" : "23/asdas",
         *          "LOP_ID" : 1,
         *          "ID" : 1
         *      },
         *      {
         *          "MSSV" : "abc126",
         *          "HoTen" : "XYZ",
         *          "NgaySinh" : "1997/6/15",
         *          "DiaChi" : "213/asdas",
         *          "LOP_ID" : 1,
         *          "ID" : 2
         *      }
         * ]
         * 
         * 
         * 
         */
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAll()
        {
            var listStudent = this._db.Students.Select(x => new StudentModel()
            {
                HoTen = x.HoTen,
                MSSV = x.MSSV,
                DiaChi = x.DiaChi,
                NgaySinh = x.NgaySinh,
                Id = x.Id,
                LOP_ID = x.Class.Id
            });

            return Ok(listStudent);
        }

        /**
         * @api (Get) Tìm Sinh viên theo ID
         * @apiName GetStudentById
         * @apigroup Student
         * @apiPermission none
         * 
         * @apiSuccess {string} Thông tin sinh viên
         * @apiSuccessExample Success-Response:
         *     HTTP/1.1 200 OK
         * {
         *      "MSSV" : "abc123",
         *      "HoTen" : "ABC",
         *      "NgaySinh" : "1997/2/15",
         *      "DiaChi" : "23/asdas",
         *      "LOP_ID" : 1,
         *      "ID" : 1
         * }
         * 
         * 
         * @apiError NotFound {string[]} Errors Mảng các lỗi
         * 
         * @apiErrorExample Error-Response:
         *     HTTP/1.1 404 Not Found
         * {
         *      "Errors" : [
         *          "Không tìm thấy sinh viên "
         *      ]
         * } 
         */
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var sv = _db.Students.FirstOrDefault(x => x.Id == id);

            if (sv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh viên này");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new StudentModel(sv));
            }

            return httpActionResult;
        }
    }
}