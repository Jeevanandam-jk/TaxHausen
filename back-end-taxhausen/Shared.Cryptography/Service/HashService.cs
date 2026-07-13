using System.Security.Cryptography;
using System.Text;
using Shared.Cryptography.Contract;

namespace Shared.Cryptography.Service;

/// <summary>
/// Provides functionality for generating cryptographic hash values using the specified hashing algorithm.
/// </summary>
/// <remarks>
/// This service supports any <see cref="HashAlgorithm"/> implementation provided by .NET, allowing callers to compute hash values using
/// algorithms such as <see cref="SHA256"/>, <see cref="SHA384"/>, and <see cref="SHA512"/>.
/// </remarks>
public class HashService : IHashService
{
    /// <summary>
    /// Computes a cryptographic hash for the specified text using the provided hashing algorithm.
    /// </summary>
    /// <param name="text">
    /// The plain text to be hashed.
    /// </param>
    /// <param name="algorithm">
    /// The cryptographic hashing algorithm to use.
    /// </param>
    /// <returns>
    /// A hexadecimal string representation of the computed hash.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="text"/> or <paramref name="algorithm"/> is <c>null</c>.
    /// </exception>
    public string ComputeHash(string text, HashAlgorithm algorithm)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(algorithm);

        using (algorithm)
        {
            byte[] bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));

            return Convert.ToHexString(bytes).ToLowerInvariant();
        }
    }
}