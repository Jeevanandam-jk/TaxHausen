using System.Security.Cryptography;

namespace Shared.Cryptography.Contract;

/// <summary>
/// Defines methods for generating cryptographic hash values. This service provides a generic mechanism for computing hash values
/// </summary>
public interface IHashService
{
    /// <summary>
    /// Computes a cryptographic hash for the specified text using the provided hashing algorithm.
    /// </summary>
    /// <param name="text">
    /// The plain text to be hashed.
    /// </param>
    /// <param name="algorithm">
    /// The cryptographic hashing algorithm to use, such as
    /// <see cref="SHA256"/>, <see cref="SHA384"/>, or <see cref="SHA512"/>.
    /// </param>
    /// <returns>
    /// A hexadecimal string representation of the computed hash.
    /// </returns>
    string ComputeHash(string text, HashAlgorithm algorithm);
}