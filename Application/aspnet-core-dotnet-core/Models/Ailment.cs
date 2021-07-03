using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
   
    public class Ailment
    {
        [Key]
        public int AilmentId { get; set; }
        public string AilmentName { get; set; }
    }
}
