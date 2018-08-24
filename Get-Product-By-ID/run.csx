#r "Microsoft.WindowsAzure.Storage"

using System.Net;
// using Microsoft.WindowsAzure.Storage.Table;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    var content = req.Content;
    var headers = req.Headers;
    string jsonContent = content.ReadAsStringAsync().Result;
    string requestBody = await req.Content.ReadAsStringAsync();

    var reqHeaders = req.GetQueryNameValuePairs();
    // var theParams; 
    var theParams = new KeyValuePair<string, string>();
    log.Info("reqHeaders: " + reqHeaders);
    Dictionary<string, string> paramDictionary = new Dictionary<string, string>();
    foreach (KeyValuePair<string, string> x in reqHeaders)
    {
        log.Info("Key: " + x.Key);
        log.Info("Value: " + x.Value);
        paramDictionary.Add(x.Key, x.Value);

    }
    var pDictionary = reqHeaders.ToDictionary(y => y.Key, y => y.Value); 
    log.Info(pDictionary.Keys.ToString()); 
    // log.Info(paramDictionary.First());
    log.Info(paramDictionary.ToString());
    
    var result = $"The product name for your product id {theParams.ToString()} from {reqHeaders} is Starfruit Explosion";
    return req.CreateResponse(HttpStatusCode.OK, result);
}

// public class Person : TableEntity
// {
//     public string Name { get; set; }
// }
