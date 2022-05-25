using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    public class DummyPrescriptions
    {
        public static  List<Prescription> GetPrescriptions()
        {
            List<Prescription> prescriptions = new List<Prescription>();
            var prescription1 = new Prescription()
            {
                Id = Guid.Parse("9d092a09-ae05-4333-9872-a5c35727f4f5"),
                Medicines="xyzal 5mg film-coated tablets ",
                RaportId = Guid.Parse("c72b703e-21f0-45ea-9323-e1362b494cb1")
            };
            var prescription2 = new Prescription()
            {
                Id = Guid.Parse("aca33117-640a-47f5-b3d8-2739a7698042"),
                Medicines = "nasonex 18g ",
                RaportId = Guid.Parse("b03172a3-fc8f-4419-a63e-618359d4cd99")
            };
            var prescription3 = new Prescription()
            {
                Id = Guid.Parse("33842c30-c6b2-4dab-87a6-9e71e4bb0250"),
                Medicines = "potassium suplement",
                RaportId = Guid.Parse("a34d644f-55fc-4a39-addd-a8cc07f89c34")
            };
         


            prescriptions.Add(prescription1);
            prescriptions.Add(prescription2);
            prescriptions.Add(prescription3);
            return prescriptions;
        }
    }
}
