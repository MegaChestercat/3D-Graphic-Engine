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
            treeView1 = new TreeView();
            label3 = new Label();
            label4 = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            label5 = new Label();
            trackBar4 = new TrackBar();
            trackBar5 = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            trackBar6 = new TrackBar();
            trackBar7 = new TrackBar();
            label10 = new Label();
            DrawMode = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            checkBox1 = new CheckBox();
            button3 = new Button();
            label11 = new Label();
            label12 = new Label();
            ColorViewer = new PictureBox();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ColorViewer).BeginInit();
            SuspendLayout();
            // 
            // rotBTN
            // 
            rotBTN.Location = new Point(1121, 231);
            rotBTN.Name = "rotBTN";
            rotBTN.Size = new Size(75, 23);
            rotBTN.TabIndex = 1;
            rotBTN.Text = "Rot in X";
            rotBTN.UseVisualStyleBackColor = true;
            rotBTN.Click += rotBTN_Click;
            // 
            // rotBTN2
            // 
            rotBTN2.Location = new Point(1121, 307);
            rotBTN2.Name = "rotBTN2";
            rotBTN2.Size = new Size(75, 23);
            rotBTN2.TabIndex = 2;
            rotBTN2.Text = "Rot in Y";
            rotBTN2.UseVisualStyleBackColor = true;
            rotBTN2.Click += rotBTN2_Click;
            // 
            // rotBTN3
            // 
            rotBTN3.Location = new Point(1121, 392);
            rotBTN3.Name = "rotBTN3";
            rotBTN3.Size = new Size(75, 23);
            rotBTN3.TabIndex = 3;
            rotBTN3.Text = "Rot in Z";
            rotBTN3.UseVisualStyleBackColor = true;
            rotBTN3.Click += rotBTN3_Click;
            // 
            // rotBTN4
            // 
            rotBTN4.Location = new Point(1121, 462);
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
            rotTimer.Interval = 80;
            rotTimer.Tick += rotTimer_Tick;
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.BackColor = SystemColors.ActiveCaptionText;
            PCT_CANVAS.Location = new Point(271, 100);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(823, 463);
            PCT_CANVAS.TabIndex = 5;
            PCT_CANVAS.TabStop = false;
            PCT_CANVAS.SizeChanged += PCT_CANVAS_SizeChanged;
            // 
            // ObjBTN
            // 
            ObjBTN.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ObjBTN.Location = new Point(30, 22);
            ObjBTN.Name = "ObjBTN";
            ObjBTN.Size = new Size(105, 46);
            ObjBTN.TabIndex = 6;
            ObjBTN.Text = "Import Figure";
            ObjBTN.UseVisualStyleBackColor = true;
            ObjBTN.Click += ObjBTN_Click;
            // 
            // CubeBTN
            // 
            CubeBTN.Location = new Point(12, 443);
            CubeBTN.Name = "CubeBTN";
            CubeBTN.Size = new Size(82, 23);
            CubeBTN.TabIndex = 7;
            CubeBTN.Text = "Cube";
            CubeBTN.UseVisualStyleBackColor = true;
            CubeBTN.Click += CubeBTN_Click;
            // 
            // ConeBTN
            // 
            ConeBTN.Location = new Point(100, 443);
            ConeBTN.Name = "ConeBTN";
            ConeBTN.Size = new Size(82, 23);
            ConeBTN.TabIndex = 8;
            ConeBTN.Text = "Cone";
            ConeBTN.UseVisualStyleBackColor = true;
            ConeBTN.Click += ConeBTN_Click;
            // 
            // CylinderBTN
            // 
            CylinderBTN.Location = new Point(12, 474);
            CylinderBTN.Name = "CylinderBTN";
            CylinderBTN.Size = new Size(82, 23);
            CylinderBTN.TabIndex = 9;
            CylinderBTN.Text = "Cylinder";
            CylinderBTN.UseVisualStyleBackColor = true;
            CylinderBTN.Click += CylinderBTN_Click;
            // 
            // SphereBTN
            // 
            SphereBTN.Location = new Point(100, 474);
            SphereBTN.Name = "SphereBTN";
            SphereBTN.Size = new Size(82, 23);
            SphereBTN.TabIndex = 10;
            SphereBTN.Text = "Sphere";
            SphereBTN.UseVisualStyleBackColor = true;
            SphereBTN.Click += SphereBTN_Click;
            // 
            // SemiSphere
            // 
            SemiSphere.Location = new Point(53, 503);
            SemiSphere.Name = "SemiSphere";
            SemiSphere.Size = new Size(82, 23);
            SemiSphere.TabIndex = 11;
            SemiSphere.Text = "Semi Sphere";
            SemiSphere.UseVisualStyleBackColor = true;
            SemiSphere.Click += SemiSphere_Click;
            // 
            // ScaleField
            // 
            ScaleField.Location = new Point(211, 74);
            ScaleField.Name = "ScaleField";
            ScaleField.Size = new Size(54, 23);
            ScaleField.TabIndex = 12;
            ScaleField.KeyPress += ScaleField_KeyPress;
            // 
            // RotField
            // 
            RotField.Location = new Point(193, 289);
            RotField.Name = "RotField";
            RotField.Size = new Size(54, 23);
            RotField.TabIndex = 13;
            RotField.KeyPress += RotField_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(166, 82);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 14;
            label1.Text = "Scale:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(169, 271);
            label2.Name = "label2";
            label2.Size = new Size(96, 15);
            label2.TabIndex = 15;
            label2.Text = "Rotation Speed:";
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 100);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(145, 297);
            treeView1.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 82);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 17;
            label3.Text = "Figures List:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(37, 416);
            label4.Name = "label4";
            label4.Size = new Size(120, 15);
            label4.TabIndex = 18;
            label4.Text = "Add Default Figures:";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(202, 103);
            trackBar1.Minimum = -10;
            trackBar1.Name = "trackBar1";
            trackBar1.Orientation = Orientation.Vertical;
            trackBar1.Size = new Size(45, 168);
            trackBar1.TabIndex = 19;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(202, 330);
            trackBar2.Minimum = -10;
            trackBar2.Name = "trackBar2";
            trackBar2.Orientation = Orientation.Vertical;
            trackBar2.Size = new Size(45, 177);
            trackBar2.TabIndex = 20;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(298, 584);
            trackBar3.Minimum = -10;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(138, 45);
            trackBar3.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(392, 566);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 24;
            label5.Text = "Camera Location:";
            // 
            // trackBar4
            // 
            trackBar4.Location = new Point(298, 619);
            trackBar4.Minimum = -10;
            trackBar4.Name = "trackBar4";
            trackBar4.Size = new Size(138, 45);
            trackBar4.TabIndex = 25;
            // 
            // trackBar5
            // 
            trackBar5.Location = new Point(442, 600);
            trackBar5.Minimum = -10;
            trackBar5.Name = "trackBar5";
            trackBar5.Size = new Size(138, 45);
            trackBar5.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(277, 584);
            label6.Name = "label6";
            label6.Size = new Size(15, 15);
            label6.TabIndex = 27;
            label6.Text = "X";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(277, 630);
            label7.Name = "label7";
            label7.Size = new Size(14, 15);
            label7.TabIndex = 28;
            label7.Text = "Y";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(509, 584);
            label8.Name = "label8";
            label8.Size = new Size(14, 15);
            label8.TabIndex = 29;
            label8.Text = "Z";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(710, 566);
            label9.Name = "label9";
            label9.Size = new Size(33, 15);
            label9.TabIndex = 30;
            label9.Text = "FOV:";
            // 
            // trackBar6
            // 
            trackBar6.Location = new Point(660, 600);
            trackBar6.Minimum = -10;
            trackBar6.Name = "trackBar6";
            trackBar6.Size = new Size(131, 45);
            trackBar6.TabIndex = 31;
            // 
            // trackBar7
            // 
            trackBar7.Location = new Point(271, 49);
            trackBar7.Maximum = 100;
            trackBar7.Name = "trackBar7";
            trackBar7.Size = new Size(823, 45);
            trackBar7.TabIndex = 32;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(536, 22);
            label10.Name = "label10";
            label10.Size = new Size(230, 25);
            label10.TabIndex = 33;
            label10.Text = "Frame: Available Frames:";
            // 
            // DrawMode
            // 
            DrawMode.FormattingEnabled = true;
            DrawMode.Location = new Point(1121, 123);
            DrawMode.Name = "DrawMode";
            DrawMode.Size = new Size(121, 23);
            DrawMode.TabIndex = 34;
            // 
            // button1
            // 
            button1.Location = new Point(37, 558);
            button1.Name = "button1";
            button1.Size = new Size(127, 23);
            button1.TabIndex = 35;
            button1.Text = "Record Point";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(37, 587);
            button2.Name = "button2";
            button2.Size = new Size(127, 23);
            button2.TabIndex = 36;
            button2.Text = "Play Animation";
            button2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(37, 650);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(129, 19);
            checkBox1.TabIndex = 37;
            checkBox1.Text = "Animate All Figures";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(37, 619);
            button3.Name = "button3";
            button3.Size = new Size(127, 23);
            button3.TabIndex = 38;
            button3.Text = "Change Animation Speed";
            button3.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(1136, 9);
            label11.Name = "label11";
            label11.Size = new Size(77, 15);
            label11.TabIndex = 39;
            label11.Text = "Color Picker:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(1143, 100);
            label12.Name = "label12";
            label12.Size = new Size(70, 15);
            label12.TabIndex = 40;
            label12.Text = "PaintMode:";
            // 
            // ColorViewer
            // 
            ColorViewer.BorderStyle = BorderStyle.Fixed3D;
            ColorViewer.Location = new Point(1126, 27);
            ColorViewer.Name = "ColorViewer";
            ColorViewer.Size = new Size(100, 50);
            ColorViewer.TabIndex = 41;
            ColorViewer.TabStop = false;
            ColorViewer.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.Gray;
            ClientSize = new Size(1264, 681);
            Controls.Add(ColorViewer);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(DrawMode);
            Controls.Add(label10);
            Controls.Add(trackBar7);
            Controls.Add(trackBar6);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(trackBar5);
            Controls.Add(trackBar4);
            Controls.Add(label5);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(treeView1);
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
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar4).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar5).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar6).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar7).EndInit();
            ((System.ComponentModel.ISupportInitialize)ColorViewer).EndInit();
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
        private TreeView treeView1;
        private Label label3;
        private Label label4;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
        private Label label5;
        private TrackBar trackBar4;
        private TrackBar trackBar5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TrackBar trackBar6;
        private TrackBar trackBar7;
        private Label label10;
        private ComboBox DrawMode;
        private Button button1;
        private Button button2;
        private CheckBox checkBox1;
        private Button button3;
        private Label label11;
        private Label label12;
        private PictureBox ColorViewer;
        private ColorDialog colorDialog1;
    }
}