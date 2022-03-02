using System.Runtime.Serialization;
using NotablePhysicianServer.Models;

namespace NotablePhysicianServer.Dtos
{
    [DataContract]
    public class PhysicianDto
    {
        public PhysicianDto()
        {
        
        }

        public PhysicianDto(string name, Guid id)
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
        public Guid id { get; set; }

    }
}
