using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Models
{
    public class PatientServicePackageView
    {

        [Key]
        public int PackageId { get; set; }
        public string Ailment { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public double Cost { get; set; }
        public int Duration { get; set; }
    }
}
