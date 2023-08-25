using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDOperation.Models
{
    public class StudentInfoModel
    {
        [Display (Name="SID")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Class { get; set; }
        public string Teacher { get; set; } 
        public int Total { get; set; }


    }





}