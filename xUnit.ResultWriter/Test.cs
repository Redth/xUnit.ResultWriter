namespace Xunit.ResultWriter
{
	public class Test
	{
		/// <summary>
		/// The display name of the test.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The fully qualified type name of the class that contained the test.
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// The name of the method that contained the test.
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// The number of seconds the test run took, in decimal format.
		/// </summary>
		public decimal Time { get; set; }

		/// <summary>
		/// The result of the test. Valid values include Pass, Fail, and Skip.
		/// </summary>
		public ResultType Result { get; set; }

		public Failure Failure { get; set; }
	}
}
