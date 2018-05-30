using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class TeacherModel
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public int Id { get; set; }
        public TeacherModel() { }
        public TeacherModel(Teacher gv)
        {
            this.MaGV = gv.MaGV;
            this.TenGV = gv.TenGV;
            this.Id = gv.Id;
        }
    }
    public class CreateTeacherModel
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }
    }
    public class UpdateTeacherModel : CreateTeacherModel
    {
        public int Id { get; set; }
    }
}