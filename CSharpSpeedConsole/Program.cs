using CSharpSpeed;
using InstrumentedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text;

namespace CSharpSpeedConsole
{
    /// <summary>
    /// The program class.
    /// </summary>
    internal class Program
    {
        #region Constants
        /// <summary>
        /// The suffixes.
        /// </summary>
        private static readonly string[] suffixes = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB", "BB", "NB", "DB", "CB", "XB" };

        /// <summary>
        /// The processor name (readonly). Value: GetProcessorName().
        /// </summary>
        private static readonly string ProcessorName = GetProcessorName();

        /// <summary>
        /// The physical memory (readonly). Value: GetPhysicalMemory().
        /// </summary>
        private static readonly string PhysicalMemory = GetPhysicalMemory();

        /// <summary>
        /// The application root folder (readonly). Value: Path.Combine(Environment.CurrentDirectory, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}").
        /// </summary>
        private static readonly string ApplicationRootFolder = Path.Combine(Environment.CurrentDirectory, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}");
        #endregion Constants

        /// <summary>
        /// The main entry point.
        /// </summary>
        /// <param name="args">The args.</param>
        private static void Main(string[] args)
        {
            foreach (var testSetClass in TestReflectionHelper.GetTypesWithHelpAttribute(typeof(SourceCodeLocationProviderAttribute)))
            {
                var testSet = ReflectionHelper.ListStaticFactoryConstructorsList(testSetClass, typeof(List<SpeedTester>));
                var tests = new List<SpeedTester>();
                tests.Clear();
                tests.AddRange(testSet[0]?.Invoke(null, null) as List<SpeedTester>);
                RunTestsAndBuildReport(
                    tests,
                    ((DisplayNameAttribute)testSetClass?.GetCustomAttribute(typeof(DisplayNameAttribute)))?.DisplayName,
                    ((DescriptionAttribute)testSetClass?.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description,
                    ((SignatureAttribute)testSetClass?.GetCustomAttribute(typeof(SignatureAttribute)))?.MethodSignature
                    );
            }

            Console.WriteLine("Reports Generated.");
            //Console.WriteLine("[Press Any Key To Continue.]");
            //Console.ReadKey();
        }

        /// <summary>
        /// The run tests and build report.
        /// </summary>
        /// <param name="tests">The tests.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        /// <param name="signature">The signature.</param>
        private static void RunTestsAndBuildReport(List<SpeedTester> tests, string title = "", string description = "", string signature = "")
        {
            // Build out the report markdown.
            var sb = new StringBuilder();

            // Build up the document title.
            sb.AppendLine($"# {title}");
            sb.AppendLine();

            // Display the description.
            if (description != "")
            {
                sb.AppendLine(description);
                sb.AppendLine();
            }

            // Present the machine specs for evaluation.
            sb.AppendLine("> ## Machine Specs for this Runs Results");
            sb.AppendLine("> The test cases below were run on a system with the following hardware specifications. Results will vary on the same system depending on current processing work load. So, take the numbers in the tables with a grain of salt.  ");
            sb.AppendLine($"> **Processor:**  ");
            sb.Append($"{ProcessorName}  ");
            sb.AppendLine($"> **Physical Memory:**  ");
            sb.Append($"{PhysicalMemory}  ");
            sb.AppendLine($"> **Library Compiled as:**  ");
#if DEBUG
            sb.Append($"> Debug  ");
#else
            sb.Append($"> Release  ");
#endif
            sb.AppendLine();
            sb.AppendLine();

            sb.AppendLine("## Results");
            sb.AppendLine();

            // Present the filename of the class being tested.
            sb.AppendLine($"{tests[0]?.FileName.Replace(Path.DirectorySeparatorChar, '/')}");
            sb.AppendLine();

            // Display the intended signature for the methods.
            if (description != "")
            {
                sb.AppendLine("The required method signature for this API is as follows:");
                sb.AppendLine();
                sb.AppendLine("```CSharp");
                sb.AppendLine(signature);
                sb.AppendLine("```");
                sb.AppendLine();
            }

            // Build up the results dictionary to be entered into the table.
            var results = new Dictionary<object[], List<string>>();
            foreach (SpeedTester test in tests)
            {
                // Run test cases.
                test.RunTest();
                Console.WriteLine($"Processing: {test.Method.Name}");
                var resultSet = test.ToResultsString();
                foreach (var result in resultSet)
                {
                    if (!results.ContainsKey(result.Key))
                    {
                        results.Add(result.Key, new List<string>());
                    }
                    results[result.Key].Add(result.Value);
                }
            }

            sb.AppendLine("## Test Case Index");
            sb.AppendLine();
            foreach (var key in results.Keys)
            {
                var keyString = key.ArrayToString();
                sb.AppendLine($"- [Test Case: ({keyString})](#{keyString.Replace(" ", "-")})");
            }

            sb.AppendLine();

            // Build up the results table.
            foreach (var result in results)
            {
                sb.AppendLine($"### ({result.Key.ArrayToString()})");
                sb.AppendLine();
                sb.AppendLine("| Method | Results (Actual, Expected) | Time (Trials, Elapsed time, Average running time) | Notes |");
                sb.AppendLine("|---|---|---|---|");
                foreach (var row in result.Value)
                {
                    sb.AppendLine(row);
                }
                sb.AppendLine();
            }

            // Copy in the applicable lines of code.
            sb.AppendLine("## The Code");
            sb.AppendLine();
            sb.AppendLine("The code for the methods tested follows below.");
            sb.AppendLine();
            foreach (SpeedTester test in tests)
            {
                sb.AppendLine($"### {((DisplayNameAttribute)test.Method?.GetCustomAttribute(typeof(DisplayNameAttribute)))?.DisplayName}");
                sb.AppendLine();
                sb.AppendLine($"{((DescriptionAttribute)test.Method?.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description}  ");
                sb.Append($"{((AcknowledgmentAttribute)test.Method?.GetCustomAttribute(typeof(AcknowledgmentAttribute)))?.Urls.ArrayToUrlListString()}");
                sb.AppendLine();
                sb.AppendLine("```CSharp");
                sb.Append(test.MethodCode);
                sb.AppendLine("```");
                sb.AppendLine();
            }

            // Capture the folder for the report.
            var reportFolder = Path.GetFullPath(Path.Combine(ApplicationRootFolder, "reports", Path.GetDirectoryName(tests[0].FileName).Replace($"..{Path.DirectorySeparatorChar}", "")));

            // Capture the name and full path of the markdown file.
            var reportFile = Path.GetFullPath(Path.Combine(reportFolder, $"{Path.GetFileNameWithoutExtension(tests[0].FileName)}.md"));

            // Ensure the directory exists.
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            // Save the markdown.
            using (var stream = File.CreateText(reportFile))
            {
                stream.Write(sb.ToString());
            }
        }

        #region Helper Methods
        /// <summary>
        /// The processor name.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetProcessorName()
        {
            var sb = new StringBuilder();
            try
            {
                var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    sb.AppendLine($"> Name: {queryObj["Name"]}  ");
                }
            }
            catch (ManagementException)
            {
                sb.AppendLine("Prosessor unknown");
            }
            return sb.ToString();
        }

        /// <summary>
        /// The physical memory.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public static string GetPhysicalMemory()
        {
            var sb = new StringBuilder();
            try
            {
                var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    sb.AppendLine($"> Capacity: {FormatCapacity((ulong)queryObj["Capacity"])}  ");
                    sb.AppendLine($"> Speed: {queryObj["Speed"]} nanoseconds  ");
                }
            }
            catch (ManagementException)
            {
                sb.Append("Memory unknown");
            }
            return sb.ToString();
        }

        /// <summary>
        /// The capacity.
        /// https://stackoverflow.com/a/22733709
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string FormatCapacity(ulong number)
        {
            for (var i = 0ul; i < (ulong)suffixes.Length; i++)
            {
                var temp = number / (ulong)Math.Pow(1024ul, i + 1ul);
                if (temp == 0ul)
                {
                    return $"{number / (ulong)Math.Pow(1024ul, i)} {suffixes[i]}";
                }
            }
            return number.ToString();
        }
        #endregion Helper Methods
    }
}
