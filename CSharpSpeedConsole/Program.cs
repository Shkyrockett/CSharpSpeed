using CSharpSpeed;
using InstrumentedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
#if HAS_INTRINSICS
using System.Runtime.Intrinsics.X86;
#endif

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
        private static readonly string processorName = GetProcessorName();

        /// <summary>
        /// The physical memory (readonly). Value: GetPhysicalMemory().
        /// </summary>
        private static readonly string physicalMemory = GetPhysicalMemory();

        /// <summary>
        /// The application root folder (readonly). Value: Path.Combine(Environment.CurrentDirectory, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}").
        /// </summary>
        private static readonly string applicationRootFolder = Path.Combine(Environment.CurrentDirectory, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}");
        #endregion Constants

        /// <summary>
        /// The main entry point.
        /// </summary>
        /// <param name="args">The args.</param>
        private static void Main(string[] args)
        {
            List<Type> types = null;
            if (args is not null)
            {
                types = new List<Type>();
                foreach (var arg in args)
                {
                    foreach (var type in TestReflectionHelper.GetTypesWithHelpAttributeByName(arg, typeof(SourceCodeLocationProviderAttribute)))
                    {
                        types.Add(type);
                    }
                }
            }
            if (types is null || !types.Any())
            {
                types = TestReflectionHelper.GetTypesWithHelpAttribute(typeof(SourceCodeLocationProviderAttribute)).ToList();
            }

            foreach (var testSetClass in types)
            {
                var testSet = HelperExtensions.ListStaticFactoryConstructorsList(testSetClass, typeof(List<SpeedTester>));
                var tests = new List<SpeedTester>();
                tests.Clear();
                tests.AddRange(testSet[0]?.Invoke(null, null) as List<SpeedTester>);
                RunTestsAndBuildReport(
                    tests,
                    ((DisplayNameAttribute)testSetClass?.GetCustomAttribute(typeof(DisplayNameAttribute)))?.DisplayName,
                    ((DescriptionAttribute)testSetClass?.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description,
                    ((SignatureAttribute)testSetClass?.GetMethods()?.FirstOrDefault(m => m?.GetCustomAttribute(typeof(SignatureAttribute)) != null)?.GetCustomAttribute(typeof(SignatureAttribute)))?.MethodSignature.Trim()
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
            if (string.IsNullOrEmpty(description))
            {
                sb.AppendLine(description);
                sb.AppendLine();
            }

            // Present the machine specs for evaluation.
            sb.AppendLine("> ## Machine Specs for this Runs Results  ");
            sb.AppendLine(">");
            sb.AppendLine("> The test cases below were run on a system with the following hardware specifications. Results will vary on the same system depending on current processing work load. So, take the numbers in the tables with a grain of salt.  ");
            sb.AppendLine(">");
            sb.Append($"> **Library Compiled as:**  ");
#if DEBUG
            sb.AppendLine($"Debug  ");
#else
            sb.AppendLine($"Release  ");
#endif
            sb.AppendLine(">");
            // https://devblogs.microsoft.com/dotnet/announcing-net-core-3-preview-4/#user-content-improving-net-core-version-apis
            sb.AppendLine($"> **.NET Version:** {Environment.Version}  ");
            sb.AppendLine($"> **Runtime Framework:** {RuntimeInformation.FrameworkDescription}  ");
            sb.AppendLine($"> **CoreCLR Build:** {((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[0]}  ");
            //sb.AppendLine($"> **CoreCLR Hash:** {((AssemblyInformationalVersionAttribute[])typeof(object).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[1]}  ");
            sb.AppendLine($"> **CoreFX Build:** {((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[0]}  ");
            //sb.AppendLine($"> **CoreFX Hash:** {((AssemblyInformationalVersionAttribute[])typeof(Uri).Assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false))[0].InformationalVersion.Split('+')[1]}  ");
            sb.AppendLine(">");
            sb.AppendLine($"> **Processor:** {processorName}  ");
            sb.AppendLine($"> **Physical Memory:**  ");
            sb.Append($"{physicalMemory}");

#if HAS_INTRINSICS
            sb.AppendLine("> **System.Runtime.Intrinsics.X86 support**  ");
            sb.AppendLine($"> Is {nameof(Aes)} supported? {Aes.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Avx)} supported? {Avx.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Avx2)} supported? {Avx2.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Bmi1)} supported? {Bmi1.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Bmi2)} supported? {Bmi2.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Fma)} supported? {Fma.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Lzcnt)} supported? {Lzcnt.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Pclmulqdq)} supported? {Pclmulqdq.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Popcnt)} supported? {Popcnt.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Sse)} supported? {Sse.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Sse2)} supported? {Sse2.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Sse3)} supported? {Sse3.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Sse41)} supported? {Sse41.IsSupported}  ");
            sb.AppendLine($"> Is {nameof(Sse42)} supported? {Sse42.IsSupported}  ");
#endif

            sb.AppendLine();
            sb.AppendLine("## Results");
            sb.AppendLine();
            sb.AppendLine("The following are the results of the speed testing the code in the following file.");
            sb.AppendLine();

            // Present the filename of the class being tested.
            sb.AppendLine($"{tests[0]?.FileName.Replace(Path.DirectorySeparatorChar, '/')}");
            sb.AppendLine();

            // Display the intended signature for the methods.
            if (string.IsNullOrEmpty(description))
            {
                sb.AppendLine("## Method Signature");
                sb.AppendLine();
                sb.AppendLine("The required method signature for this API is as follows:  ");
                sb.AppendLine();
                sb.AppendLine("```CSharp");
                sb.AppendLine(signature);
                sb.AppendLine("```");
                sb.AppendLine();
            }

            // Build up the results dictionary to be entered into the table.
            var results = new Dictionary<object[], List<string>>();
            foreach (var test in tests)
            {
                // Run test cases.
                Console.WriteLine($"Processing: {Path.GetFileNameWithoutExtension(test.FileName)}");
                test.RunTest();
                Console.WriteLine($"   Processed: {Path.GetFileNameWithoutExtension(test.FileName)}.{test.Method.Name}");
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
                sb.AppendLine($"- [Test Case: ({keyString})](#{keyString.Replace(" ", "-", true, CultureInfo.InvariantCulture)})");
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
            foreach (var test in tests)
            {
                sb.AppendLine($"### {((DisplayNameAttribute)test.Method?.GetCustomAttribute(typeof(DisplayNameAttribute)))?.DisplayName}");
                sb.AppendLine();
                sb.AppendLine($"{((DescriptionAttribute)test.Method?.GetCustomAttribute(typeof(DescriptionAttribute)))?.Description}  ");
                sb.Append($"{((AcknowledgmentAttribute)test.Method?.GetCustomAttribute(typeof(AcknowledgmentAttribute)))?.Urls.ArrayToAddressListString()}");
                sb.AppendLine();
                sb.AppendLine("```CSharp");
                sb.Append(test.MethodCode);
                sb.AppendLine("```");
                sb.AppendLine();
            }

            // Capture the folder for the report.
            var reportFolder = Path.GetFullPath(Path.Combine(applicationRootFolder, "reports", Path.GetDirectoryName(tests[0].FileName).Replace($"..{Path.DirectorySeparatorChar}", "", true, CultureInfo.InvariantCulture)));

            // Capture the name and full path of the markdown file.
            var reportFile = Path.GetFullPath(Path.Combine(reportFolder, $"{Path.GetFileNameWithoutExtension(tests[0].FileName)}.md"));

            // Ensure the directory exists.
            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            // Save the markdown.
            using var stream = File.CreateText(reportFile);
            stream.Write(sb.ToString());
        }

        #region Helper Methods
        /// <summary>
        /// The processor name.
        /// </summary>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public static string GetProcessorName()
        {
            var sb = new StringBuilder();
            try
            {
                using var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    sb.Append($"Name: {queryObj["Name"]}");
                }
            }
            catch (ManagementException)
            {
                sb.Append("Processor unknown");
            }

            return sb.ToString();
        }

        /// <summary>
        /// The physical memory.
        /// </summary>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public static string GetPhysicalMemory()
        {
            var sb = new StringBuilder();
            try
            {
                using var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
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
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// The <see cref="string" />.
        /// </returns>
        public static string FormatCapacity(ulong number, IFormatProvider provider = null)
        {
            for (var i = 0ul; i < (ulong)suffixes.Length; i++)
            {
                var temp = number / (ulong)Math.Pow(1024ul, i + 1ul);
                if (temp == 0ul)
                {
                    return $"{number / (ulong)Math.Pow(1024ul, i)} {suffixes[i]}";
                }
            }

            return number.ToString(provider ?? CultureInfo.CurrentCulture);
        }
        #endregion Helper Methods
    }
}
