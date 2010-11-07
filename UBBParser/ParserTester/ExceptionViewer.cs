/*
	This file is part of HnD.
	HnD is (c) 2002-2006 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ParserTester
{
	/// <summary>
	/// Generic Exception viewer.
	/// </summary>
	internal class ExceptionViewer : System.Windows.Forms.Form
	{
		#region Class Member Declaration
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button _closeButton;
		private Exception _exception;
		private System.Windows.Forms.TextBox _sourceTextBox;
		private System.Windows.Forms.RichTextBox _stackTraceTextBox;
		private System.Windows.Forms.RichTextBox _messageTextBox;
		private System.ComponentModel.Container components = null;
		#endregion

		public ExceptionViewer()
		{
			InitializeComponent();
		}

		public ExceptionViewer(Exception exceptionToView)
		{
			InitializeComponent();
			_exception = exceptionToView;
			ViewExceptionInWindow();
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		/// <summary>
		/// Purpose: will load the private membervariable m_kexException's data
		/// into the windows' controls and thus view it. Set m_kexException with the
		/// property kexException.
		/// </summary>
		public void ViewExceptionInWindow()
		{
			if(_exception==null)
			{
				// no exception loaded
				_messageTextBox.Text = "No exception loaded into window: can't visualize exception";
				return;
			}
			// visualize the exception.
			_stackTraceTextBox.SelectionBullet=true;
			_messageTextBox.SelectionBullet=true;
			_messageTextBox.Text += _exception.Message + Environment.NewLine;
			_sourceTextBox.Text += _exception.Source + Environment.NewLine;
			_stackTraceTextBox.Text += "-----[Core exception]--------------------" + Environment.NewLine;
			_stackTraceTextBox.Text += _exception.StackTrace + Environment.NewLine;
			// go into the inner exceptions.
			for(Exception innerException = _exception.InnerException;
				innerException!=null;innerException = innerException.InnerException)
			{
				_messageTextBox.Text += innerException.Message + Environment.NewLine;
				_sourceTextBox.Text += innerException.Source + Environment.NewLine;
				_stackTraceTextBox.Text += "-----[InnerException]--------------------" + Environment.NewLine;
				_stackTraceTextBox.Text += innerException.StackTrace + Environment.NewLine;
			}
			// strip extra newline from boxes
			_messageTextBox.Text = _messageTextBox.Text.Substring(0,_messageTextBox.Text.Length-1);
			_sourceTextBox.Text = _sourceTextBox.Text.Substring(0,_sourceTextBox.Text.Length);
			_stackTraceTextBox.Text = _stackTraceTextBox.Text.Substring(0,_stackTraceTextBox.Text.Length-1);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._messageTextBox = new System.Windows.Forms.RichTextBox();
			this._stackTraceTextBox = new System.Windows.Forms.RichTextBox();
			this._sourceTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._closeButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(503, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "An exception occured. Below is the general information about this exception. Clic" +
				"k Close to close this window to resume.";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this._messageTextBox);
			this.groupBox1.Controls.Add(this._stackTraceTextBox);
			this.groupBox1.Controls.Add(this._sourceTextBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(4, 54);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(525, 451);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = ".NET Exception information";
			// 
			// _messageTextBox
			// 
			this._messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._messageTextBox.BulletIndent = 10;
			this._messageTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._messageTextBox.Location = new System.Drawing.Point(8, 36);
			this._messageTextBox.Name = "_messageTextBox";
			this._messageTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this._messageTextBox.Size = new System.Drawing.Size(511, 88);
			this._messageTextBox.TabIndex = 2;
			this._messageTextBox.Text = "";
			// 
			// _stackTraceTextBox
			// 
			this._stackTraceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._stackTraceTextBox.BackColor = System.Drawing.SystemColors.Window;
			this._stackTraceTextBox.BulletIndent = 10;
			this._stackTraceTextBox.CausesValidation = false;
			this._stackTraceTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._stackTraceTextBox.Location = new System.Drawing.Point(8, 148);
			this._stackTraceTextBox.Name = "_stackTraceTextBox";
			this._stackTraceTextBox.ReadOnly = true;
			this._stackTraceTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this._stackTraceTextBox.Size = new System.Drawing.Size(511, 218);
			this._stackTraceTextBox.TabIndex = 3;
			this._stackTraceTextBox.Text = "";
			// 
			// _sourceTextBox
			// 
			this._sourceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._sourceTextBox.BackColor = System.Drawing.SystemColors.Window;
			this._sourceTextBox.Location = new System.Drawing.Point(8, 390);
			this._sourceTextBox.Multiline = true;
			this._sourceTextBox.Name = "_sourceTextBox";
			this._sourceTextBox.ReadOnly = true;
			this._sourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this._sourceTextBox.Size = new System.Drawing.Size(509, 52);
			this._sourceTextBox.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.Location = new System.Drawing.Point(8, 374);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 16);
			this.label6.TabIndex = 4;
			this.label6.Text = "Source";
			// 
			// label5
			// 
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label5.Location = new System.Drawing.Point(8, 132);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(188, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Stack trace";
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.Location = new System.Drawing.Point(8, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Message";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(535, 48);
			this.label3.TabIndex = 3;
			// 
			// _closeButton
			// 
			this._closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._closeButton.Location = new System.Drawing.Point(239, 511);
			this._closeButton.Name = "_closeButton";
			this._closeButton.Size = new System.Drawing.Size(48, 24);
			this._closeButton.TabIndex = 5;
			this._closeButton.Text = "Close";
			this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
			// 
			// ExceptionViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(535, 541);
			this.Controls.Add(this._closeButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Exception Viewer";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion

		private void _closeButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// Purpose: sets the membervariable _exception which is visualized
		/// in the windows controls using ViewExceptionInWindow()
		/// </summary>
		public Exception ExceptionToView
		{
			set
			{
				_exception = value;
			}
		}
	}
}
