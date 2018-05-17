namespace Xunit.ResultWriter
{
	public class Error
	{
		/// <summary>
		/// The name of the item that caused the failure.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// A code which indicates what kind of failure it is.
		/// </summary>
		public string Type { get; set; }

		public Failure Failure { get; set; }
	}
}
