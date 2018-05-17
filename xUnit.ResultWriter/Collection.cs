using System.Collections.Generic;
using System.Linq;

namespace Xunit.ResultWriter
{
	public class Collection
	{
		/// <summary>
		/// The name of the test collection.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The number of seconds the test collection run took, in decimal format.
		/// </summary>
		public decimal Time { get; set; }

		/// <summary>
		/// The total number of test cases run in the test collection.
		/// </summary>
		public int Total => TestItems.Count;

		/// <summary>
		/// The total number of test cases in the test collection which passed.
		/// </summary>
		public int Passed => TestItems.Count(t => t.Result == ResultType.Pass);

		/// <summary>
		/// The total number of test cases in the test collection which failed.
		/// </summary>
		public int Failed => TestItems.Count(t => t.Result == ResultType.Fail);

		/// <summary>
		/// The total number of test cases in the test collection that were skipped.
		/// </summary>
		public int Skipped => TestItems.Count(t => t.Result == ResultType.Skip);

		public List<Test> TestItems { get; set; } = new List<Test>();
	}
}
