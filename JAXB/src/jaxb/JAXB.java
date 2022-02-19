package jaxb;

import generated.Kupci;
import generated.Kupci.Kupac;
import java.io.File;
import java.util.List;
import javax.xml.XMLConstants;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import org.xml.sax.SAXException;


public class JAXB {

    public static void main(String[] args) {
        
        String xmlFile = "C:\\Users\\User\\OneDrive\\Radna površina\\ii\\SOAP_servis\\SOAP_servis\\Asteroids.xsd";
        String xsdFile = "C:\\Users\\User\\OneDrive\\Radna površina\\ii\\JAXB\\Asteroids.xsd";
        
        validateXML(xmlFile,xsdFile);
    }

    private static void validateXML(String xmlFile, String xsdFile) {
        JAXBContext context;
        try
        {
            context = JAXBContext.newInstance(Kupci.class);
            
            Unmarshaller jaxbUnmarshaller = context.createUnmarshaller();
            
            SchemaFactory sf = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
            Schema kupciSchema = sf.newSchema(new File(xsdFile));
            jaxbUnmarshaller.setSchema(kupciSchema);
            
            Kupci kupac = (Kupci) jaxbUnmarshaller.unmarshal(new File(xmlFile));
            List<Kupac> kupci = kupac.getKupac();
            for(Kupac kup : kupci){
                printKupac(kup);
            }
            System.out.println("XML valid!");
        }
        catch(JAXBException |SAXException e)
        {
            System.out.println("XML is not valid!");
        }
    }

    private static void printKupac(Kupac kup) {
        System.out.println("Ime: "+kup.getIme());
        System.out.println("Email: "+kup.getEmail());
        System.out.println("Broj mobitela: "+kup.getBrojMobitela());
        System.out.println("Adresa: "+kup.getAdresa());
        System.out.println("OIB: "+ kup.getOIB());
        System.out.println("------------------");
    }

   
}
