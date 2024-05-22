﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Vehicle
{
    public class InspectableDTO
    {
        [Required]
        public string? Name { get; set; } 
        [Required]
        public string? Description { get; set; }
    }
}