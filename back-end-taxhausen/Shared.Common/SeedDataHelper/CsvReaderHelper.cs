using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Shared.Common.SeedDataHelper;

/// <summary>
/// Provides helper methods for reading CSV files.
/// </summary>
public static class CsvReaderHelper
{
    /// <summary>
    /// Reads an embedded CSV file stream and maps each record to the specified model.
    /// </summary>
    /// <typeparam name="T">
    /// The type to which each CSV record is mapped.
    /// </typeparam>
    /// <param name="fileStream">
    /// The stream containing the CSV file.
    /// </param>
    /// <returns>
    /// A list of objects mapped from the CSV records.
    /// </returns>
    public static List<T> ReadCsv<T>(Stream fileStream)
    {
        CsvConfiguration config = new(CultureInfo.InvariantCulture)
        {
            HeaderValidated = null,
            MissingFieldFound = null,
            IgnoreReferences = true
        };

        using StreamReader reader = new(fileStream, Encoding.UTF8);
        CsvReader csvReader = new(reader, config);

        return csvReader.GetRecords<T>().ToList();
    }
}