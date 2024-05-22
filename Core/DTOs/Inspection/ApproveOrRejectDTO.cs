using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Inspection
{
    public class ApproveOrRejectDTO
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdInspection { get; set; }
        [Required]
        public int StatusInspection { get; set; }
        [Required]
        public string? Comment { get; set; }
    }
}
