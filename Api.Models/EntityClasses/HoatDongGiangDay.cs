using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class HoatDongGiangDay : Entity<int>
    {
        public virtual Teacher GiaoVien { get; set; }
        public virtual Classes Lop { get; set; }
    }
}
