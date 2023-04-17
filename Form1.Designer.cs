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
            CubeBTN = new Button();
            ConeBTN = new Button();
            CylinderBTN = new Button();
            SphereBTN = new Button();
            SemiSphere = new Button();
            ScaleField = new TextBox();
            RotField = new TextBox();
            label1 = new Label();
            label2 = new Label();
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
            // CubeBTN
            // 
            CubeBTN.Location = new Point(82, 559);
            CubeBTN.Name = "CubeBTN";
            CubeBTN.Size = new Size(75, 23);
            CubeBTN.TabIndex = 7;
            CubeBTN.Text = "Cube";
            CubeBTN.UseVisualStyleBackColor = true;
            CubeBTN.Click += CubeBTN_Click;
            // 
            // ConeBTN
            // 
            ConeBTN.Location = new Point(195, 559);
            ConeBTN.Name = "ConeBTN";
            ConeBTN.Size = new Size(75, 23);
            ConeBTN.TabIndex = 8;
            ConeBTN.Text = "Cone";
            ConeBTN.UseVisualStyleBackColor = true;
            ConeBTN.Click += ConeBTN_Click;
            // 
            // CylinderBTN
            // 
            CylinderBTN.Location = new Point(298, 559);
            CylinderBTN.Name = "CylinderBTN";
            CylinderBTN.Size = new Size(75, 23);
            CylinderBTN.TabIndex = 9;
            CylinderBTN.Text = "Cylinder";
            CylinderBTN.UseVisualStyleBackColor = true;
            CylinderBTN.Click += CylinderBTN_Click;
            // 
            // SphereBTN
            // 
            SphereBTN.Location = new Point(403, 559);
            SphereBTN.Name = "SphereBTN";
            SphereBTN.Size = new Size(75, 23);
            SphereBTN.TabIndex = 10;
            SphereBTN.Text = "Sphere";
            SphereBTN.UseVisualStyleBackColor = true;
            SphereBTN.Click += SphereBTN_Click;
            // 
            // SemiSphere
            // 
            SemiSphere.Location = new Point(508, 559);
            SemiSphere.Name = "SemiSphere";
            SemiSphere.Size = new Size(88, 23);
            SemiSphere.TabIndex = 11;
            SemiSphere.Text = "Semi Sphere";
            SemiSphere.UseVisualStyleBackColor = true;
            SemiSphere.Click += SemiSphere_Click;
            // 
            // ScaleField
            // 
            ScaleField.Location = new Point(912, 547);
            ScaleField.Name = "ScaleField";
            ScaleField.Size = new Size(89, 23);
            ScaleField.TabIndex = 12;
            ScaleField.KeyPress += ScaleField_KeyPress;
            // 
            // RotField
            // 
            RotField.Location = new Point(912, 576);
            RotField.Name = "RotField";
            RotField.Size = new Size(89, 23);
            RotField.TabIndex = 13;
            RotField.KeyPress += RotField_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(867, 559);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 14;
            label1.Text = "Scale:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(810, 579);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 15;
            label2.Text = "Rotation Speed:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(1028, 609);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RotField);
            Controls.Add(ScaleField);
            Controls.Add(SemiSphere);
            Controls.Add(SphereBTN);
            Controls.Add(CylinderBTN);
            Controls.Add(ConeBTN);
            Controls.Add(CubeBTN);
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
            PerformLayout();
        }

        #endregion
        private Button rotBTN;
        private Button rotBTN2;
        private Button rotBTN3;
        private Button rotBTN4;
        private System.Windows.Forms.Timer rotTimer;
        private PictureBox PCT_CANVAS;
        private Button ObjBTN;
        private Button CubeBTN;
        private Button ConeBTN;
        private Button CylinderBTN;
        private Button SphereBTN;
        private Button SemiSphere;
        private TextBox ScaleField;
        private TextBox RotField;
        private Label label1;
        private Label label2;
    }
}