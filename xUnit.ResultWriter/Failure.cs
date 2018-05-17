namespace Xunit.ResultWriter
{
	public class Failure
	{
		/// <summary>
		/// The fully qualified type name of the exception that caused the failure.
		/// </summary>
		public string ExceptionType { get; set; }

		public string Message { get; set; }

		public string StackTrace { get; set; }
	}
}
