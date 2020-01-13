using PipServices3.Components.Build;
using PipServices3.Commons.Refer;

namespace PipServices3.Components.Auth
{
    /// <summary>
    /// Creates ICredentialStore components by their descriptors.
    /// </summary>
    /// See <see cref="IFactory"/>, <see cref="ICredentialStore"/>, <see cref="MemoryCredentialStore"/>
    public class DefaultCredentialStoreFactory: Factory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "credential-store", "default", "1.0");
        public static readonly Descriptor Descriptor3 = new Descriptor("pip-services3", "factory", "credential-store", "default", "1.0");
        public static readonly Descriptor MemoryCredentialStoreDescriptor = new Descriptor("pip-services", "credential-store", "memory", "*", "1.0");
        public static readonly Descriptor MemoryCredentialStore3Descriptor = new Descriptor("pip-services3", "credential-store", "memory", "*", "1.0");
        public static readonly Descriptor MemoryCredentialStoreDescriptor2 = new Descriptor("pip-services-commons", "credential-store", "memory", "*", "1.0");
        public static readonly Descriptor MemoryCredentialStore3Descriptor2 = new Descriptor("pip-services3-commons", "credential-store", "memory", "*", "1.0");

        /// <summary>
        /// Create a new instance of the factory.
        /// </summary>
        public DefaultCredentialStoreFactory()
        {
            RegisterAsType(MemoryCredentialStoreDescriptor, typeof(MemoryCredentialStore));
            RegisterAsType(MemoryCredentialStore3Descriptor, typeof(MemoryCredentialStore));
            RegisterAsType(MemoryCredentialStoreDescriptor2, typeof(MemoryCredentialStore));
            RegisterAsType(MemoryCredentialStore3Descriptor2, typeof(MemoryCredentialStore));
	    }	
    }
}
