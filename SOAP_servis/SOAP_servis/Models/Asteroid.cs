using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_servis.Models
{
    [Serializable]
    public class Asteroid
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        public string EstimatedMinimumDiameter { get; set; }
        public string EstimatedMaximumDiameter { get; set; }
        public string PotentiallyHazardous { get; set; }

        public Asteroid(string id, string name, string estimatedMinimumDiameter, string estimatedMaximumDiameter, string potentiallyHazardous)
        {
            Id = id;
            Name = name;
            EstimatedMinimumDiameter = estimatedMinimumDiameter;
            EstimatedMaximumDiameter = estimatedMaximumDiameter;
            PotentiallyHazardous = potentiallyHazardous;
        }

        
    }
}