using Cede_Dotnet_MedicalAppointment_EF.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_Dotnet_MedicalAppointment_EF.Entities
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid AppointmentId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } 

        public Guid SpecialistId { get; set; }
        public Specialist Specialist { get; set; }

        public DateTime AppointmentDate { get; set; }

        [MaxLength(50)]
        [Required]
        public string Code { get; set; } = "AP" + DateTime.Now.Date.Day + DateTime.Now.Date.Hour + new Random().Next();

        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
