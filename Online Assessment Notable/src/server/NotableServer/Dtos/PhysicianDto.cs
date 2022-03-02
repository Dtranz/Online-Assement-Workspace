using System.Runtime.Serialization;
using NotableServer.Models;

namespace NotableServer.Dtos
{
    [DataContract]
    public class PhysicianDto
    {
        public PhysicianDto()
        {
        
        }

        public PhysicianDto(string name, int id)
        {
            Name = name;
            this.id = id;
        }

        public PhysicianDto(Physician physician)
        {
            this.id = physician.id;
            this.Name = physician.Name;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public List<ScheduledPatientDto> Schedule { get; set; }
    }
}
