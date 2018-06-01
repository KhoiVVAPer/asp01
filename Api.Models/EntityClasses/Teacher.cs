using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Teacher:Entity<int>
    {
        public string MaGV { get; set; }
        public string TenGV { get; set; }
        public virtual ICollection<Classes> DanhSachLopChuNhiem { get; set; }
        
        public virtual ICollection<Classes> DanhSachLopDay { get; set; }
    }
}
