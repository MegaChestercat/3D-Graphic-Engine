namespace Optimized_3D_Graphic_Engine
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
            components = new System.ComponentModel.Container();
            rotBTN = new Button();
            rotBTN2 = new Button();
            rotBTN3 = new Button();
            rotBTN4 = new Button();
            rotTimer = new System.Windows.Forms.Timer(components);
            PCT_CANVAS = new PictureBox();
            ObjBTN = new Button();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            SuspendLayout();
            // 
            // rotBTN
            // 
            rotBTN.Location = new Point(918, 165);
            rotBTN.Name = "rotBTN";
            rotBTN.Size = new Size(75, 23);
            rotBTN.TabIndex = 1;
            rotBTN.Text = "Rot in X";
            rotBTN.UseVisualStyleBackColor = true;
            rotBTN.Click += rotBTN_Click;
            // 
            // rotBTN2
            // 
            rotBTN2.Location = new Point(918, 241);
            rotBTN2.Name = "rotBTN2";
            rotBTN2.Size = new Size(75, 23);
            rotBTN2.TabIndex = 2;
            rotBTN2.Text = "Rot in Y";
            rotBTN2.UseVisualStyleBackColor = true;
            rotBTN2.Click += rotBTN2_Click;
            // 
            // rotBTN3
            // 
            rotBTN3.Location = new Point(918, 326);
            rotBTN3.Name = "rotBTN3";
            rotBTN3.Size = new Size(75, 23);
            rotBTN3.TabIndex = 3;
            rotBTN3.Text = "Rot in Z";
            rotBTN3.UseVisualStyleBackColor = true;
            rotBTN3.Click += rotBTN3_Click;
            // 
            // rotBTN4
            // 
            rotBTN4.Location = new Point(918, 396);
            rotBTN4.Name = "rotBTN4";
            rotBTN4.Size = new Size(75, 46);
            rotBTN4.TabIndex = 4;
            rotBTN4.Text = "Rot in all axis";
            rotBTN4.UseVisualStyleBackColor = true;
            rotBTN4.Click += rotBTN4_Click;
            // 
            // rotTimer
            // 
            rotTimer.Enabled = true;
            rotTimer.Interval = 40;
            rotTimer.Tick += rotTimer_Tick;
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.BackColor = SystemColors.ActiveCaptionText;
            PCT_CANVAS.Location = new Point(45, 36);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(845, 497);
            PCT_CANVAS.TabIndex = 5;
            PCT_CANVAS.TabStop = false;
            // 
            // ObjBTN
            // 
            ObjBTN.Location = new Point(918, 79);
            ObjBTN.Name = "ObjBTN";
            ObjBTN.Size = new Size(75, 46);
            ObjBTN.TabIndex = 6;
            ObjBTN.Text = "Open OBJ File";
            ObjBTN.UseVisualStyleBackColor = true;
            ObjBTN.Click += ObjBTN_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1028, 609);
            Controls.Add(ObjBTN);
            Controls.Add(PCT_CANVAS);
            Controls.Add(rotBTN4);
            Controls.Add(rotBTN3);
            Controls.Add(rotBTN2);
            Controls.Add(rotBTN);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button rotBTN;
        private Button rotBTN2;
        private Button rotBTN3;
        private Button rotBTN4;
        private System.Windows.Forms.Timer rotTimer;
        private PictureBox PCT_CANVAS;
        private Button ObjBTN;
    }
}