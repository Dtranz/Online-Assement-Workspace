using System.Runtime.Serialization;

namespace NotablePhysicianServer.Models
{
    [DataContract]
    public class Physician
    {
        public Physician()
        {

        }

        public Physician(string name, Guid id)
        {
            Name = name;
            this.id = id;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid id { get; set; }

    }
}
