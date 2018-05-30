using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class StudentModel
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MSSV { get; set; }
        public int Id { get; set; }
        public int LOP_ID { get; set; }
        public StudentModel() { }
        public StudentModel(Student stu)
        {
            this.HoTen = stu.HoTen;
            this.NgaySinh = stu.NgaySinh;
            this.DiaChi = stu.DiaChi;
            this.MSSV = stu.MSSV;
            this.LOP_ID = stu.Class.Id;
            this.Id = stu.Id;
        }
    }

    public class CreateStudentModel{

        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string MSSV { get; set; }
        public int LOP_ID { get; set; }
    }
    public class UpdateStudentModel : CreateStudentModel
    {
        public int Id { get; set; }
    }
}