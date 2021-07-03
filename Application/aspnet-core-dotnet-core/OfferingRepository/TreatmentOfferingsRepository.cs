using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


using System.Diagnostics.CodeAnalysis;
using aspnet_core_dotnet_core.Models;
using aspnet_core_dotnet_core.OfferingRepository;

namespace aspnet_core_dotnet_core.OfferingRepository
{
   
    public class TreatmentOfferingsRepository : ITreatmentOfferingsRepository
    {
        public List<Ailment> Ailments { get { return Offerings.ailmentCategory; } }
        public List<TreatmentPackage> Packages { get { return Offerings.packages; } }
        public List<Specialist> Specialists { get { return Offerings.specialistsList; } }
        public List<PatientServicePackageView> AllPackage()
        {
            List<PatientServicePackageView> packages = (from x in Ailments
                                                        join y in Packages on x.AilmentId equals y.AilmentId
                                                        select new PatientServicePackageView()
                                                        {
                                                            PackageId = y.PackageId,
                                                            Ailment = x.AilmentName,
                                                            PackageName = y.PackageName,
                                                            TestDetails = y.TestDetails,
                                                            Cost = y.Cost,
                                                            Duration = y.Duration
                                                        }).ToList<PatientServicePackageView>();
            return packages;
        }
        public List<SpecialistView> AllSpecialist()
        {
            List<SpecialistView> specialists = (from x in Specialists
                                                join y in Ailments on x.AreaOfExpertise equals y.AilmentId
                                                select new SpecialistView()
                                                {
                                                    SpecialistId = x.Id,
                                                    Name = x.Name,
                                                    Expertise = y.AilmentName,
                                                    YearsOfExp = x.YearsOfExp,
                                                    Contact = x.Contact
                                                }).ToList<SpecialistView>();
            return specialists;
        }
    }
}
