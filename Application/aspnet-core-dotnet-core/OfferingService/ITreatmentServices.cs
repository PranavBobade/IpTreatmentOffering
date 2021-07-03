using aspnet_core_dotnet_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.OfferingService
{
    public interface ITreatmentServices
    {
        List<PatientServicePackageView> GetPackages();
        List<PatientServicePackageView> GetPackagesByName(string packageName);
        List<SpecialistView> GetSpecialistDetails();
    }
}
