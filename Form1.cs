using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lilbrowser
{
    public partial class Form1 : Form
    {
        private const string HomePage = "https://www.google.com/";
        private const string ApplicationTitle = "Lilbrowser";
        private readonly DownloadHistory downloadHistory = new DownloadHistory();
        private bool isLoading;

        public Form1()
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
            UpdateNavigationButtons();
            UpdateDownloadsPanel();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            NavigateTo(new Uri(HomePage));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
            {
                addressBox.Focus();
                addressBox.SelectAll();
                e.SuppressKeyPress = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
            {
                browser.GoBack();
            }
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
            {
                browser.GoForward();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (browser.Url != null)
            {
                browser.Refresh();
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            NavigateTo(new Uri(HomePage));
        }

        private void downloadsButton_Click(object sender, EventArgs e)
        {
            browserSplitContainer.Panel2Collapsed = !browserSplitContainer.Panel2Collapsed;
            downloadsButton.Text = browserSplitContainer.Panel2Collapsed ? "Downloads" : "Hide downloads";

            if (!browserSplitContainer.Panel2Collapsed)
            {
                downloadsListBox.Focus();
            }
        }

        private void clearDownloadsButton_Click(object sender, EventArgs e)
        {
            downloadHistory.Clear();
            UpdateDownloadsPanel();
            SetStatus("Download history cleared.");
        }

        private void openDownloadsFolderButton_Click(object sender, EventArgs e)
        {
            var downloadsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads");

            try
            {
                if (!Directory.Exists(downloadsPath))
                {
                    Directory.CreateDirectory(downloadsPath);
                }

                Process.Start(downloadsPath);
            }
            catch (Win32Exception)
            {
                SetStatus("Could not open the Downloads folder.");
            }
            catch (UnauthorizedAccessException)
            {
                SetStatus("The Downloads folder is not accessible.");
            }
            catch (IOException)
            {
                SetStatus("Could not open the Downloads folder.");
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            Uri target;
            string errorMessage;
            if (!NavigationTarget.TryCreate(addressBox.Text, out target, out errorMessage))
            {
                SetStatus(errorMessage);
                addressBox.Focus();
                addressBox.SelectAll();
                return;
            }

            NavigateTo(target);
        }

        private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url == null)
            {
                return;
            }

            BeginLoading(e.Url);
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UpdateNavigationButtons();
            UpdateAddressBar();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // DocumentCompleted also fires for frames; update chrome only for the top-level document.
            if (browser.Url == null || !browser.Url.Equals(e.Url))
            {
                return;
            }

            UpdateAddressBar();
            UpdateNavigationButtons();
            EndLoading("Done");
        }

        private void browser_StatusTextChanged(object sender, EventArgs e)
        {
            if (!isLoading && !string.IsNullOrWhiteSpace(browser.StatusText))
            {
                SetStatus(browser.StatusText);
            }
        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (!isLoading)
            {
                return;
            }

            if (e.MaximumProgress > 0 && e.CurrentProgress >= 0)
            {
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = Math.Min(100, Math.Max(0, (int)(e.CurrentProgress * 100L / e.MaximumProgress)));
            }
            else
            {
                progressBar.Style = ProgressBarStyle.Marquee;
            }
        }

        private void browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Text = string.IsNullOrWhiteSpace(browser.DocumentTitle)
                ? ApplicationTitle
                : browser.DocumentTitle + " - " + ApplicationTitle;
        }

        private void browser_CanGoBackChanged(object sender, EventArgs e)
        {
            UpdateNavigationButtons();
        }

        private void browser_CanGoForwardChanged(object sender, EventArgs e)
        {
            UpdateNavigationButtons();
        }

        private void browser_FileDownload(object sender, EventArgs e)
        {
            // WebBrowser owns the native download prompt and transfer. We keep an in-session
            // history entry so the user can see that the request was handed to the browser.
            downloadHistory.Add(browser.Url, DateTime.Now);
            UpdateDownloadsPanel();
            browserSplitContainer.Panel2Collapsed = false;
            downloadsButton.Text = "Hide downloads";
            SetStatus("Download started. Choose a save location in the download dialog.");
        }

        private void browser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            SetStatus("Pop-ups are blocked.");
        }

        private void NavigateTo(Uri target)
        {
            if (target == null || IsDisposed || browser.IsDisposed)
            {
                return;
            }

            try
            {
                browser.Navigate(target);
            }
            catch (InvalidOperationException)
            {
                EndLoading("The browser is not ready to navigate yet.");
            }
        }

        private void BeginLoading(Uri target)
        {
            isLoading = true;
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            SetStatus("Loading " + DisplayHost(target) + "...");
        }

        private void EndLoading(string statusMessage)
        {
            isLoading = false;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 100;
            progressBar.Visible = false;
            SetStatus(statusMessage);
        }

        private void UpdateAddressBar()
        {
            if (browser.Url != null && !addressBox.Focused)
            {
                addressBox.Text = browser.Url.AbsoluteUri;
            }
        }

        private void UpdateNavigationButtons()
        {
            backButton.Enabled = browser.CanGoBack;
            forwardButton.Enabled = browser.CanGoForward;
            refreshButton.Enabled = browser.Url != null;
        }

        private void UpdateDownloadsPanel()
        {
            downloadsListBox.BeginUpdate();
            try
            {
                downloadsListBox.Items.Clear();
                foreach (var entry in downloadHistory.Snapshot())
                {
                    downloadsListBox.Items.Add(entry);
                }
            }
            finally
            {
                downloadsListBox.EndUpdate();
            }

            downloadsEmptyLabel.Visible = downloadHistory.Count == 0;
            clearDownloadsButton.Enabled = downloadHistory.Count > 0;
        }

        private void SetStatus(string message)
        {
            statusLabel.Text = string.IsNullOrWhiteSpace(message) ? "Ready" : message;
        }

        private static string DisplayHost(Uri target)
        {
            return target == null || string.IsNullOrWhiteSpace(target.Host) ? "page" : target.Host;
        }
    }
}
