namespace MergeTwoSidedScanPages
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
            this.side1Path = new System.Windows.Forms.Label();
            this.side2Path = new System.Windows.Forms.Label();
            this.outputPath = new System.Windows.Forms.Label();
            this.textSide1 = new System.Windows.Forms.TextBox();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.textSide2 = new System.Windows.Forms.TextBox();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.btnInterleave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // side1Path
            // 
            this.side1Path.AutoSize = true;
            this.side1Path.Location = new System.Drawing.Point(12, 25);
            this.side1Path.Name = "side1Path";
            this.side1Path.Size = new System.Drawing.Size(129, 13);
            this.side1Path.TabIndex = 0;
            this.side1Path.Text = "Choose Side-1 input path:";
            this.side1Path.Click += new System.EventHandler(this.Side1Path_Click);
            // 
            // side2Path
            // 
            this.side2Path.AutoSize = true;
            this.side2Path.Location = new System.Drawing.Point(12, 73);
            this.side2Path.Name = "side2Path";
            this.side2Path.Size = new System.Drawing.Size(129, 13);
            this.side2Path.TabIndex = 1;
            this.side2Path.Text = "Choose Side-2 input path:";
            this.side2Path.Click += new System.EventHandler(this.Side2Path_Click);
            // 
            // outputPath
            // 
            this.outputPath.AutoSize = true;
            this.outputPath.Location = new System.Drawing.Point(36, 121);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(105, 13);
            this.outputPath.TabIndex = 2;
            this.outputPath.Text = "Choose Output path:";
            this.outputPath.Click += new System.EventHandler(this.OutputPath_Click);
            // 
            // textSide1
            // 
            this.textSide1.Location = new System.Drawing.Point(147, 22);
            this.textSide1.Name = "textSide1";
            this.textSide1.Size = new System.Drawing.Size(744, 20);
            this.textSide1.TabIndex = 3;
            this.textSide1.Text = "H:\\OneDrive\\documents\\Moving to US - Tucson\\Taiwan - Medical Records\\Taipei City " +
    "Hospital - Both Branches\\Side-1s";
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(147, 118);
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(744, 20);
            this.textOutput.TabIndex = 4;
            this.textOutput.Text = "H:\\OneDrive\\documents\\Moving to US - Tucson\\Taiwan - Medical Records\\Taipei City " +
    "Hospital - Both Branches";
            // 
            // textSide2
            // 
            this.textSide2.Location = new System.Drawing.Point(147, 70);
            this.textSide2.Name = "textSide2";
            this.textSide2.Size = new System.Drawing.Size(744, 20);
            this.textSide2.TabIndex = 5;
            this.textSide2.Text = "H:\\OneDrive\\documents\\Moving to US - Tucson\\Taiwan - Medical Records\\Taipei City " +
    "Hospital - Both Branches\\Side-2s";
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(147, 230);
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(744, 20);
            this.textStatus.TabIndex = 6;
            // 
            // btnInterleave
            // 
            this.btnInterleave.Location = new System.Drawing.Point(15, 160);
            this.btnInterleave.Name = "btnInterleave";
            this.btnInterleave.Size = new System.Drawing.Size(70, 38);
            this.btnInterleave.TabIndex = 7;
            this.btnInterleave.Text = "Interleave";
            this.btnInterleave.UseVisualStyleBackColor = true;
            this.btnInterleave.Click += new System.EventHandler(this.BtnInterleave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(147, 160);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 38);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Status:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnInterleave);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.textSide2);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.textSide1);
            this.Controls.Add(this.outputPath);
            this.Controls.Add(this.side2Path);
            this.Controls.Add(this.side1Path);
            this.Name = "Form1";
            this.Text = "Interleave Side1 and Side2 of Two-Sided document scanned in two parts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label side1Path;
        private System.Windows.Forms.Label side2Path;
        private System.Windows.Forms.Label outputPath;
        private System.Windows.Forms.TextBox textSide1;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.TextBox textSide2;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.Button btnInterleave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
    }
}

