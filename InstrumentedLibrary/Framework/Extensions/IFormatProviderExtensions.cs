using System.Globalization;

namespace InstrumentedLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class IFormatProviderExtensions
    {
        /// <summary>
        /// Get the numeric list separator for a given IFormatProvider.
        /// The separator is the list separator, or a comma [,] unless the decimal separator is the same, otherwise a semicolon [;] is used.
        /// </summary>
        /// <param name="provider">The <see cref="CultureInfo"/> provider.</param>
        /// <returns>Returns the list separator, or a comma [,] unless the decimal separator is the same, otherwise a semicolon [;].</returns>
        public static string GetNumericListSeparator(this CultureInfo provider)
        {
            var numberDecimalSeparator = provider?.NumberFormat?.NumberDecimalSeparator ?? ".";
            var listSeparator = provider?.TextInfo?.ListSeparator ?? ",";

            // If the decimal separator is the same as the list separator, use a semicolon ";".
            return (string.IsNullOrWhiteSpace(numberDecimalSeparator) && (listSeparator == numberDecimalSeparator)) ? ";" : listSeparator;
        }
    }
}
