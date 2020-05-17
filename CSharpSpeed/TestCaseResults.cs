using System.ComponentModel;

namespace CSharpSpeed
{
    /// <summary>
    /// The test case class.
    /// </summary>
    public class TestCaseResults
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestCaseResults" /> class.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="trials">The trials.</param>
        /// <param name="expectedReturnValue">The expectedReturnValue.</param>
        /// <param name="epsilon">The epsilon.</param>
        public TestCaseResults(string description, int trials, object expectedReturnValue, double epsilon = 0)
        {
            _ = epsilon;
            Trials = trials;
            Description = description;
            ExpectedReturnValue = expectedReturnValue;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DisplayName("Test Case Description")]
        public string Description { get; private set; }

        /// <summary>
        /// Gets the trials.
        /// </summary>
        /// <value>
        /// The trials.
        /// </value>
        [DisplayName("Number of Trials")]
        public int Trials { get; private set; }

        /// <summary>
        /// Gets the total nanoseconds it took to run the method trials.
        /// </summary>
        /// <value>
        /// The total running time.
        /// </value>
        [DisplayName("Total Running Time")]
        public int? TotalRunningTime { get; set; } = null;

        /// <summary>
        /// Gets the total time over the number of trials.
        /// </summary>
        /// <value>
        /// The average running time.
        /// </value>
        [DisplayName("Average Running Time")]
        public double? AverageRunningTime => (double)TotalRunningTime / Trials;

        /// <summary>
        /// Gets the expected return value.
        /// </summary>
        /// <value>
        /// The expected return value.
        /// </value>
        [DisplayName("Expected Return Value")]
        public object ExpectedReturnValue { get; private set; }

        /// <summary>
        /// Gets the value that the method returns.
        /// </summary>
        /// <value>
        /// The return value.
        /// </value>
        [DisplayName("Actual Return Value")]
        public object ReturnValue { get; set; } = null;

        /// <summary>
        /// Gets the epsilon.
        /// </summary>
        /// <value>
        /// The epsilon.
        /// </value>
        [DisplayName("The smallest amount of change.")]
        public double Epsilon { get; private set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public override string ToString() => $"| {Description} | {Trials} | {TotalRunningTime} ms | {AverageRunningTime:R} ms | {ExpectedReturnValue} | {ReturnValue} |";
    }
}
