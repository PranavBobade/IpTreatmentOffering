using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
    public class SpecialistView
    {

        [Key]

        public int SpecialistId { get; set; }
        public string Name { get; set; }
        public string Expertise { get; set; }
        public int YearsOfExp { get; set; }
        public long Contact { get; set; }
    }
}
