#r "Microsoft.WindowsAzure.Storage"

using System.Net;
// using Microsoft.WindowsAzure.Storage.Table;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log)
{
    var content = req.Content;
    var headers = req.Headers; 
    string jsonContent = content.ReadAsStringAsync().Result;
    var re = req.GetQueryNameValuePairs().Where(nv => nv.Key =="q").Select(nv => nv.Value).FirstOrDefault();
    log.Info("WHAT IS RE: ", re.ToString()); 
    var reqHeaders = req.GetQueryNameValuePairs();
    var result = $"The product name for your product id {reqHeaders} is Starfruit Explosion";
    return req.CreateResponse(HttpStatusCode.OK, result); 
}

// public class Person : TableEntity
// {
//     public string Name { get; set; }
// }
