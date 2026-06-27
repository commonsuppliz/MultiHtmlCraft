using MultiHtmlCraft.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.WinformsControl
{
    public class CHtmlWebObjectDetails : System.Windows.Forms.Form 
    {
        private System.Windows.Forms.TextBox txtObjectTitle;
        private System.Windows.Forms.TextBox txtObjectDetail;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        public CHtmlWebObjectDetails(string elementDetail, object _objectDetail)
        {
            InitializeComponent();
            this.SuspendLayout();
            switch (elementDetail)
            {
                case "Element":
                    this.Text = "Element Details";
                    break;
                case "Attribute":
                    this.Text = "Attribute Details";
                    break;
                case "Style":
                    this.Text = "Style Details";
                    break;
                case "Event":
                    this.Text = "Event Details";
                    break;
                case "Script":
                    this.Text = "Script Details";
                    this.txtObjectTitle.Height = 150; // Increase height for script details
                    this.txtObjectDetail.Height = 300; // Increase height for script details
                    if(_objectDetail != null)
                    {
                        var scriptResult = _objectDetail as CHtmlScriptResult;
                        if (scriptResult != null)
                        {
                            txtObjectTitle.Text = scriptResult.text;
                            this.Text = string.Format("{0} : {1}", scriptResult.result, scriptResult.Url);
                            if (scriptResult.result == 200)
                            {
                                txtObjectDetail.Text = "OK";
                            }
                            else
                            {
                                txtObjectDetail.Text = scriptResult.errorDetail;
                            }
                           
                        }

                    }
                    else
                    {
                        txtObjectDetail.Text = "No script content available.";
                    }
                    break;
                case "CSS":
                    this.Text = "CSS Details";
                    break;
                default:
                    this.Text = "Details";
                    break;
            }
           
            this.ResumeLayout(false);
        }
        public CHtmlWebObjectDetails()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            txtObjectTitle = new System.Windows.Forms.TextBox();
            txtObjectDetail = new System.Windows.Forms.TextBox();
            btnClose = new System.Windows.Forms.Button();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // txtObjectTitle
            // 
            txtObjectTitle.Location = new System.Drawing.Point(0, 0);
            txtObjectTitle.Multiline = true;
            txtObjectTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            txtObjectTitle.Name = "txtObjectTitle";
            txtObjectTitle.ReadOnly = true;
            txtObjectTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObjectTitle.Size = new System.Drawing.Size(513, 11);
            txtObjectTitle.TabIndex = 0;
            // 
            // txtObjectDetail
            // 
            txtObjectDetail.AcceptsReturn = true;
            txtObjectDetail.Location = new System.Drawing.Point(0,0);
            txtObjectDetail.Multiline = true;
            txtObjectDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            txtObjectDetail.Name = "txtObjectDetail";
            txtObjectDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObjectDetail.Size = new System.Drawing.Size(800, 450);
            txtObjectDetail.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnClose.Location = new System.Drawing.Point(0, 420);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(800, 30);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtObjectTitle);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtObjectDetail);
            splitContainer1.Size = new System.Drawing.Size(188, 125);
            splitContainer1.SplitterDistance = 62;
            splitContainer1.TabIndex = 3;
            // 
            // CHtmlWebObjectDetails
            // 
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(btnClose);
            Name = "CHtmlWebObjectDetails";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
