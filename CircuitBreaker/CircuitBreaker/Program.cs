using System;
using System.Threading;
using RestSharp;

namespace CircuitBreaker
{
	class MainClass
	{
		// Inspiration coming from:
		// https://docs.microsoft.com/en-us/azure/architecture/patterns/circuit-breaker#example

		public static void Main(string[] args)
		{
			var serverAddress = "http://localhost:5001";

			var client = new RestClient(serverAddress);
			var request = new RestRequest("circuit-breaker", Method.GET);
			var breaker = new CircuitBreaker();
			var desiredCallsToRemoteServer = 30;
			var actualCallsToRemoteServer = 0;

			for (int i = 1; i <= desiredCallsToRemoteServer; i++)
			{
				try
				{
					Console.WriteLine("\nAttempting call #{0} to server.", i);

					breaker.ExecuteAction(() =>
					{
						// Operation protected by the circuit breaker.

						actualCallsToRemoteServer++;

						Console.WriteLine("\nExecuting call #{0} to server", actualCallsToRemoteServer);

						IRestResponse response = client.Execute(request);

						Console.WriteLine("Response was: {0}. Status Code was {1}", response.Content, response.StatusCode);

						if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
						{
							throw new BadRequestException(string.Format("Received a bad request back, triping Circuit Breaker: {0}",
															  response.StatusCode));
						}
					});
				}
				catch (CircuitBreakerOpenException ex)
				{
					// Perform some different action when the breaker is open.
					// Last exception details are in the inner exception.
					Console.WriteLine("\n\n{0}", ex);
				}
				catch (Exception ex)
				{
					Console.WriteLine("\n\nCatch All Exeption: \n{0}", ex);
				}

				Thread.Sleep(5000);
			}

			Console.WriteLine("==============================================================");
			Console.WriteLine("\nDesired calls to remote: {0}", desiredCallsToRemoteServer);
			Console.WriteLine("Calls allowed by Circuit Breaker: {0}", actualCallsToRemoteServer);
		}
	}
}