using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroup.Models
{
    internal class Group:BaseModel
    {
        public List<Student> Students { get; set; } 
    }
}
