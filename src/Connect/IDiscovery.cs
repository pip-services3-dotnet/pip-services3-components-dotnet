using System.Collections.Generic;
using System.Threading.Tasks;
using PipServices.Components.Auth;

namespace PipServices.Components.Connect
{
    /// <summary>
    /// Interface for discovery services which are used to store and resolve connection parameters
    /// to connect to external services.
    /// </summary>
    /// See <see cref="ConnectionParams"/>, <see cref="CredentialParams"/>
    public interface IDiscovery
    {
        /// <summary>
        /// Registers connection parameters into the discovery service.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a key to uniquely identify the connection parameters.</param>
        /// <param name="connection">a connection to be registered.</param>
        Task RegisterAsync(string correlationId, string key, ConnectionParams connection);

        /// <summary>
        /// Resolves a single connection parameters by its key.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a key to uniquely identify the connection.</param>
        /// <returns>a resolved connection.</returns>
        Task<ConnectionParams> ResolveOneAsync(string correlationId, string key);

        /// <summary>
        /// Resolves all connection parameters by their key.
        /// </summary>
        /// <param name="correlationId">(optional) transaction id to trace execution through call chain.</param>
        /// <param name="key">a key to uniquely identify the connection.</param>
        /// <returns>a list with resolved connections.</returns>
        Task<List<ConnectionParams>> ResolveAllAsync(string correlationId, string key);
    }
}
