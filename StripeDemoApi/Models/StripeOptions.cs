namespace StripeDemoApi.Models;

/// <summary>
/// Represents the configuration options for Stripe.
/// </summary>
public class StripeOptions
{
    // The key that corresponds to the section in appsettings.json.
    public const string Stripe = "Stripe";

    /// <summary>
    /// Gets or sets the Stripe secret key.
    /// </summary>
    public string SecretKey { get; set; }

    /// <summary>
    /// Gets or sets the Stripe client key.
    /// </summary>
    public string ClientKey { get; set; }
}