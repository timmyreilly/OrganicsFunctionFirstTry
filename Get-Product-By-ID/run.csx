#r "Microsoft.WindowsAzure.Storage"

using System.Net;
// using Microsoft.WindowsAzure.Storage.Table;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    var content = req.Content;
    var headers = req.Headers;
    string jsonContent = content.ReadAsStringAsync().Result;
    string requestBody = await req.Content.ReadAsStringAsync();
    log.Info("what we got: ", requestBody);
    // var re = req.GetQueryNameValuePairs().Where(nv => nv.Key == "q").Select(nv => nv.Value).FirstOrDefault();
    // log.Info("WHAT IS RE: ", re.ToString());
    var reqHeaders = req.GetQueryNameValuePairs();
    foreach (var x in reqHeaders){
        log.Info(x.ToString()); 
    }
    var productId = reqHeaders.ToString(); 
    var result = $"The product name for your product id {productId} from {reqHeaders} is Starfruit Explosion";
    return req.CreateResponse(HttpStatusCode.OK, result);
}

// public class Person : TableEntity
// {
//     public string Name { get; set; }
// }
