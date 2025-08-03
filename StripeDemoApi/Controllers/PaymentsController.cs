using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using StripeDemoApi.Models;

namespace StripeDemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly StripeOptions _stripeOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentsController"/> class.
    /// </summary>
    /// <param name="stripeOptions">The Stripe configuration options, injected via the Options Pattern.</param>
    public PaymentsController(IOptions<StripeOptions> stripeOptions)
    {
        _stripeOptions = stripeOptions.Value;
        StripeConfiguration.ApiKey = _stripeOptions.SecretKey;
    }

    /// <summary>
    /// Creates a new Stripe Payment Intent.
    /// </summary>
    /// <param name="request">The request body containing the payment amount.</param>
    /// <returns>An IActionResult containing the client secret of the created Payment Intent.</returns>
    [HttpPost("create-payment-intent")]
    public async Task<IActionResult> CreatePaymentIntent([FromBody] PaymentIntentRequest request)
    {
        var options = new PaymentIntentCreateOptions
        {
            Amount = request.Amount,
            Currency = "usd",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true,
            },
        };

        var service = new PaymentIntentService();
        var paymentIntent = await service.CreateAsync(options);

        return Ok(new { clientSecret = paymentIntent.ClientSecret });
    }

    /// <summary>
    /// Endpoint to retrieve information about a payment intent
    /// </summary>
    /// <param name="id">Id of the payment to retrieve.</param>
    /// <returns>Returns the payment intent information</returns>
    [HttpGet("retrieve-payment-intent/{id}")]
    public async Task<IActionResult> RetrievePaymentIntent(string id)
    {
        var service = new PaymentIntentService();
        try
        {
            var paymentIntent = await service.GetAsync(id);
            return Ok(paymentIntent);
        }
        catch (StripeException e)
        {
            return BadRequest(new { error = new { message = e.Message } });
        }
    }
}