using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sphinx.Client.UnitTests.Helpers
{
    public static class XmlUtils
    {
        public static string XmlEncode(string text)
        {
            if (text == null) return null;
            return text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }

        public static string XmlDecode(string xml)
        {
            if (xml == null) return null;
            return xml.Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&");
        }
    }
}
