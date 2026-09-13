namespace Lilbrowser
{
    partial class Form1
    {
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button downloadsButton;
        private System.Windows.Forms.TableLayoutPanel navigationBar;
        private System.Windows.Forms.TableLayoutPanel rootLayout;
        private System.Windows.Forms.SplitContainer browserSplitContainer;
        private System.Windows.Forms.Panel downloadsPanel;
        private System.Windows.Forms.ListBox downloadsListBox;
        private System.Windows.Forms.Label downloadsTitleLabel;
        private System.Windows.Forms.Label downloadsEmptyLabel;
        private System.Windows.Forms.Button openDownloadsFolderButton;
        private System.Windows.Forms.Button clearDownloadsButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        private void InitializeComponent()
        {
            this.browser = new System.Windows.Forms.WebBrowser();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.downloadsButton = new System.Windows.Forms.Button();
            this.navigationBar = new System.Windows.Forms.TableLayoutPanel();
            this.rootLayout = new System.Windows.Forms.TableLayoutPanel();
            this.browserSplitContainer = new System.Windows.Forms.SplitContainer();
            this.downloadsPanel = new System.Windows.Forms.Panel();
            this.downloadsListBox = new System.Windows.Forms.ListBox();
            this.downloadsTitleLabel = new System.Windows.Forms.Label();
            this.downloadsEmptyLabel = new System.Windows.Forms.Label();
            this.openDownloadsFolderButton = new System.Windows.Forms.Button();
            this.clearDownloadsButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.navigationBar.SuspendLayout();
            this.rootLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserSplitContainer)).BeginInit();
            this.browserSplitContainer.Panel1.SuspendLayout();
            this.browserSplitContainer.Panel2.SuspendLayout();
            this.browserSplitContainer.SuspendLayout();
            this.downloadsPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // browser
            //
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.TabIndex = 0;
            this.browser.CanGoBackChanged += new System.EventHandler(this.browser_CanGoBackChanged);
            this.browser.CanGoForwardChanged += new System.EventHandler(this.browser_CanGoForwardChanged);
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            this.browser.DocumentTitleChanged += new System.EventHandler(this.browser_DocumentTitleChanged);
            this.browser.FileDownload += new System.EventHandler(this.browser_FileDownload);
            this.browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.browser_Navigated);
            this.browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browser_Navigating);
            this.browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.browser_NewWindow);
            this.browser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.browser_ProgressChanged);
            this.browser.StatusTextChanged += new System.EventHandler(this.browser_StatusTextChanged);
            //
            // addressBox
            //
            this.addressBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.addressBox.Location = new System.Drawing.Point(206, 13);
            this.addressBox.Margin = new System.Windows.Forms.Padding(6, 13, 6, 12);
            this.addressBox.MaxLength = 2048;
            this.addressBox.Name = "addressBox";
            this.addressBox.TabIndex = 4;
            //
            // backButton
            //
            ConfigureToolbarButton(this.backButton, "‹", "Back", 0);
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            //
            // forwardButton
            //
            ConfigureToolbarButton(this.forwardButton, "›", "Forward", 1);
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            //
            // refreshButton
            //
            ConfigureToolbarButton(this.refreshButton, "↻", "Refresh", 2);
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            //
            // homeButton
            //
            ConfigureToolbarButton(this.homeButton, "Home", "Home", 3);
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            //
            // goButton
            //
            ConfigureToolbarButton(this.goButton, "Go", "Open address", 5);
            this.goButton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.goButton.ForeColor = System.Drawing.Color.White;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            //
            // downloadsButton
            //
            ConfigureToolbarButton(this.downloadsButton, "Downloads", "Show downloads", 6);
            this.downloadsButton.Click += new System.EventHandler(this.downloadsButton_Click);
            //
            // navigationBar
            //
            this.navigationBar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.navigationBar.ColumnCount = 7;
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.navigationBar.Controls.Add(this.backButton, 0, 0);
            this.navigationBar.Controls.Add(this.forwardButton, 1, 0);
            this.navigationBar.Controls.Add(this.refreshButton, 2, 0);
            this.navigationBar.Controls.Add(this.homeButton, 3, 0);
            this.navigationBar.Controls.Add(this.addressBox, 4, 0);
            this.navigationBar.Controls.Add(this.goButton, 5, 0);
            this.navigationBar.Controls.Add(this.downloadsButton, 6, 0);
            this.navigationBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationBar.Name = "navigationBar";
            this.navigationBar.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.navigationBar.RowCount = 1;
            this.navigationBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navigationBar.TabIndex = 0;
            //
            // progressBar
            //
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.progressBar.MarqueeAnimationSpeed = 24;
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            //
            // browserSplitContainer
            //
            this.browserSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.browserSplitContainer.IsSplitterFixed = false;
            this.browserSplitContainer.Name = "browserSplitContainer";
            this.browserSplitContainer.Panel1.Controls.Add(this.browser);
            this.browserSplitContainer.Panel2.Controls.Add(this.downloadsPanel);
            this.browserSplitContainer.Panel2MinSize = 230;
            this.browserSplitContainer.Panel2Collapsed = true;
            this.browserSplitContainer.Size = new System.Drawing.Size(1040, 600);
            this.browserSplitContainer.SplitterDistance = 750;
            this.browserSplitContainer.TabIndex = 2;
            //
            // downloadsPanel
            //
            this.downloadsPanel.BackColor = System.Drawing.Color.White;
            this.downloadsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.downloadsPanel.Controls.Add(this.downloadsListBox);
            this.downloadsPanel.Controls.Add(this.downloadsEmptyLabel);
            this.downloadsPanel.Controls.Add(this.clearDownloadsButton);
            this.downloadsPanel.Controls.Add(this.openDownloadsFolderButton);
            this.downloadsPanel.Controls.Add(this.downloadsTitleLabel);
            this.downloadsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadsPanel.Name = "downloadsPanel";
            this.downloadsPanel.Padding = new System.Windows.Forms.Padding(14);
            this.downloadsPanel.TabIndex = 0;
            //
            // downloadsTitleLabel
            //
            this.downloadsTitleLabel.AutoSize = true;
            this.downloadsTitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.downloadsTitleLabel.Location = new System.Drawing.Point(14, 14);
            this.downloadsTitleLabel.Name = "downloadsTitleLabel";
            this.downloadsTitleLabel.Text = "Downloads";
            //
            // openDownloadsFolderButton
            //
            this.openDownloadsFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openDownloadsFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openDownloadsFolderButton.Location = new System.Drawing.Point(102, 50);
            this.openDownloadsFolderButton.Name = "openDownloadsFolderButton";
            this.openDownloadsFolderButton.Size = new System.Drawing.Size(150, 30);
            this.openDownloadsFolderButton.TabIndex = 0;
            this.openDownloadsFolderButton.Text = "Open Downloads folder";
            this.openDownloadsFolderButton.UseVisualStyleBackColor = true;
            this.openDownloadsFolderButton.Click += new System.EventHandler(this.openDownloadsFolderButton_Click);
            //
            // clearDownloadsButton
            //
            this.clearDownloadsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearDownloadsButton.Location = new System.Drawing.Point(14, 50);
            this.clearDownloadsButton.Name = "clearDownloadsButton";
            this.clearDownloadsButton.Size = new System.Drawing.Size(74, 30);
            this.clearDownloadsButton.TabIndex = 1;
            this.clearDownloadsButton.Text = "Clear";
            this.clearDownloadsButton.UseVisualStyleBackColor = true;
            this.clearDownloadsButton.Click += new System.EventHandler(this.clearDownloadsButton_Click);
            //
            // downloadsEmptyLabel
            //
            this.downloadsEmptyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadsEmptyLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.downloadsEmptyLabel.Location = new System.Drawing.Point(14, 96);
            this.downloadsEmptyLabel.Name = "downloadsEmptyLabel";
            this.downloadsEmptyLabel.Size = new System.Drawing.Size(238, 40);
            this.downloadsEmptyLabel.TabIndex = 2;
            this.downloadsEmptyLabel.Text = "Downloads you start in this session will appear here.";
            //
            // downloadsListBox
            //
            this.downloadsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.downloadsListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.downloadsListBox.FormattingEnabled = true;
            this.downloadsListBox.IntegralHeight = false;
            this.downloadsListBox.Location = new System.Drawing.Point(14, 142);
            this.downloadsListBox.Name = "downloadsListBox";
            this.downloadsListBox.Size = new System.Drawing.Size(238, 430);
            this.downloadsListBox.TabIndex = 3;
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            //
            // statusLabel
            //
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Ready";
            //
            // rootLayout
            //
            this.rootLayout.ColumnCount = 1;
            this.rootLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.Controls.Add(this.navigationBar, 0, 0);
            this.rootLayout.Controls.Add(this.progressBar, 0, 1);
            this.rootLayout.Controls.Add(this.browserSplitContainer, 0, 2);
            this.rootLayout.Controls.Add(this.statusStrip, 0, 3);
            this.rootLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootLayout.Name = "rootLayout";
            this.rootLayout.RowCount = 4;
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rootLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.rootLayout.TabIndex = 0;
            //
            // Form1
            //
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 700);
            this.Controls.Add(this.rootLayout);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(760, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lilbrowser";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.navigationBar.ResumeLayout(false);
            this.navigationBar.PerformLayout();
            this.rootLayout.ResumeLayout(false);
            this.rootLayout.PerformLayout();
            this.browserSplitContainer.Panel1.ResumeLayout(false);
            this.browserSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browserSplitContainer)).EndInit();
            this.browserSplitContainer.ResumeLayout(false);
            this.downloadsPanel.ResumeLayout(false);
            this.downloadsPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
        }

        private void ConfigureToolbarButton(System.Windows.Forms.Button button, string text, string accessibleName, int tabIndex)
        {
            button.AccessibleName = accessibleName;
            button.BackColor = System.Drawing.Color.White;
            button.Dock = System.Windows.Forms.DockStyle.Fill;
            button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Segoe UI", 9F);
            button.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            button.Name = accessibleName.Replace(" ", string.Empty).ToLowerInvariant() + "Button";
            button.TabIndex = tabIndex;
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }
    }
}
