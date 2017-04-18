using System;

namespace CircuitBreaker
{
	public interface ICircuitBreakerStateStore
	{
		CircuitBreakerStateEnum State { get; }

		Exception LastException { get; }

		DateTime LastStateChangedDateUtc { get; }

		void Trip(Exception ex);

		void Reset();

		void HalfOpen();

		bool IsClosed();
	}
}