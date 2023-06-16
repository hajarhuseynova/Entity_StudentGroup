using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroup.Models
{
    internal class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
