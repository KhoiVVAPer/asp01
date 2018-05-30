using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
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
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Update(UpdateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            Student sv = this._db.Students.FirstOrDefault(x => x.Id == model.Id);

            if (sv == null)
            {
                errors.Add("Không tìm thấy Sinh viên");

                httpActionResult = Ok(errors);
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

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var sv = _db.Students.FirstOrDefault(x => x.Id == id);

            if (sv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh viên này");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new StudentModel(sv));
            }

            return httpActionResult;
        }
    }
}