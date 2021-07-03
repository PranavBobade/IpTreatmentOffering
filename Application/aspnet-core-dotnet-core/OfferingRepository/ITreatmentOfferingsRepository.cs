using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.Models;


namespace aspnet_core_dotnet_core.OfferingRepository
{
    public interface ITreatmentOfferingsRepository
    {
        List<PatientServicePackageView> AllPackage();
        List<SpecialistView> AllSpecialist();
    }
}
