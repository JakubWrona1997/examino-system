using Examino.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examino.Infrastructure.DummyData
{
    public class DummyRaports
    {
        public static List<Raport> GetRaports()
        {
            List<Raport> raports = new List<Raport>();

            var raport1 = new Raport()
            {
                Id = Guid.Parse("a34d644f-55fc-4a39-addd-a8cc07f89c34"),
                DoctorId = Guid.Parse("ae47d26c-b934-4057-8d05-dfd78ea1a138"),
                PatientId= Guid.Parse("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                RaportTime = DateTime.Now,
                Symptoms=" heart pain,pain in middle of chest,lazziness ",
                Examination = "checking pulse, checking sound of lungs",
                Diagnosis = " there are needed cholesterol tests ",
                Comment=" do cholesterol tests",
                Recommendation="increase potassium income"

            };
            var raport2 = new Raport()
            {
                Id = Guid.Parse("b03172a3-fc8f-4419-a63e-618359d4cd99"),
                DoctorId = Guid.Parse("d9339e74-284d-46f4-ad46-b13269c4900e"),
                PatientId = Guid.Parse("c394c3c5-3727-4b3b-999f-de8180edf15f"),
                RaportTime = DateTime.Now,
                Symptoms = " runny nose ",
                Examination = "after checking nose i saw curve in bones",
                Diagnosis = "curve septum",
                Comment = "there is need for rendgen photo",
                Recommendation = "using nasonex twice a day  at 7 AM and at 9PM"

            };
            var raport3 = new Raport()
            {
                Id = Guid.Parse("c72b703e-21f0-45ea-9323-e1362b494cb1"),
                DoctorId = Guid.Parse("d9339e74-284d-46f4-ad46-b13269c4900e"),
                PatientId = Guid.Parse("4d9b6996-8e8a-4cec-9f2f-d7f64e2113ca"),
                RaportTime = DateTime.Now,
                Symptoms = "runny nose after night's sleep  ",
                Examination = "runny nose",
                Diagnosis = "allergy to dust mites",
                Comment = "there are needed allergy tests",
                Recommendation = "bed cleaning, xyzal once a day"

            };
            raports.Add(raport1);
            raports.Add(raport2);
            raports.Add(raport3);
            return raports;


        }
    }
}
