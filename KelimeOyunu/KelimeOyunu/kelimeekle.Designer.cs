
namespace KelimeOyunu
{
    partial class kelimeekle
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
            this.soruBox = new System.Windows.Forms.TextBox();
            this.cevapBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kelimeekleButon = new System.Windows.Forms.Button();
            this.iptalButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // soruBox
            // 
            this.soruBox.AllowDrop = true;
            this.soruBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.soruBox.Location = new System.Drawing.Point(84, 11);
            this.soruBox.Multiline = true;
            this.soruBox.Name = "soruBox";
            this.soruBox.Size = new System.Drawing.Size(379, 85);
            this.soruBox.TabIndex = 0;
            this.soruBox.Text = "Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru Soru";
            // 
            // cevapBox
            // 
            this.cevapBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cevapBox.Location = new System.Drawing.Point(84, 102);
            this.cevapBox.Multiline = true;
            this.cevapBox.Name = "cevapBox";
            this.cevapBox.Size = new System.Drawing.Size(196, 30);
            this.cevapBox.TabIndex = 1;
            this.cevapBox.Text = "cevap cevap cevap";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Soru :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cevap :";
            // 
            // kelimeekleButon
            // 
            this.kelimeekleButon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.kelimeekleButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kelimeekleButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kelimeekleButon.Location = new System.Drawing.Point(59, 146);
            this.kelimeekleButon.Name = "kelimeekleButon";
            this.kelimeekleButon.Size = new System.Drawing.Size(132, 81);
            this.kelimeekleButon.TabIndex = 4;
            this.kelimeekleButon.Text = "EKLE";
            this.kelimeekleButon.UseVisualStyleBackColor = false;
            this.kelimeekleButon.Click += new System.EventHandler(this.kelimeekleButon_Click);
            // 
            // iptalButon
            // 
            this.iptalButon.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.iptalButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iptalButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptalButon.Location = new System.Drawing.Point(300, 146);
            this.iptalButon.Name = "iptalButon";
            this.iptalButon.Size = new System.Drawing.Size(124, 81);
            this.iptalButon.TabIndex = 5;
            this.iptalButon.Text = "İPTAL";
            this.iptalButon.UseVisualStyleBackColor = false;
            this.iptalButon.Click += new System.EventHandler(this.iptalButon_Click);
            // 
            // kelimeekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(475, 239);
            this.Controls.Add(this.iptalButon);
            this.Controls.Add(this.kelimeekleButon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cevapBox);
            this.Controls.Add(this.soruBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "kelimeekle";
            this.Text = "Kelime / Soru Ekle";
            this.Load += new System.EventHandler(this.kelimeekle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox soruBox;
        private System.Windows.Forms.TextBox cevapBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button kelimeekleButon;
        private System.Windows.Forms.Button iptalButon;
    }
}