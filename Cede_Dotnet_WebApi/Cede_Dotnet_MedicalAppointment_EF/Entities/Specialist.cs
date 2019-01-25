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
    public class Specialist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid SpecialistId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public Specialty Specialty { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Phone2 { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public SpecialistStatus SpecialistStatus { get; set; }

        public virtual ICollection<Disponibility> Disponibilities { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
