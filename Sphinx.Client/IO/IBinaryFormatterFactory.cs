using System.IO;
using Sphinx.Client.Network;

namespace Sphinx.Client.IO
{
    /// <summary>
    /// Interface for binary formatters factory
    /// </summary>
    public interface IBinaryFormatterFactory
    {
		IBinaryReader CreateReader(IStreamAdapter stream);
		IBinaryWriter CreateWriter(IStreamAdapter stream);
    }
}