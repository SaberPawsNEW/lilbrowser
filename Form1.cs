using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lilbrowser
{
    public partial class Form1 : Form
    {
        private const string HomePage = "https://www.google.com/";
        private const string ApplicationTitle = "Lilbrowser";

        public Form1()
        {
            InitializeComponent();
            browser.ScriptErrorsSuppressed = true;
            UpdateNavigationButtons();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            NavigateTo(new Uri(HomePage));
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
            if (e.Url != null)
            {
                SetStatus("Loading " + e.Url.Host + "...");
            }
        }

        private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UpdateNavigationButtons();
            UpdateAddressBar();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // DocumentCompleted also fires for frames; only update the chrome for the top-level page.
            if (browser.Url == null || !browser.Url.Equals(e.Url))
            {
                return;
            }

            UpdateAddressBar();
            UpdateNavigationButtons();
            SetStatus("Done");
        }

        private void browser_StatusTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(browser.StatusText))
            {
                SetStatus(browser.StatusText);
            }
        }

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress > 0 && e.CurrentProgress >= 0 && e.CurrentProgress < e.MaximumProgress)
            {
                SetStatus("Loading...");
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
                SetStatus("The browser is not ready to navigate yet.");
            }
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

        private void SetStatus(string message)
        {
            statusLabel.Text = string.IsNullOrWhiteSpace(message) ? "Ready" : message;
        }
    }
}
