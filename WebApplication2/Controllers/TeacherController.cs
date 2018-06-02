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
    public class TeacherController : ApiController
    {

        private ApiDBContext _db;

        public TeacherController()
        {
            this._db = new ApiDBContext();
        }

        /* 
         *  Hàm tạo Giáo viên
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
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }
        /* 
        *   Hàm cập nhập Giáo viên
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

                httpActionResult = Ok(errors);
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

        /* 
        *   Hàm lấy danh sách Giáo viên
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
        /* 
        *   Hàm lấy thông tin Giáo viên theo ID
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

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new TeacherModel(gv));
            }

            return httpActionResult;
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetListClassCN(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = _db.Teacher.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy Giáo viên này");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new GetListClassModel(gv.DanhSachLopChuNhiem));
            }

            return httpActionResult;
        }
    }
}