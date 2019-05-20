namespace Media_Registration
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.cboTapeType = new System.Windows.Forms.ComboBox();
            this.cboMovementType = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(12, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(391, 45);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "BROWSE";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(12, 63);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(391, 265);
            this.txtDisplay.TabIndex = 4;
            // 
            // cboTapeType
            // 
            this.cboTapeType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboTapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTapeType.FormattingEnabled = true;
            this.cboTapeType.Location = new System.Drawing.Point(12, 334);
            this.cboTapeType.Name = "cboTapeType";
            this.cboTapeType.Size = new System.Drawing.Size(391, 24);
            this.cboTapeType.TabIndex = 5;
            // 
            // cboMovementType
            // 
            this.cboMovementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMovementType.FormattingEnabled = true;
            this.cboMovementType.Location = new System.Drawing.Point(12, 364);
            this.cboMovementType.Name = "cboMovementType";
            this.cboMovementType.Size = new System.Drawing.Size(391, 24);
            this.cboMovementType.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(12, 395);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(391, 51);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create File";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(413, 449);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cboMovementType);
            this.Controls.Add(this.cboTapeType);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.btnBrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Media Registration File Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.ComboBox cboTapeType;
        private System.Windows.Forms.ComboBox cboMovementType;
        private System.Windows.Forms.Button btnCreate;
    }
}

