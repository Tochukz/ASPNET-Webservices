## Part 1: Introduction to ASP.NET Web Services
Web Services have `.asmx` extension. For this reason web services are also often called "ASMX Web Services"

A Web Service is a class that is decorated with `[WebService]` attribute and inherits from `System.Web.Services.WebService` base class.
The `[WebService]` attribute tells that the the class contains the code for a web service.

WebService Namespace is used to uniquely identify your web service on the internet from other services that are already there in the Web. WebService Namespace can be any string but it is common to give it a company's internet domain name as they are usually unique. Something like `[WebService(Namespace= "http:// mywebstation.net/websevices")]`

It is not mandatory for a web service to inherit form `System.Web.Sevices.WebService` base class. However, if the web service has to use ASP.NET Session or application state objects, then inheriting from `System.Web.Services.WebService` base class will provide direct access to these ASP.NET objects.

To allow a web service method be called from JavaScript, using ASP.NET AJAX, then you must deocrate the web service class with `[System.Web.Script.Services.ScriptService]` attribute.

If you want a method to be exposed as part of the Web service, then the method must be `public` and should be decorated with `[WebMethod]` attribute. This attribute has got several properties which can be used to configure the behavior of the XML Web service Method.
```
[WebMethod]
public string HelloWorld()
{
  return "Hello World";
}
```

SOAP 1.2 is a new version with some major changes from SOAP 1.1.

__Creating an ASMX WebService__
* Open of Visual studio
* Create an Empty "ASP.NET Web Application"
* Create an Web Service template file (.asmx)
* You will find a generated code in you web service file.

## Part 2: consuming a Web Service  
To consume a web service, you generate a proxy class in Visual Studio using the web service's WSDL document.
__Generating a Proxy class using Visual studio__
* First get the link to the WSDL document.
 * Right click on the Web Servvice `.asmx` file and click "View in Browser"
 * Goto the Browser and click on "Service Description"
 * Copy the URL of the WSDL document from the browser location bar
* Add an ASP.NET Web Application to the solution containing the webservice. This application will be the client to consume the web services.
* Click on the Client application in the Solution explorer.
* Right-click on `Reference` and click   `Add service Reference`
* Enter the URL of the WSDL document obtained earlier on to the address input and click on "Go" and the web service will be detected by Visual studio
* Enter a Namespace for the Service reference and click "Ok"
* Visual studio will then generate a Proxy class based on the WSDL document
* To see the Proxy class
  * Select the Client Application and then click on the "Show all files" tab in the Solution explorer
  * Then click on "Connected Service" -> The Service ReferenceName -> "Reference.cs"
* When a request is made by the client, it goes to the Proxy class and the Proxy class serializes the request and forwards it to the actual Web Service.
* The Web service responds with a soap message to the Proxy class, which deserializes the response and forward it to the client.

__Questions__  
1. What is WSDL and what is it's purpose
2. How is a proxy class generated
3. What is the use of a proxy class
4. What actually happens when a web service reference is added  

__Answers__  
Visual studio generates a proxy class using the WSDL (Web Service Description Language) document of the web service. The WSDL document formally defines web service. It contains
1. All the methods that are exposed by the web services
2. The parameters and their types
3. The return types of the methods  

This information is then used by visual studio to create the proxy class. The client application calls the proxy class method. The proxy class will then serialize the parameters, prepare a SOAP request message and sends it to the webservice. The webservice execusted the method and returns a SOAP response message to the proxy, The proxy class will then deserialize the SOAP response message and hands it the client application.

## Part 3:  Using ASP.NET Session Sate in a Web Service  
To use ASP.NET Session object in a Web Service, the web service class must inherit from `System.Web.Services.webService` class and `EnableSession` property of `WebMethod` attribute must be set to `true`.
```
[WebService(Namespace="http://mywebstation.net")]
public class CalculatorWebService :System.Web.Services.WebService
{
  [WebMethod(EnableSession=true)]
  public int Add(nint fisrtNumber, int secondNumber)
  {
    return firstNumber + secondNumber;
  }
}
```
Set `allowCookies` to `true` in the `Web.config` file of the client Web Application.
```
  ...
  <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding name="CalculatorWebServiceSoap" allowCookies="true">
  ...
```
If the Webservice code changes, the Proxy class will needs to be updated. This is done by updating the service reference:
* Click on the Client application on the Solution explorer
* Click on "ConnectionService"
* Right-click on the ServiceReferenceName e.g `CalculatorService`
* Click on "Update Service Reference"
* This will update the proxy class for code changes in the webservice.

## Part 4: WebMethod attribute properties  
* __Description__ -  Use to specify a description for the web service method.
* __BufferResponse__ - This is a boolean property. Default is true. When this property is true, the response of the XML Webservice method is not returned to the client until either the response is completely serialized or the buffer is full.

On the other hand, when this property is false, the response of the XML Web Service method is returned to the client as it is being serialized.

In general, set BufferResponse to false, only when the XML Web Service method returns large amount of data. For small amounts of data, web service performance is better when BufferRepons is set to true

* __CacheDuration__ - Use this property, if you want to cache the results of  web service method. This is an integer property, and specifies the number of seconds that the response should be cached. A response is cached for each unique parameter.

## Part 5: WebMethod overloading in ASP.NET Web Services  
 Methos overloading allows a class to have multiple methods with the same name, but with different signature. So, in C#, methods can be overloaded based on the number, type(int, float, etc) and the kind (value, Ref, or Out) of parameters.

 WebMethods in a web service can also be overloaded, using MessageName property. This property is used to uniquely indentify the individual XML Webservice WebMethods
 ```
 [WebMethod(MessageName="Add2Numbers")]
 public int Add(int firstNumber, int secondNumber)
 {
   return firstNumber + secondNumber;
 }
 [WebMethod]
 public int Add(int forstNumber, int secondNumber, int thirdNumber)
 {
   retur  firstNumber + secondNumber + thirdNumber;
 }
 ```
 Set the value of the `ConformsTo` property of the `WebServiceBinding`  attribute of the Webservice class to `WsiProfiles.None`
```
  [WebServiceBinding(ConformsTo = WsiProfiles.None)]
```
 If you don't specify the MessageName of a WebMethod, then the MessageName of the WebMethod becomes the method name by default.

## Part 6: Calling ASP.NET Web Service from JavaScript using AJAX  
