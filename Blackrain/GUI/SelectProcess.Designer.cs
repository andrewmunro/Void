namespace BlackRain.GUI
{
    partial class SelectProcess
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
            this.lbl_SelectProcess = new System.Windows.Forms.Label();
            this.cmb_Processes = new System.Windows.Forms.ComboBox();
            this.btn_Attach = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_SelectProcess
            // 
            this.lbl_SelectProcess.AutoSize = true;
            this.lbl_SelectProcess.Location = new System.Drawing.Point(12, 9);
            this.lbl_SelectProcess.Name = "lbl_SelectProcess";
            this.lbl_SelectProcess.Size = new System.Drawing.Size(233, 13);
            this.lbl_SelectProcess.TabIndex = 0;
            this.lbl_SelectProcess.Text = "Select a World of Warcraft process to attach to:";
            // 
            // cmb_Processes
            // 
            this.cmb_Processes.FormattingEnabled = true;
            this.cmb_Processes.Location = new System.Drawing.Point(15, 25);
            this.cmb_Processes.Name = "cmb_Processes";
            this.cmb_Processes.Size = new System.Drawing.Size(389, 21);
            this.cmb_Processes.TabIndex = 1;
            // 
            // btn_Attach
            // 
            this.btn_Attach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Attach.Location = new System.Drawing.Point(329, 52);
            this.btn_Attach.Name = "btn_Attach";
            this.btn_Attach.Size = new System.Drawing.Size(75, 23);
            this.btn_Attach.TabIndex = 2;
            this.btn_Attach.Text = "Attach";
            this.btn_Attach.UseVisualStyleBackColor = true;
            this.btn_Attach.Click += new System.EventHandler(this.btn_Attach_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Location = new System.Drawing.Point(248, 52);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // SelectProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 88);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Attach);
            this.Controls.Add(this.cmb_Processes);
            this.Controls.Add(this.lbl_SelectProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectProcess";
            this.ShowIcon = false;
            this.Text = "Select Process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectProcess;
        private System.Windows.Forms.ComboBox cmb_Processes;
        private System.Windows.Forms.Button btn_Attach;
        private System.Windows.Forms.Button btn_Refresh;
    }
}