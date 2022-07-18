using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Todo: BaseEntity
    {
        public string Task { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
