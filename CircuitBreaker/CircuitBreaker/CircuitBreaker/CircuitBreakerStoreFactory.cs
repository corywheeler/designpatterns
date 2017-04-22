namespace CircuitBreaker
{

	class CircuitBreakerStoreFactory
	{
		public static ICircuitBreakerStateStore GetCircuitBreakerStateStore()
		{
			return new CircuiteBreakerStateStore();
		}
	}
}