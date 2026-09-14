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
        private System.Windows.Forms.TableLayoutPanel navigationBar;
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
            this.navigationBar = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.navigationBar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            //
            // browser
            //
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 42);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.TabIndex = 1;
            this.browser.CanGoBackChanged += new System.EventHandler(this.browser_CanGoBackChanged);
            this.browser.CanGoForwardChanged += new System.EventHandler(this.browser_CanGoForwardChanged);
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            this.browser.DocumentTitleChanged += new System.EventHandler(this.browser_DocumentTitleChanged);
            this.browser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.browser_Navigated);
            this.browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browser_Navigating);
            this.browser.NewWindow += new System.ComponentModel.CancelEventHandler(this.browser_NewWindow);
            this.browser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.browser_ProgressChanged);
            this.browser.StatusTextChanged += new System.EventHandler(this.browser_StatusTextChanged);
            //
            // addressBox
            //
            this.addressBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressBox.Location = new System.Drawing.Point(249, 9);
            this.addressBox.Margin = new System.Windows.Forms.Padding(3, 9, 3, 8);
            this.addressBox.MaxLength = 2048;
            this.addressBox.Name = "addressBox";
            this.addressBox.TabIndex = 4;
            //
            // backButton
            //
            this.backButton.AutoSize = true;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backButton.Name = "backButton";
            this.backButton.TabIndex = 0;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            //
            // forwardButton
            //
            this.forwardButton.AutoSize = true;
            this.forwardButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.TabIndex = 1;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            //
            // refreshButton
            //
            this.refreshButton.AutoSize = true;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            //
            // homeButton
            //
            this.homeButton.AutoSize = true;
            this.homeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeButton.Name = "homeButton";
            this.homeButton.TabIndex = 3;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            this.homeButton.Click += new System.EventHandler(this.homeButton_Click);
            //
            // goButton
            //
            this.goButton.AutoSize = true;
            this.goButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goButton.Name = "goButton";
            this.goButton.TabIndex = 5;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            //
            // navigationBar
            //
            this.navigationBar.AutoSize = true;
            this.navigationBar.ColumnCount = 6;
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.navigationBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.navigationBar.Controls.Add(this.backButton, 0, 0);
            this.navigationBar.Controls.Add(this.forwardButton, 1, 0);
            this.navigationBar.Controls.Add(this.refreshButton, 2, 0);
            this.navigationBar.Controls.Add(this.homeButton, 3, 0);
            this.navigationBar.Controls.Add(this.addressBox, 4, 0);
            this.navigationBar.Controls.Add(this.goButton, 5, 0);
            this.navigationBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.navigationBar.Location = new System.Drawing.Point(0, 0);
            this.navigationBar.Name = "navigationBar";
            this.navigationBar.Padding = new System.Windows.Forms.Padding(6);
            this.navigationBar.RowCount = 1;
            this.navigationBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.navigationBar.TabIndex = 0;
            //
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 578);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.TabIndex = 2;
            //
            // statusLabel
            //
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Ready";
            //
            // Form1
            //
            this.AcceptButton = this.goButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 600);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.navigationBar);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lilbrowser";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.navigationBar.ResumeLayout(false);
            this.navigationBar.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
