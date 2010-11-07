namespace ParserTester
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this._textToParseTextBox = new System.Windows.Forms.TextBox();
			this._startParseButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this._inputFilenameTextBox = new System.Windows.Forms.TextBox();
			this._loadInputButton = new System.Windows.Forms.Button();
			this._mainTabControl = new System.Windows.Forms.TabControl();
			this._inputoutputTab = new System.Windows.Forms.TabPage();
			this._parseLogTab = new System.Windows.Forms.TabPage();
			this._parseTreeTreeView = new System.Windows.Forms.TreeView();
			this.label5 = new System.Windows.Forms.Label();
			this._logTextBox = new System.Windows.Forms.TextBox();
			this._destinationFileTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._mainTabControl.SuspendLayout();
			this._inputoutputTab.SuspendLayout();
			this._parseLogTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text to parse";
			// 
			// _textToParseTextBox
			// 
			this._textToParseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._textToParseTextBox.Location = new System.Drawing.Point(81, 34);
			this._textToParseTextBox.MaxLength = 99999999;
			this._textToParseTextBox.Multiline = true;
			this._textToParseTextBox.Name = "_textToParseTextBox";
			this._textToParseTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._textToParseTextBox.Size = new System.Drawing.Size(584, 362);
			this._textToParseTextBox.TabIndex = 1;
			// 
			// _startParseButton
			// 
			this._startParseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._startParseButton.Location = new System.Drawing.Point(81, 402);
			this._startParseButton.Name = "_startParseButton";
			this._startParseButton.Size = new System.Drawing.Size(125, 23);
			this._startParseButton.TabIndex = 2;
			this._startParseButton.Text = "Start parse";
			this._startParseButton.UseVisualStyleBackColor = true;
			this._startParseButton.Click += new System.EventHandler(this._startParseButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "UBB Input file";
			// 
			// _inputFilenameTextBox
			// 
			this._inputFilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._inputFilenameTextBox.Location = new System.Drawing.Point(81, 8);
			this._inputFilenameTextBox.Name = "_inputFilenameTextBox";
			this._inputFilenameTextBox.Size = new System.Drawing.Size(503, 20);
			this._inputFilenameTextBox.TabIndex = 3;
			// 
			// _loadInputButton
			// 
			this._loadInputButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._loadInputButton.Location = new System.Drawing.Point(590, 6);
			this._loadInputButton.Name = "_loadInputButton";
			this._loadInputButton.Size = new System.Drawing.Size(75, 23);
			this._loadInputButton.TabIndex = 5;
			this._loadInputButton.Text = "Load";
			this._loadInputButton.UseVisualStyleBackColor = true;
			this._loadInputButton.Click += new System.EventHandler(this._loadInputButton_Click);
			// 
			// _mainTabControl
			// 
			this._mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._mainTabControl.Controls.Add(this._inputoutputTab);
			this._mainTabControl.Controls.Add(this._parseLogTab);
			this._mainTabControl.Location = new System.Drawing.Point(6, 6);
			this._mainTabControl.Name = "_mainTabControl";
			this._mainTabControl.SelectedIndex = 0;
			this._mainTabControl.Size = new System.Drawing.Size(679, 582);
			this._mainTabControl.TabIndex = 6;
			// 
			// _inputoutputTab
			// 
			this._inputoutputTab.Controls.Add(this._logTextBox);
			this._inputoutputTab.Controls.Add(this._destinationFileTextBox);
			this._inputoutputTab.Controls.Add(this.label2);
			this._inputoutputTab.Controls.Add(this.label3);
			this._inputoutputTab.Controls.Add(this._textToParseTextBox);
			this._inputoutputTab.Controls.Add(this._loadInputButton);
			this._inputoutputTab.Controls.Add(this.label1);
			this._inputoutputTab.Controls.Add(this.label4);
			this._inputoutputTab.Controls.Add(this._inputFilenameTextBox);
			this._inputoutputTab.Controls.Add(this._startParseButton);
			this._inputoutputTab.Location = new System.Drawing.Point(4, 22);
			this._inputoutputTab.Name = "_inputoutputTab";
			this._inputoutputTab.Padding = new System.Windows.Forms.Padding(3);
			this._inputoutputTab.Size = new System.Drawing.Size(671, 556);
			this._inputoutputTab.TabIndex = 0;
			this._inputoutputTab.Text = "Input / Output";
			this._inputoutputTab.UseVisualStyleBackColor = true;
			// 
			// _parseLogTab
			// 
			this._parseLogTab.Controls.Add(this.label5);
			this._parseLogTab.Controls.Add(this._parseTreeTreeView);
			this._parseLogTab.Location = new System.Drawing.Point(4, 22);
			this._parseLogTab.Name = "_parseLogTab";
			this._parseLogTab.Padding = new System.Windows.Forms.Padding(3);
			this._parseLogTab.Size = new System.Drawing.Size(671, 556);
			this._parseLogTab.TabIndex = 1;
			this._parseLogTab.Text = "Parser output info";
			this._parseLogTab.UseVisualStyleBackColor = true;
			// 
			// _parseTreeTreeView
			// 
			this._parseTreeTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._parseTreeTreeView.Location = new System.Drawing.Point(5, 19);
			this._parseTreeTreeView.Name = "_parseTreeTreeView";
			this._parseTreeTreeView.Size = new System.Drawing.Size(662, 531);
			this._parseTreeTreeView.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(2, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Parse tree";
			// 
			// _logTextBox
			// 
			this._logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._logTextBox.Location = new System.Drawing.Point(81, 442);
			this._logTextBox.MaxLength = 999999999;
			this._logTextBox.Multiline = true;
			this._logTextBox.Name = "_logTextBox";
			this._logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._logTextBox.Size = new System.Drawing.Size(584, 82);
			this._logTextBox.TabIndex = 9;
			// 
			// _destinationFileTextBox
			// 
			this._destinationFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._destinationFileTextBox.Location = new System.Drawing.Point(111, 530);
			this._destinationFileTextBox.Name = "_destinationFileTextBox";
			this._destinationFileTextBox.Size = new System.Drawing.Size(554, 20);
			this._destinationFileTextBox.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 533);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "XML destination file";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 445);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Output log";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(689, 592);
			this.Controls.Add(this._mainTabControl);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "UBB to Xml parser tester";
			this._mainTabControl.ResumeLayout(false);
			this._inputoutputTab.ResumeLayout(false);
			this._inputoutputTab.PerformLayout();
			this._parseLogTab.ResumeLayout(false);
			this._parseLogTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _textToParseTextBox;
		private System.Windows.Forms.Button _startParseButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _inputFilenameTextBox;
		private System.Windows.Forms.Button _loadInputButton;
		private System.Windows.Forms.TabControl _mainTabControl;
		private System.Windows.Forms.TabPage _inputoutputTab;
		private System.Windows.Forms.TabPage _parseLogTab;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TreeView _parseTreeTreeView;
		private System.Windows.Forms.TextBox _logTextBox;
		private System.Windows.Forms.TextBox _destinationFileTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}

