
package xml.rpc;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.ProtocolException;
import java.net.URL;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathConstants;
import javax.xml.xpath.XPathExpressionException;
import javax.xml.xpath.XPathFactory;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;


public class Temperatura {
    
    public String temp(String nazivGrada) throws ProtocolException, IOException, ParserConfigurationException, SAXException, XPathExpressionException{
        
        String temperatura = "";
        Document xmlDoc = getXmlVrijeme();
        XPathFactory xf = XPathFactory.newInstance();
        XPath xPath = xf.newXPath();
        String expression = "/Hrvatska/Grad[GradIme='"+nazivGrada+"']";
        
        NodeList nodeList = (NodeList) xPath.compile(expression).evaluate(xmlDoc,XPathConstants.NODESET);
        
        for (int i = 0; i < nodeList.getLength(); i++) {
            Node node = nodeList.item(i);
            if (node.getNodeType() == Node.ELEMENT_NODE) {
                Element element = (Element) node;
                temperatura = element.getElementsByTagName("Temp").item(0).getTextContent();
            }
        }
        
        return temperatura;
    }

    private Document getXmlVrijeme() throws ProtocolException, IOException, ParserConfigurationException, SAXException {
        
        HttpURLConnection connection = (HttpURLConnection) new URL("https://vrijeme.hr/hrvatska_n.xml").openConnection();
        connection.setRequestMethod("GET");
        InputStream stream = connection.getInputStream();
        DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
        dbf.setNamespaceAware(false);
        Document doc = dbf.newDocumentBuilder().parse(stream);
        
        return doc;
    }
    
}
