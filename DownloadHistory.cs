using System;
using System.Collections.Generic;

namespace Lilbrowser
{
    /// <summary>
    /// Keeps a small, in-session record of download requests raised by the browser control.
    /// The built-in WebBrowser download dialog remains responsible for choosing the destination.
    /// </summary>
    internal sealed class DownloadHistory
    {
        private const int MaximumEntries = 100;
        private readonly List<DownloadEntry> entries = new List<DownloadEntry>();

        internal int Count
        {
            get { return entries.Count; }
        }

        internal void Add(Uri source, DateTime startedAt)
        {
            entries.Insert(0, new DownloadEntry(source, startedAt));
            if (entries.Count > MaximumEntries)
            {
                entries.RemoveAt(entries.Count - 1);
            }
        }

        internal void Clear()
        {
            entries.Clear();
        }

        internal IList<DownloadEntry> Snapshot()
        {
            return entries.AsReadOnly();
        }
    }

    internal sealed class DownloadEntry
    {
        internal DownloadEntry(Uri source, DateTime startedAt)
        {
            Source = source;
            StartedAt = startedAt;
        }

        internal Uri Source { get; private set; }

        internal DateTime StartedAt { get; private set; }

        public override string ToString()
        {
            var sourceText = Source == null || string.IsNullOrWhiteSpace(Source.Host)
                ? "Unknown source"
                : Source.Host;

            return StartedAt.ToString("g") + "  •  " + sourceText;
        }
    }
}
