using System;
using System.Threading;

namespace CircuitBreaker
{
	public class CircuitBreaker
	{
		private readonly ICircuitBreakerStateStore stateStore =
			CircuitBreakerStoreFactory.GetCircuitBreakerStateStore();
		private readonly object halfOpenSyncObject = new object();
		private TimeSpan OpenToHalfOpenWaitTime = new TimeSpan(0, 1, 0);

		public bool IsClosed { get { return stateStore.IsClosed; } }

		public bool IsOpen { get { return !IsClosed; } }

		public void ExecuteAction(Action action)
		{
			if (IsOpen)
			{
				// The Circuit Breaker is Open.

				// The circuit breaker is Open. Check if the Open timeout has expired.
				// If it has, set the state to HalfOpen. Another approach might be to
				// check for the HalfOpen state that had be set by some other operation.
				if (stateStore.LastStateChangedDateUtc + OpenToHalfOpenWaitTime < DateTime.UtcNow)
				{

					Console.WriteLine("We have waited long enough");

					// The Open timeout has expired. Allow one operation to execute. Note that, in
					// this example, the circuit breaker is set to HalfOpen after being
					// in the Open state for some period of time. An alternative would be to set
					// this using some other approach such as a timer, test method, manually, and
					// so on, and check the state here to determine how to handle execution
					// of the action.
					// Limit the number of threads to be executed when the breaker is HalfOpen.
					// An alternative would be to use a more complex approach to determine which
					// threads or how many are allowed to execute, or to execute a simple test
					// method instead.

					bool lockTaken = false;
					try
					{
						Monitor.TryEnter(halfOpenSyncObject, ref lockTaken);
						if (lockTaken)
						{
							// Set the circuit breaker state to HalfOpen.
							stateStore.HalfOpen();

							// Attempt the operation.
							action();

							// If this action succeeds, reset the state and allow other operations.
							// In reality, instead of immediately returning to the Closed state, a counter
							// here would record the number of successful operations and return the
							// circuit breaker to the Closed state only after a specified number succeed.
							this.stateStore.Reset();
							return;
						}
					}
					catch (Exception ex)
					{
						// If there's still an exception, trip the breaker again immediately.
						this.stateStore.Trip(ex);

						// Throw the exception so that the caller knows which exception occurred.
						throw;
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(halfOpenSyncObject);
						}
					}
				}

				// The Open timeout hasn't yet expired. Throw a CircuitBreakerOpen exception to
				// inform the caller that the call was not actually attempted,
				// and return the most recent exception received.
				throw new CircuitBreakerOpenException(stateStore.LastException);

			}

			// The Circuit Breaker is Closed, execute the action
			try
			{
				Console.WriteLine("The Circuit Breaker is Closed, executing the action");
				action();
			}
			catch (Exception ex)
			{
				// If an exception still occurs here, simply
				// retrip the breaker immediately
				this.TrackException(ex);

				// Throw the exeption so that the caller can tell
				// the type of exception that was thrown.
				throw;
			}
		}

		void TrackException(Exception ex)
		{
			// For simplicity in this example, open the circuit breaker on the first exception.
			// In reality this would be more complex. A certain type of exception, such as one
			// that indicates a service is offline, might trip the circuit breaker immediately.
			// Alternatively it might count exceptions locally or across multiple instances and
			// use this value over time, or the exception/success ratio based on the exception
			// types, to open the circuit breaker.
			this.stateStore.Trip(ex);
		}
	}
}