using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using StripeDemoApi.Models;

namespace StripeDemoApi.Controllers;

public class CustomersController : ControllerBase
{
    private readonly StripeOptions _stripeOptions;

    public CustomersController(IOptions<StripeOptions> stripeOptions)
    {
        _stripeOptions = stripeOptions.Value;
        StripeConfiguration.ApiKey = _stripeOptions.SecretKey;
    }

    [HttpPost("create-customer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreateRequest request)
    {
        var options = new CustomerCreateOptions
        {
            Email = request.Email,
            Name = request.Name,
        };
        var service = new CustomerService();
        var customer = await service.CreateAsync(options);
        return Ok(customer);
    }
}