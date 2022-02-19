
package xml.rpc;

import java.io.IOException;
import org.apache.xmlrpc.XmlRpcException;
import org.apache.xmlrpc.server.PropertyHandlerMapping;
import org.apache.xmlrpc.server.XmlRpcServerConfigImpl;
import org.apache.xmlrpc.webserver.WebServer;

public class XMLRPC {

    public static void main(String[] args) throws IOException, XmlRpcException {
        
        WebServer server = new WebServer(8080);
        PropertyHandlerMapping phm = new PropertyHandlerMapping();
        phm.addHandler("Temperatura", Temperatura.class);
        server.getXmlRpcServer().setHandlerMapping(phm);
        
        XmlRpcServerConfigImpl serverConfig = (XmlRpcServerConfigImpl) server.getXmlRpcServer().getConfig();
        serverConfig.setEnabledForExtensions(true);
        
        
        server.start();
        
        System.out.println("Server ready");
    }
    
}
