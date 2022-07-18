using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class TodoDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Task is required")]
        public string Task { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
