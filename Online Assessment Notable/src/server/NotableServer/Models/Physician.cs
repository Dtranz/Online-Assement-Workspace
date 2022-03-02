using System.Runtime.Serialization;

namespace NotableServer.Models
{
    [DataContract]
    public class Physician
    {
        public Physician()
        {

        }

        public Physician(string name, int id)
        {
            Name = name;
            this.id = id;
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public List<ScheduledPatient> Schedule { get; set; }

    }
}
