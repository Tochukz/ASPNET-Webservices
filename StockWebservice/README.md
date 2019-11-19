# ASMS WebService

## StockWeb service
From [Tutorial Point](https://www.tutorialspoint.com/asp.net/asp.net_web_services.htm)

__To generate a proxy class for your web service__  
* Add an Empty ASP.NET Web application to the solution containing the WebService. This Web application will serve as a client to consume the webservice.
* Right-click on the newly created web application navigate to "Add" and click on "Service Reference..."  
* Click on the "Discover" button on the left side of the dialogue box.
* Select the address of your desired service from the list generated.  
* Enter a Namespace for the reference. This will be the name by which the Proxy will be identified and accessed. I entered the name "StockServiceReference" for my Namespace.
* To view the Proxy class, click on "Connected Services" under the Web Application project in the solution explorer.
* You will identify the Proxy by the Namespace you entered earlier. In my case, it will be "StockServiceReference".  
