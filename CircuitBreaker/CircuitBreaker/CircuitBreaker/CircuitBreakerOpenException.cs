using System;
using System.Runtime.Serialization;

namespace CircuitBreaker
{
	[Serializable]
	class CircuitBreakerOpenException : Exception
	{
		public CircuitBreakerOpenException()
		{
		}

		public CircuitBreakerOpenException(string message) : base(message)
		{
		}

		public CircuitBreakerOpenException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected CircuitBreakerOpenException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}