using System.Runtime.Serialization;
using NotableServer.Models;

namespace NotableServer.Dtos
{

    [DataContract]
    public class ScheduledPatientDto
    {
        public ScheduledPatientDto()
        {

        }

        public ScheduledPatientDto(Guid id, string time, string name, VisitType visit)
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
