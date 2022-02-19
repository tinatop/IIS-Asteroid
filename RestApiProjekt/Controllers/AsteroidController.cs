using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiProjekt.Models;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.Serialization;
using System.IO;
using Commons.Xml.Relaxng;
using Microsoft.AspNetCore.Authorization;
using System.Xml.Linq;
using System;
using System.Xml.Serialization;

namespace RestApiProjekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidController : ControllerBase
    {
        
        public List<Asteroid> Get()
        {
            return Startup.GetAsteroid;
        }

        private bool error = false;

        [Authorize]
        [HttpPost("xsd")]
        public void PostXMl(XmlElement xmlAsteroid)
        {
            try
            {
                XmlDocument doc = xmlAsteroid.OwnerDocument;
                doc.AppendChild(xmlAsteroid);
                doc.Schemas.Add("http://schemas.datacontract.org/2004/07/RestApiProjekt.Models", "Asteroid.xsd");

                ValidationEventHandler validation = new ValidationEventHandler(XmlValidacija);
                doc.Validate(validation);

                if (!error)
                {
                    DataContractSerializer deserijalizacija = new DataContractSerializer(typeof(Asteroid));
                    MemoryStream xmlStream = new MemoryStream();
                    doc.Save(xmlStream);
                    xmlStream.Position = 0;
                    Asteroid newAsteroid = (Asteroid)deserijalizacija.ReadObject(xmlStream);
                    Startup.GetAsteroid.Add(newAsteroid);
                }
                else
                {
                    Response.StatusCode = StatusCodes.Status400BadRequest;
                }
            }
            catch
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
        [Authorize]
        [HttpPost("rng")]
        public void PostRng(XmlElement xmlAsteroid)
        {
            XmlDocument xmlDoc = xmlAsteroid.OwnerDocument;
            xmlDoc.AppendChild(xmlAsteroid);
            MemoryStream xmlStream = new MemoryStream();
            xmlDoc.Save(xmlStream);
            xmlStream.Position = 0;

            XmlReader instance = new XmlTextReader(xmlStream);
            XmlReader grammar = new XmlTextReader("Asteroid.rng");
            using (XmlReader reader = new RelaxngValidatingReader(instance,grammar))
            {
                try
                {
                    while (!reader.EOF)
                    {
                        reader.Read();
                    }
                    Startup.GetAsteroid.Add(kreairajKupca(xmlDoc));
                }
                catch
                {

                    Response.StatusCode = StatusCodes.Status400BadRequest;
                }
            }
        }

        private Asteroid kreairajKupca(XmlDocument xmlDoc)
        {
            Asteroid noviKupac = new Asteroid();
            noviKupac.Id = xmlDoc.DocumentElement.ChildNodes[0].InnerText;
            noviKupac.Name = xmlDoc.DocumentElement.ChildNodes[1].InnerText;
            noviKupac.EstimatedMinimumDiameter = xmlDoc.DocumentElement.ChildNodes[2].InnerText;
            noviKupac.EstimatedMaximumDiameter = xmlDoc.DocumentElement.ChildNodes[3].InnerText;
            noviKupac.PotentiallyHazardous = xmlDoc.DocumentElement.ChildNodes[4].InnerText;

            return noviKupac;
        }

        private void XmlValidacija(object sender, ValidationEventArgs e)
        {
            error = true;
        }
    }
}