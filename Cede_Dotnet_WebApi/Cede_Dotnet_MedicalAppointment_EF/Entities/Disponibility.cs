using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cede_Dotnet_MedicalAppointment_EF.Entities
{
    public class Disponibility
    {
       public Guid DisponibilityId { get; set; }
       public short Hour { get; set; }
             
       public Guid SpecialistId { get; set; }

       public Specialist Specialist { get; set; }
        
    }
}
