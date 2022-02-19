/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pjaxb;

import generated.Asteroids;
import generated.Asteroids.Asteroid;
import java.io.File;
import java.util.List;
import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import org.xml.sax.SAXException;

/**
 *
 * @author User
 */
public class PJAXB {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String xmlFile = "C:\\Users\\User\\OneDrive\\Radna površina\\ii\\SOAP_servis\\SOAP_servis\\Asteroids.xsd";
        String xsdFile = "C:\\Users\\User\\OneDrive\\Radna površina\\ii\\PJAXB\\Asteroids.xsd";

        validateXML(xmlFile, xsdFile);
    }

    private static void validateXML(String xmlFile, String xsdFile) {
        JAXBContext context;

        try {
            context = JAXBContext.newInstance(Asteroids.class);

            Unmarshaller jaxbUnmarshaller = context.createUnmarshaller();
            
            
            

            SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
            Schema asSchema = sf.newSchema(new File(xsdFile));
            jaxbUnmarshaller.setSchema(asSchema);

            Asteroids asteroid = (Asteroids) jaxbUnmarshaller.unmarshal(new File(xmlFile));
            List<Asteroid> asteroids = asteroid.getAsteroid();
            for (Asteroid as : asteroids) {
                printAsteroid(as);
            }
            System.out.println("XML valid!");
        } catch (JAXBException | SAXException e) {
            System.out.println("XML is not valid!");
        }
    }

   

    private static void printAsteroid(Asteroid as) {
        System.out.println("Id: " + as.getId());
        System.out.println("Name: " + as.getName());
        System.out.println("Estimated Minimum Diameter: " + as.getEstimatedMinimumDiameter());
        System.out.println("Estimated Maximum Diameter: " + as.getEstimatedMaximumDiameter());
        System.out.println("Potentially Hazardous: " + as.getPotentiallyHazardous());
    }

}
