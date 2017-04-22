using System;
namespace CircuitBreaker
{
	public class CircuiteBreakerStateStore : ICircuitBreakerStateStore
	{
		private CircuitBreakerStateEnum currentState = CircuitBreakerStateEnum.Closed;
		private Exception lastException;
		private DateTime lastStateChangedDateUtc;


		public Exception LastException
		{
			get
			{
				return lastException;
			}
		}

		public DateTime LastStateChangedDateUtc
		{
			get
			{
				return lastStateChangedDateUtc;
			}
		}

		public CircuitBreakerStateEnum State
		{
			get
			{
				return currentState;
			}
		}

		public void HalfOpen()
		{
			currentState = CircuitBreakerStateEnum.HalfOpen;
		}

		public bool IsClosed
		{
			get
			{
				if (currentState == CircuitBreakerStateEnum.Closed)
					return true;
				else if (currentState == CircuitBreakerStateEnum.Open || currentState == CircuitBreakerStateEnum.HalfOpen)
					return false;
				else
					return true;
			}
		}

		public void Reset()
		{
			currentState = CircuitBreakerStateEnum.Closed;
		}

		public void Trip(Exception ex)
		{
			currentState = CircuitBreakerStateEnum.Open;
			lastStateChangedDateUtc = DateTime.UtcNow;
			lastException = ex;
		}
	}
}