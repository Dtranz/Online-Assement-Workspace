using System.Runtime.Serialization;

namespace NotableServer.Models
{
    public enum VisitType
    {
        NewPatient = 0,
        FollowUp
    }

    [DataContract]
    public class ScheduledPatient
    {
        public ScheduledPatient ()
        {

        }

        public ScheduledPatient(Guid id, string time, string name, VisitType visit)
        {
            VisitTime = time;
            Id = id;
            PatientName = name;
            VisitType = visit;
        }
        [DataMember]
        public string VisitTime { get; set; }
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string? PatientName { get; set; }
        [DataMember]
        public VisitType VisitType { get; set; } 
    }
}
