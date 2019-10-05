using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpSpeed
{
    /// <summary>
    /// Class for testing the speed that methods run.
    /// </summary>
    public class SpeedTester
    {
        /// <summary>
        /// Delegate of the method to run.
        /// </summary>
        private readonly Delegate methodDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedTester"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="methodDescription"></param>
        /// <param name="testCases"></param>
        public SpeedTester(MethodInfo method, string methodDescription, Dictionary<object[], TestCaseResults> testCases)
        {
            Method = method;
            methodDelegate = CreateDelegate(Method);
            MethodDescription = methodDescription;
            TestCases = testCases;
            var sourceInfo = Method.GetCustomAttribute<SourceCodeLocationProviderAttribute>(true);
            FileName = MakeRelative(sourceInfo.File, Environment.CurrentDirectory);
            LineNumber = sourceInfo.Line;
            Member = sourceInfo.Member;
            MethodCode = GetMethodCode(FileName, LineNumber);
        }

        /// <summary>
        /// Gets the method.
        /// </summary>
        [DisplayName("Method Info")]
        public MethodInfo Method { get; private set; }

        /// <summary>
        /// Gets or sets the method description.
        /// </summary>
        [DisplayName("Method Description")]
        public string MethodDescription { get; set; }

        /// <summary>
        /// Gets the method code.
        /// </summary>
        [DisplayName("Method Source Code")]
        public string MethodCode { get; private set; }

        /// <summary>
        /// Gets the file name.
        /// </summary>
        [DisplayName("Test case Filename")]
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the member.
        /// </summary>
        [DisplayName("Tested Member")]
        public string Member { get; private set; }

        /// <summary>
        /// Gets the line number.
        /// </summary>
        [DisplayName("Method Line Number")]
        public int LineNumber { get; private set; }

        /// <summary>
        /// Gets or sets the test case.
        /// </summary>
        public Dictionary<object[], TestCaseResults> TestCases { get; }

        /// <summary>
        /// Runs trials of the method delegate a specified number of times.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RunTest()
        {
            var watch = new Stopwatch();

            foreach (var testCase in TestCases)
            {
                // Run once before timing, to make sure it is compiled.
                testCase.Value.ReturnValue = methodDelegate.DynamicInvoke(testCase.Key);

                // Run garbage collection to try to keep each test in about the same conditions. 
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                //GC.TryStartNoGCRegion(15728640);
                //GC.TryStartNoGCRegion(268435456);

                // Putting into low latency mode to try to prevent garbage collection in the middle of tests.
                var oldMode = GCSettings.LatencyMode;
                RuntimeHelpers.PrepareConstrainedRegions();
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;

                // Indenting for clarity of where the testing is occurring.
                {
                    watch.Reset();
                    watch.Start();
                    for (var i = 0; i < testCase.Value.Trials; i++)
                    {
                        // Run the method
                        testCase.Value.ReturnValue = methodDelegate.DynamicInvoke(testCase.Key);
                    }
                    watch.Stop();
                }

                // Restoring the latency mode.
                GCSettings.LatencyMode = oldMode;
                //GC.EndNoGCRegion();

                testCase.Value.TotalRunningTime = (int)watch.ElapsedNanoSeconds();
                //testCase.Value.TotalRunningTime = (int)watch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Create the delegate.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The <see cref="Delegate"/>.</returns>
        /// <exception cref="ArgumentNullException">method</exception>
        /// <exception cref="ArgumentException">method</exception>
        /// <exception cref="ArgumentException">method</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Delegate CreateDelegate(MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (!method.IsStatic)
            {
                throw new ArgumentException("The provided method must be static.", nameof(method));
            }

            if (method.IsGenericMethod)
            {
                throw new ArgumentException("The provided method must not be generic.", nameof(method));
            }

            return method.CreateDelegate(Expression.GetDelegateType(
                (from parameter in method.GetParameters() select parameter.ParameterType)
                .Concat(new[] { method.ReturnType })
                .ToArray()));
        }

        /// <summary>
        /// The make relative.
        /// </summary>
        /// <param name="filePath">The filePath.</param>
        /// <param name="referencePath">The referencePath.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string MakeRelative(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(referencePath);
            var uri = referenceUri.MakeRelativeUri(fileUri).ToString().Replace('/', Path.DirectorySeparatorChar);
            return $"..{Path.DirectorySeparatorChar}{uri}";
        }

        /// <summary>
        /// Get the method code.
        /// </summary>
        /// <param name="fileName">The fileName.</param>
        /// <param name="lineNumber">The lineNumber.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetMethodCode(string fileName, int lineNumber)
        {
            var sb = new StringBuilder();
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            using (var fileStream = File.Open(path, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                for (var i = 0; i < lineNumber; ++i)
                {
                    reader.ReadLine();
                }
                var line = string.Empty;
                while (!reader.EndOfStream && !((line = reader.ReadLine()) is null))
                {
                    sb.AppendLine(line);
                    if (line == "        }" || line == "		}")
                    {
                        break;
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get the method code.
        /// </summary>
        /// <param name="fileName">The fileName.</param>
        /// <param name="lineNumber">The lineNumber.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetMethodCodeSignature(string fileName, int lineNumber)
        {
            var sb = new StringBuilder();
            var path = Path.Combine(Environment.CurrentDirectory, fileName);
            using (var fileStream = File.Open(path, FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {
                for (var i = 0; i < lineNumber; ++i)
                {
                    reader.ReadLine();
                }
                sb.Append(reader.ReadLine());
            }
            return sb.ToString();
        }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Dictionary<object[], string> ToResultsString()
        {
            var sb = new Dictionary<object[], string>();
            foreach (var testcase in TestCases)
            {
                var equivalency = testcase.Equivalency();
                sb.Add(testcase.Key, $"| [{Member}({testcase.Key.ArrayToString()})](#{((DisplayNameAttribute)Method?.GetCustomAttribute(typeof(DisplayNameAttribute)))?.DisplayName.Replace(" ", "-")}) | {(equivalency=="!="?"<span style = \"color: red;\" >": "<span style = \"color: green;\">")} {testcase.Value.ReturnValue.ObjectValueToString()} { "</span>" } {equivalency} {testcase.Value.ExpectedReturnValue.ObjectValueToString()} | {testcase.Value.Trials} in {testcase.Value.TotalRunningTime} ns. {testcase.Value.AverageRunningTime:R} ns. average | {testcase.Value.Description} |");
            }
            return sb;
        }
    }
}
