using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroup.Models
{
    internal class Student:BaseModel
    {
        public string Surname { get; set; }
       public int GroupId { get; set; } 
        public Group Group { get; set; }
    }
}
