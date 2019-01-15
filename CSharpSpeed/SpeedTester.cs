using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
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
        public Dictionary<object[], TestCaseResults> TestCases { get; set; }

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

                testCase.Value.TotalRunningTime = (int)watch.ElapsedMilliseconds;
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
                throw new ArgumentNullException("method");
            }

            if (!method.IsStatic)
            {
                throw new ArgumentException("The provided method must be static.", "method");
            }

            if (method.IsGenericMethod)
            {
                throw new ArgumentException("The provided method must not be generic.", "method");
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
                sb.Add(testcase.Key, $"| [{Member}({testcase.Key.ArrayToString()})](#{((DisplayNameAttribute)Method?.GetCustomAttribute(typeof(DisplayNameAttribute)))?.DisplayName.Replace(" ", "-")}) | {ObjectValueToString(testcase.Value.ReturnValue)} {Equivalency(testcase)} {ObjectValueToString(testcase.Value.ExpectedReturnValue)} | {testcase.Value.Trials} in {testcase.Value.TotalRunningTime} ms. {testcase.Value.AverageRunningTime:R} ms. average | {testcase.Value.Description} |");
            }
            return sb;
        }

        /// <summary>
        /// The object value to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string ObjectValueToString(object value)
        {
            // This mess is to make sure to print reproducible floating point values in order to be able to correct test cases.
            switch (value)
            {
                case double d:
                    return $"{d:R}";
                case float f:
                    return $"{f:R}";
                case ValueTuple<float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R})";
                case ValueTuple<double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R})";
                case ValueTuple<float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R})";
                case ValueTuple<double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R})";
                case ValueTuple<float, float, float, float> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R})";
                case ValueTuple<double, double, double, double> t:
                    return $"({t.Item1:R}, {t.Item2:R}, {t.Item3:R}, {t.Item4:R})";
                case float[] l:
                    return $"float\\[\\] {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case List<float> l:
                    return $"List\\<float\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case IList<float> l:
                    return $"IList\\<float\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case double[] l:
                    return $"double\\[\\] {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case List<double> l:
                    return $"List\\<double\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case IList<double> l:
                    return $"IList\\<double\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case Complex[] l:
                    return $"Complex\\[\\] {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case List<Complex> l:
                    return $"List\\<Complex\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case IList<Complex> l:
                    return $"IList\\<Complex\\> {{{string.Join(", ", l.Select(x => $"{x:R}"))}}}";
                case object[] l:
                    return string.Join(", ", l.Select(x => x.ToString()));
                case null:
                    return "Null";
                default:
                    return value.ToString();
            }
        }

        /// <summary>
        /// Special equivalency tests.
        /// </summary>
        /// <param name="testcase">The test-case.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string Equivalency(KeyValuePair<object[], TestCaseResults> testcase)
        {
            const string equal = "==";
            const string notEqual = "!=";
            var equivalency = string.Empty;
            switch (testcase.Value.ReturnValue)
            {
                case int i:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case int j:
                            equivalency = Math.Abs(i - j) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        case float f:
                            equivalency = Math.Abs(i - f) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        case double d:
                            equivalency = Math.Abs(i - d) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        default:
                            equivalency = Equals(i, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                case float f:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case int i:
                            equivalency = Math.Abs(f - i) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        case float g:
                            if (float.IsNaN(f))
                            {
                                equivalency = float.IsNaN(g) ? equal : notEqual;
                            }
                            else
                            {
                                equivalency = Math.Abs(f - g) <= testcase.Value.Epsilon ? equal : notEqual;
                            }
                            break;
                        case double e:
                            if (float.IsNaN(f))
                            {
                                equivalency = double.IsNaN(e) ? equal : notEqual;
                            }
                            else
                            {
                                equivalency = Math.Abs(f - e) <= testcase.Value.Epsilon ? equal : notEqual;
                            }
                            break;
                        default:
                            equivalency = Equals(f, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                case double d:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case int i:
                            equivalency = Math.Abs(d - i) <= testcase.Value.Epsilon ? equal : notEqual;
                            break;
                        case float f:
                            if (double.IsNaN(d))
                            {
                                equivalency = float.IsNaN(f) ? equal : notEqual;
                            }
                            else
                            {
                                equivalency = Math.Abs(d - f) <= testcase.Value.Epsilon ? equal : notEqual;
                            }
                            break;
                        case double e:
                            if (double.IsNaN(d))
                            {
                                equivalency = double.IsNaN(e) ? equal : notEqual;
                            }
                            else
                            {
                                equivalency = Math.Abs(d - e) <= testcase.Value.Epsilon ? equal : notEqual;
                            }
                            break;
                        default:
                            equivalency = Equals(d, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                case IList<int> l:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case IList<int> k:
                            equivalency = equal;
                            if (l.Count != k.Count)
                            {
                                equivalency = notEqual;
                            }
                            else
                            {
                                for (var i = 0; i < l.Count; i++)
                                {
                                    if (l[i] != k[i])
                                    {
                                        equivalency = notEqual;
                                        break;
                                    }
                                }
                            }
                            break;
                        default:
                            equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                case IList<float> l:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case IList<float> k:
                            equivalency = equal;
                            if (l.Count != k.Count)
                            {
                                equivalency = notEqual;
                            }
                            else
                            {
                                for (var i = 0; i < l.Count; i++)
                                {
                                    if (l[i] != k[i])
                                    {
                                        equivalency = notEqual;
                                        break;
                                    }
                                }
                            }
                            break;
                        default:
                            equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                case IList<double> l:
                    switch (testcase.Value.ExpectedReturnValue)
                    {
                        case IList<double> k:
                            equivalency = equal;
                            if (l.Count != k.Count)
                            {
                                equivalency = notEqual;
                            }
                            else
                            {
                                for (var i = 0; i < l.Count; i++)
                                {
                                    if (l[i] != k[i])
                                    {
                                        equivalency = notEqual;
                                        break;
                                    }
                                }
                            }
                            break;
                        default:
                            equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                            break;
                    }
                    break;
                default:
                    equivalency = Equals(testcase.Value.ReturnValue, testcase.Value.ExpectedReturnValue) ? equal : notEqual;
                    break;
            }

            return equivalency;
        }
    }
}
