using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Classes : Entity<int>
    {
        public string Malop { get; set; }
        public string Tenlop { get; set; }
        public virtual ICollection<Student> DanhSachSV { get; set; }
        public virtual Teacher GiaoVienChuNhiem { get; set; }
    }
}
