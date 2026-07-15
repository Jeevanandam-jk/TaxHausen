using System.Text;

namespace Shared.Common.Extension;

/// <summary>
/// Provides extension methods for string manipulation.
/// </summary>
public static class StringExtension
{
    /// <summary>
    /// Converts the specified string from PascalCase or camelCase to snake_case.
    /// </summary>
    /// <param name="value">
    /// The string to be converted.
    /// </param>
    /// <returns>
    /// A snake_case representation of the specified string. Returns the original value if it is null, empty, or consists only of whitespace.
    /// </returns>
    public static string ConvertToSnakeCase(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return value;
        }

        StringBuilder builder = new();

        for (int i = 0; i < value.Length; i++)
        {
            char current = value[i];

            if (char.IsUpper(current))
            {
                if (i > 0)
                {
                    builder.Append('_');
                }

                builder.Append(char.ToLowerInvariant(current));
            }
            else
            {
                builder.Append(current);
            }
        }

        return builder.ToString();
    }
}