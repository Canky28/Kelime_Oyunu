
namespace KelimeOyunu
{
    partial class oyna
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
            this.components = new System.ComponentModel.Container();
            this.baslaButon = new System.Windows.Forms.Button();
            this.iptalButon = new System.Windows.Forms.Button();
            this.IsimBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // baslaButon
            // 
            this.baslaButon.Location = new System.Drawing.Point(12, 78);
            this.baslaButon.Name = "baslaButon";
            this.baslaButon.Size = new System.Drawing.Size(110, 52);
            this.baslaButon.TabIndex = 0;
            this.baslaButon.Text = "BAŞLA";
            this.baslaButon.UseVisualStyleBackColor = true;
            this.baslaButon.Click += new System.EventHandler(this.baslaButon_Click);
            // 
            // iptalButon
            // 
            this.iptalButon.Location = new System.Drawing.Point(165, 78);
            this.iptalButon.Name = "iptalButon";
            this.iptalButon.Size = new System.Drawing.Size(99, 52);
            this.iptalButon.TabIndex = 1;
            this.iptalButon.Text = "İPTAL";
            this.iptalButon.UseVisualStyleBackColor = true;
            this.iptalButon.Click += new System.EventHandler(this.iptalButon_Click);
            // 
            // IsimBox
            // 
            this.IsimBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsimBox.Location = new System.Drawing.Point(93, 25);
            this.IsimBox.Name = "IsimBox";
            this.IsimBox.Size = new System.Drawing.Size(175, 26);
            this.IsimBox.TabIndex = 2;
            this.IsimBox.Text = "İsminiz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "İsminiz :";
            // 
            // oyna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(276, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IsimBox);
            this.Controls.Add(this.iptalButon);
            this.Controls.Add(this.baslaButon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "oyna";
            this.Text = "Oyna";
            this.Load += new System.EventHandler(this.oyna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baslaButon;
        private System.Windows.Forms.Button iptalButon;
        private System.Windows.Forms.TextBox IsimBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer date;
    }
}