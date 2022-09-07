namespace Summer_Practice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TurningTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.StartStopButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.TurnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TurningTimer
            // 
            this.TurningTimer.Interval = 1000;
            this.TurningTimer.Tick += new System.EventHandler(this.TurningTimer_Tick);
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(12, 147);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(80, 30);
            this.StartStopButton.TabIndex = 0;
            this.StartStopButton.Text = "START/STOP";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // RestartButton
            // 
            this.RestartButton.Location = new System.Drawing.Point(12, 105);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(75, 25);
            this.RestartButton.TabIndex = 2;
            this.RestartButton.Text = "RESTART";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // TurnButton
            // 
            this.TurnButton.Location = new System.Drawing.Point(12, 36);
            this.TurnButton.Name = "TurnButton";
            this.TurnButton.Size = new System.Drawing.Size(75, 23);
            this.TurnButton.TabIndex = 3;
            this.TurnButton.Text = "button1";
            this.TurnButton.UseVisualStyleBackColor = true;
            this.TurnButton.Visible = false;
            this.TurnButton.Click += new System.EventHandler(this.TurnButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 635);
            this.Controls.Add(this.TurnButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartStopButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TurningTimer;
        private ToolTip toolTip1;
        private Button StartStopButton;
        private Label label1;
        private Button RestartButton;
        private Button TurnButton;
    }
}