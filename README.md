# Stripe Demo API (.NET 9)

This is a sample backend project built with .NET 9 Web API that demonstrates a basic integration with the Stripe payment platform. It provides several endpoints to manage common payment-related tasks.

## Features

* **Create Payment Intents**: Initiate a payment process.
* **Retrieve Payment Intents**: Get the status and details of a specific payment.
* **Customer Management**: Create and manage Stripe Customer objects.


## Prerequisites

Before you begin, ensure you have the following installed:

* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
* A [Stripe Account](https://dashboard.stripe.com/register) to get your API keys.

## Setup & Configuration

1.  **Clone the repository:**
    ```bash
    git clone <your-repository-url>
    cd StripeDemoApi
    ```

2.  **Configure API Keys:**
    Open the `appsettings.json` file and update the `Stripe` section with your keys from the Stripe Dashboard.

    ```json
    {
      // ...
      "Stripe": {
        "SecretKey": "sk_test_...",
        "PublishableKey": "pk_test_...",
        "WebhookSecret": "whsec_..."
      }
    }
    ```
    > **Important:** For a real application, use a secure method like the .NET Secret Manager or an environment variable to store your secret keys. Do not commit them directly to your repository. The Webhook Secret is obtained when you set up a webhook endpoint in your Stripe Dashboard.

## How to Run

1.  Navigate to the project's root directory in your terminal.
2.  Run the application using the following command:
    ```bash
    dotnet run
    ```
3.  The API will be available at `https://localhost:<port>`, where `<port>` is typically between 5001 and 7999.

## API Endpoints

### Payments

* **Create Payment Intent**
    * **Endpoint:** `POST /api/payments/create-payment-intent`
    * **Description:** Creates a new Payment Intent to initiate a payment.
    * **Body:**
        ```json
        {
          "amount": 2000
        }
        ```

* **Retrieve Payment Intent**
    * **Endpoint:** `GET /api/payments/retrieve-payment-intent/{id}`
    * **Description:** Retrieves the details of a specific Payment Intent.
    * **Example:** `GET /api/payments/retrieve-payment-intent/pi_...`

* **Create Customer**
    * **Endpoint:** `POST /api/payments/create-customer`
    * **Description:** Creates a new customer in your Stripe account.
    * **Body:**
        ```json
        {
          "email": "customer@example.com",
          "name": "John Doe"
        }
        ```
