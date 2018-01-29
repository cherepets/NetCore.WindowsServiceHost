using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace NetCore.WindowsServiceHost
{
    public static class Config
    {
        public static string Executeable { get; private set; }
        public static string ServiceName { get; private set; }
        public static TimeSpan PingInterval { get; private set; }
		public static bool AutoRestart { get; private set; }

		public static bool DebugMode { get; set; }

		private static readonly TimeSpan DefaultPingInterval = TimeSpan.FromMilliseconds(100);
        private const bool DefaultCreateNoWindow = false;

        static Config()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var xdoc = XDocument.Load(assembly.Location + ".config");
            var xconfig = xdoc.Descendants("appSettings").FirstOrDefault();

            Executeable = ReadKey(xconfig, nameof(Executeable));
            ServiceName = ReadKey(xconfig, nameof(ServiceName));
            PingInterval = TimeSpan.TryParse(ReadKey(xconfig, nameof(PingInterval)), CultureInfo.InvariantCulture, out TimeSpan pingInterval)
                ? pingInterval
                : DefaultPingInterval;
			AutoRestart = bool.TryParse(ReadKey(xconfig, nameof(AutoRestart)), out bool autoRestart)
				? autoRestart
				: false;
		}

        private static string ReadKey(XElement xelement, string key)
        {
            if (xelement == null) return null;
            var add = xelement.Descendants("add").FirstOrDefault(x => ReadAttribute(x, "key") == key);
            if (add == null) return null;
            return ReadAttribute(add, "value");
        }

        private static string ReadAttribute(XElement xelement, string key)
            => xelement.Attributes(key).FirstOrDefault()?.Value;
    }
}