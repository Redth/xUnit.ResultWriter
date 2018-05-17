using System.Collections.Generic;
using System.Linq;

namespace Xunit.ResultWriter
{
	public class Assembly
	{
		/// <summary>
		/// The fully qualified path name of the test assembly.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The fully qualified path name of the test assembly configuration file.
		/// </summary>
		public string ConfigFile { get; set; }

		/// <summary>
		/// The display name of the test framework that ran the tests.
		/// </summary>
		public string TestFramework { get; set; }

		/// <summary>
		/// The runtime environment in which the tests were run.
		/// </summary>
		public string Environment { get; set; }

		/// <summary>
		/// The date when the test run started, in yyyy-mm-dd format.
		/// </summary>
		public string RunDate { get; set; }

		/// <summary>
		/// The time when the test run started, in 24-hour hh:mm:ss format.
		/// </summary>
		public string RunTime { get; set; }

		/// <summary>
		/// The number of seconds the assembly run took, in decimal format.
		/// </summary>
		public decimal Time => CollectionItems.Sum(c => c.Time);

		/// <summary>
		/// The total number of test cases run in the assembly.
		/// </summary>
		public int Total =>
			CollectionItems.Sum(c => c.Total);

		/// <summary>
		/// The total number of test cases in the assembly which passed.
		/// </summary>
		public int Passed =>
			CollectionItems.Sum(c => c.Passed);

		/// <summary>
		/// The total number of test cases in the assembly which failed.
		/// </summary>
		public int Failed =>
			CollectionItems.Sum(c => c.Failed);

		/// <summary>
		/// The total number of test cases in the assembly that were skipped.
		/// </summary>
		public int Skipped =>
			CollectionItems.Sum(c => c.Skipped);

		/// <summary>
		/// The total number of environmental errors experienced in the assembly.
		/// </summary>
		public int Errors =>
			ErrorItems.Count;

		public List<Error> ErrorItems { get; set; } = new List<Error>();

		public List<Collection> CollectionItems { get; set; } = new List<Collection>();
	}
}
