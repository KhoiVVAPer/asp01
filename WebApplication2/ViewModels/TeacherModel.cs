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

    public class ViewClassModel
    {
        public int id { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
    }

    public class GetListClassModel
    {
        public List<ViewClassModel> DanhSachLopChuNhiem { get; set; }
        public GetListClassModel(ICollection<Classes> DanhSachLop)
        {
            this.DanhSachLopChuNhiem = new List<ViewClassModel>();
            foreach(Classes lop in DanhSachLop)
            {
                this.DanhSachLopChuNhiem.Add(new ViewClassModel()
                {
                    id = lop.Id,
                    MaLop = lop.Malop,
                    TenLop = lop.Tenlop
                });
            }
        }
    }
}