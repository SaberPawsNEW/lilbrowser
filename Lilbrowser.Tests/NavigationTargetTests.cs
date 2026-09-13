using System;

namespace Lilbrowser.Tests
{
    internal static class NavigationTargetTests
    {
        private static int Main()
        {
            try
            {
                ResolvesWebAddresses();
                ResolvesSearchTerms();
                RejectsUnsupportedSchemes();
                RejectsBlankInput();
                KeepsDownloadHistoryInNewestFirstOrder();
                CapsDownloadHistory();
                Console.WriteLine("All browser support tests passed.");
                return 0;
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception.Message);
                return 1;
            }
        }

        private static void ResolvesWebAddresses()
        {
            AssertTarget("https://example.com/path", "https://example.com/path");
            AssertTarget("example.com", "https://example.com/");
            AssertTarget("localhost:5000", "https://localhost:5000/");
            AssertTarget("127.0.0.1:8080", "https://127.0.0.1:8080/");
        }

        private static void ResolvesSearchTerms()
        {
            AssertTarget("best browser", "https://www.google.com/search?q=best%20browser");
        }

        private static void RejectsUnsupportedSchemes()
        {
            AssertRejected("ftp://example.com");
            AssertRejected("javascript:alert(1)");
            AssertRejected("file:///C:/Windows/system.ini");
            AssertRejected("https://");
        }

        private static void RejectsBlankInput()
        {
            AssertRejected("   ");
        }

        private static void KeepsDownloadHistoryInNewestFirstOrder()
        {
            var history = new DownloadHistory();
            var first = new Uri("https://first.example/file.zip");
            var second = new Uri("https://second.example/file.zip");
            history.Add(first, new DateTime(2024, 1, 1, 10, 0, 0));
            history.Add(second, new DateTime(2024, 1, 1, 10, 1, 0));

            if (history.Count != 2 || !history.Snapshot()[0].Source.Equals(second))
            {
                throw new InvalidOperationException("Download history did not retain newest-first order.");
            }

            history.Clear();
            if (history.Count != 0)
            {
                throw new InvalidOperationException("Download history did not clear.");
            }
        }

        private static void CapsDownloadHistory()
        {
            var history = new DownloadHistory();
            for (var index = 0; index < 105; index++)
            {
                history.Add(new Uri("https://example.com/" + index), DateTime.UtcNow);
            }

            if (history.Count != 100)
            {
                throw new InvalidOperationException("Download history did not enforce its maximum size.");
            }
        }

        private static void AssertTarget(string input, string expected)
        {
            Uri target;
            string errorMessage;
            if (!NavigationTarget.TryCreate(input, out target, out errorMessage))
            {
                throw new InvalidOperationException("Expected a target for '" + input + "', but got: " + errorMessage);
            }

            if (!string.Equals(target.AbsoluteUri, expected, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Expected '" + expected + "', got '" + target.AbsoluteUri + "'.");
            }
        }

        private static void AssertRejected(string input)
        {
            Uri target;
            string errorMessage;
            if (NavigationTarget.TryCreate(input, out target, out errorMessage))
            {
                throw new InvalidOperationException("Expected '" + input + "' to be rejected, got '" + target.AbsoluteUri + "'.");
            }

            if (string.IsNullOrWhiteSpace(errorMessage))
            {
                throw new InvalidOperationException("Expected an error message for '" + input + "'.");
            }
        }
    }
}
