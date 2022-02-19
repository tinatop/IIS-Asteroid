using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Model
{

    [DataContract(Namespace = "http://schemas.datacontract.org/2004/07/RestApiProjekt.Models")]
    class Asteroid
    {
        [DataMember(Order = 0)]
        public string Id { get; set; }
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public string EstimatedMinimumDiameter { get; set; }
        [DataMember(Order = 3)]
        public string EstimatedMaximumDiameter { get; set; }
        [DataMember(Order = 4)]
        public string PotentiallyHazardous { get; set; }

        public Asteroid(string id, string name, string estimatedMinimumDiameter, string estimatedMaximumDiameter, string potentiallyHazardous)
        {
            Id = id;
            Name = name;
            EstimatedMinimumDiameter = estimatedMinimumDiameter;
            EstimatedMaximumDiameter = estimatedMaximumDiameter;
            PotentiallyHazardous = potentiallyHazardous;
        }

        public Asteroid()
        {

        }
    }
}
