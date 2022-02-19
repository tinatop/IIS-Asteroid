using SOAP_servis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace SOAP_servis
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class FinderServis : System.Web.Services.WebService
    {
        internal static List<Asteroid> GetAsteroids;
        XmlDocument xmlDoc;

        public FinderServis()
        {

            GetAsteroids = new List<Asteroid>();
            Asteroid a1 = new Asteroid("12", "A12", "0.11", "0.12", "Yes");
            Asteroid a2 = new Asteroid("13", "B13", "0.02", "0.1", "No");
            GetAsteroids.Add(a1);
            GetAsteroids.Add(a2);
            xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Asteroids");
            xmlDoc.AppendChild(root);
            foreach (var asteroid in GetAsteroids)
            {
                XmlElement child = xmlDoc.CreateElement("Asteroid");
                XmlElement id = xmlDoc.CreateElement("Id");
                id.InnerText = asteroid.Id;
                child.AppendChild(id);
                XmlElement name = xmlDoc.CreateElement("Name");
                name.InnerText = asteroid.Name;
                child.AppendChild(name);
                XmlElement eMinD = xmlDoc.CreateElement("EstimatedMinimumDiameter");
                eMinD.InnerText = asteroid.EstimatedMinimumDiameter;
                child.AppendChild(eMinD);
                XmlElement eMaxD = xmlDoc.CreateElement("EstimatedMaximumDiameter");
                eMaxD.InnerText = asteroid.EstimatedMaximumDiameter;
                child.AppendChild(eMaxD);
                XmlElement ph = xmlDoc.CreateElement("PotentiallyHazardous");
                ph.InnerText = asteroid.PotentiallyHazardous;
                child.AppendChild(ph);
                root.AppendChild(child);
            }
            xmlDoc.Save("C:\\Users\\User\\OneDrive\\Radna površina\\ii\\SOAP_servis\\Asteroid.xml");
        }
        [WebMethod]
        public XmlNode Find(string word)
        {
            XmlNode asteroid = xmlDoc.SelectSingleNode("/Asteroids/Asteroid[Id='" + word+"']");

            return asteroid;
        }
    }
}
