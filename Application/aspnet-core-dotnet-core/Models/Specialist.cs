﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
   
    public class Specialist
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Ailment Ailment { get; set; }

        [ForeignKey("Ailment")]
        public int AreaOfExpertise { get; set; }
        public int YearsOfExp { get; set; }
        public long Contact { get; set; }
    }
}
