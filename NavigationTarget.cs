using System;

namespace Lilbrowser
{
    /// <summary>
    /// Turns text entered in the address bar into a safe web navigation target.
    /// </summary>
    internal static class NavigationTarget
    {
        private const string SearchUrl = "https://www.google.com/search?q=";

        internal static bool TryCreate(string input, out Uri target, out string errorMessage)
        {
            target = null;
            errorMessage = null;

            var value = (input ?? string.Empty).Trim();
            if (value.Length == 0)
            {
                errorMessage = "Enter a web address or search term.";
                return false;
            }

            if (HasExplicitScheme(value))
            {
                if (!Uri.TryCreate(value, UriKind.Absolute, out target) || !IsWebAddress(target))
                {
                    target = null;
                    errorMessage = "Only http and https web addresses can be opened.";
                    return false;
                }

                return true;
            }

            if (LooksLikeAddress(value))
            {
                Uri webAddress;
                if (Uri.TryCreate("https://" + value, UriKind.Absolute, out webAddress) && IsWebAddress(webAddress))
                {
                    target = webAddress;
                    return true;
                }

                errorMessage = "That web address is not valid.";
                return false;
            }

            try
            {
                target = new Uri(SearchUrl + Uri.EscapeDataString(value), UriKind.Absolute);
                return true;
            }
            catch (UriFormatException)
            {
                errorMessage = "That search could not be opened.";
                return false;
            }
        }

        private static bool HasExplicitScheme(string value)
        {
            var separator = value.IndexOf(':');
            if (separator <= 0 || !char.IsLetter(value[0]))
            {
                return false;
            }

            for (var index = 0; index < separator; index++)
            {
                var character = value[index];
                if (!char.IsLetterOrDigit(character) && character != '+' && character != '-' && character != '.')
                {
                    return false;
                }
            }

            return !LooksLikeHostAndPort(value, separator);
        }

        private static bool LooksLikeHostAndPort(string value, int separator)
        {
            var host = value.Substring(0, separator);
            var portEnd = value.IndexOf('/', separator + 1);
            var port = value.Substring(separator + 1, (portEnd < 0 ? value.Length : portEnd) - separator - 1);
            int ignoredPort;

            return port.Length > 0 && int.TryParse(port, out ignoredPort) &&
                   Uri.CheckHostName(host) != UriHostNameType.Unknown;
        }

        private static bool LooksLikeAddress(string value)
        {
            if (value.IndexOfAny(new[] { ' ', '\t', '\r', '\n' }) >= 0)
            {
                return false;
            }

            return value.IndexOf('.') >= 0 || value.IndexOf(':') >= 0 ||
                   string.Equals(value, "localhost", StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsWebAddress(Uri address)
        {
            return address != null &&
                   !string.IsNullOrEmpty(address.Host) &&
                   (string.Equals(address.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(address.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase));
        }
    }
}
