using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.Models;
using aspnet_core_dotnet_core.OfferingRepository;

using Microsoft.AspNetCore.Authorization;
using System.Diagnostics.CodeAnalysis;
using aspnet_core_dotnet_core.OfferingService;

namespace aspnet_core_dotnet_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferingController : ControllerBase
    {
        private ITreatmentServices _services;
        public OfferingController(ITreatmentServices services)
        {
            this._services = services;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,User")]

        [Route("getPackages")]
        public IEnumerable<PatientServicePackageView> GetTreatmentPackages()
        {
            return _services.GetPackages();
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]

        [Route("getPackagesByName")]
        public IEnumerable<PatientServicePackageView> GetTreatmentPackagesByName([FromQuery] string packageName)
        {
            return _services.GetPackagesByName(packageName);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        [Route("getSpecialists")]
        public IEnumerable<SpecialistView> GetSpecialist()
        {
            return _services.GetSpecialistDetails();
        }
    }
}
