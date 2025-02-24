using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TBD.FunctionApp.Interfaces;
using TBD.FunctionApp.Models;

namespace TBD.FunctionApp.Functions;

public class GetResultFunc(IFeatureService featureService)
{
    [FunctionName("GetResultFunc")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        var x = double.Parse(req.Query["x"]);
        var y = double.Parse(req.Query["y"]);

        var useNewSystem = featureService.IsEnabled(
                Constants.SimpleFeatureFlags_NewPaymentSystem,
                defaultValue: false
            );

        if (useNewSystem)
        {
            // New Logic
            var newResult = Multiply(x,y);
            return new OkObjectResult(new
            {
                System = "Multiply",
                newResult,
                Message = "Processed by new multiply logic."
            });
        }
        else
        {
            // Old Logic
            var oldResult = Add(x,y);
            return new OkObjectResult(new
            {
                System = "Add",
                oldResult,
                Message = "Processed by old add logic."
            });
        }
    }

    private static double Add(double x, double y) => x + y;

    private static double Multiply(double x, double y) => x * y;
}
