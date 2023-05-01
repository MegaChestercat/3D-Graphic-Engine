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
            Scale = new TrackBar();
            Speed = new TrackBar();
            CameraX = new TrackBar();
            label5 = new Label();
            CameraY = new TrackBar();
            CameraZ = new TrackBar();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            FOV = new TrackBar();
            Frames = new TrackBar();
            label10 = new Label();
            DrawMode = new ComboBox();
            RecordBTN = new Button();
            PlayBTN = new Button();
            checkBox1 = new CheckBox();
            button3 = new Button();
            label11 = new Label();
            label12 = new Label();
            ColorViewer = new PictureBox();
            colorDialog1 = new ColorDialog();
            XCoord = new TrackBar();
            ZCoord = new TrackBar();
            YCoord = new TrackBar();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            TransformationsBox = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Scale).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Speed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CameraX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CameraY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CameraZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FOV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Frames).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ColorViewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XCoord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ZCoord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YCoord).BeginInit();
            SuspendLayout();
            // 
            // rotBTN
            // 
            rotBTN.Location = new Point(942, 587);
            rotBTN.Name = "rotBTN";
            rotBTN.Size = new Size(75, 23);
            rotBTN.TabIndex = 1;
            rotBTN.Text = "Rot in X";
            rotBTN.UseVisualStyleBackColor = true;
            rotBTN.Click += rotBTN_Click;
            // 
            // rotBTN2
            // 
            rotBTN2.Location = new Point(1049, 587);
            rotBTN2.Name = "rotBTN2";
            rotBTN2.Size = new Size(75, 23);
            rotBTN2.TabIndex = 2;
            rotBTN2.Text = "Rot in Y";
            rotBTN2.UseVisualStyleBackColor = true;
            rotBTN2.Click += rotBTN2_Click;
            // 
            // rotBTN3
            // 
            rotBTN3.Location = new Point(942, 630);
            rotBTN3.Name = "rotBTN3";
            rotBTN3.Size = new Size(75, 23);
            rotBTN3.TabIndex = 3;
            rotBTN3.Text = "Rot in Z";
            rotBTN3.UseVisualStyleBackColor = true;
            rotBTN3.Click += rotBTN3_Click;
            // 
            // rotBTN4
            // 
            rotBTN4.Location = new Point(1049, 619);
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
            // Scale
            // 
            Scale.Location = new Point(202, 103);
            Scale.Minimum = -10;
            Scale.Name = "Scale";
            Scale.Orientation = Orientation.Vertical;
            Scale.Size = new Size(45, 168);
            Scale.TabIndex = 19;
            Scale.TickStyle = TickStyle.Both;
            Scale.MouseUp += Scale_MouseUp;
            // 
            // Speed
            // 
            Speed.Location = new Point(202, 330);
            Speed.Minimum = -10;
            Speed.Name = "Speed";
            Speed.Orientation = Orientation.Vertical;
            Speed.Size = new Size(45, 177);
            Speed.TabIndex = 20;
            Speed.TickStyle = TickStyle.Both;
            Speed.MouseUp += Speed_MouseUp;
            // 
            // CameraX
            // 
            CameraX.Location = new Point(298, 584);
            CameraX.Minimum = -10;
            CameraX.Name = "CameraX";
            CameraX.Size = new Size(138, 45);
            CameraX.TabIndex = 21;
            CameraX.MouseMove += CameraX_MouseMove;
            CameraX.MouseUp += CameraX_MouseUp;
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
            // CameraY
            // 
            CameraY.Location = new Point(298, 619);
            CameraY.Minimum = -10;
            CameraY.Name = "CameraY";
            CameraY.Size = new Size(138, 45);
            CameraY.TabIndex = 25;
            CameraY.MouseMove += CameraY_MouseMove;
            CameraY.MouseUp += CameraY_MouseUp;
            // 
            // CameraZ
            // 
            CameraZ.Location = new Point(442, 600);
            CameraZ.Minimum = -10;
            CameraZ.Name = "CameraZ";
            CameraZ.Size = new Size(138, 45);
            CameraZ.TabIndex = 26;
            CameraZ.MouseMove += CameraZ_MouseMove;
            CameraZ.MouseUp += CameraZ_MouseUp;
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
            label8.Location = new Point(505, 584);
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
            // FOV
            // 
            FOV.Location = new Point(660, 600);
            FOV.Minimum = -10;
            FOV.Name = "FOV";
            FOV.Size = new Size(131, 45);
            FOV.TabIndex = 31;
            FOV.MouseUp += FOV_MouseUp;
            // 
            // Frames
            // 
            Frames.Location = new Point(271, 49);
            Frames.Maximum = 100;
            Frames.Name = "Frames";
            Frames.Size = new Size(823, 45);
            Frames.TabIndex = 32;
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
            DrawMode.Items.AddRange(new object[] { "Wireframe", "Fill" });
            DrawMode.Location = new Point(1121, 123);
            DrawMode.Name = "DrawMode";
            DrawMode.Size = new Size(121, 23);
            DrawMode.TabIndex = 34;
            DrawMode.SelectedIndexChanged += DrawMode_SelectedIndexChanged;
            // 
            // RecordBTN
            // 
            RecordBTN.Location = new Point(37, 558);
            RecordBTN.Name = "RecordBTN";
            RecordBTN.Size = new Size(127, 23);
            RecordBTN.TabIndex = 35;
            RecordBTN.Text = "Record Point";
            RecordBTN.UseVisualStyleBackColor = true;
            RecordBTN.Click += RecordBTN_Click;
            // 
            // PlayBTN
            // 
            PlayBTN.Location = new Point(37, 587);
            PlayBTN.Name = "PlayBTN";
            PlayBTN.Size = new Size(127, 23);
            PlayBTN.TabIndex = 36;
            PlayBTN.Text = "Play Animation";
            PlayBTN.UseVisualStyleBackColor = true;
            PlayBTN.Click += PlayBTN_Click;
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
            button3.Location = new Point(14, 621);
            button3.Name = "button3";
            button3.Size = new Size(168, 23);
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
            // XCoord
            // 
            XCoord.Location = new Point(1121, 289);
            XCoord.Minimum = -10;
            XCoord.Name = "XCoord";
            XCoord.Size = new Size(131, 45);
            XCoord.TabIndex = 42;
            // 
            // ZCoord
            // 
            ZCoord.Location = new Point(1121, 391);
            ZCoord.Minimum = -10;
            ZCoord.Name = "ZCoord";
            ZCoord.Size = new Size(131, 45);
            ZCoord.TabIndex = 43;
            // 
            // YCoord
            // 
            YCoord.Location = new Point(1121, 340);
            YCoord.Minimum = -10;
            YCoord.Name = "YCoord";
            YCoord.Size = new Size(131, 45);
            YCoord.TabIndex = 44;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(1109, 289);
            label13.Name = "label13";
            label13.Size = new Size(15, 15);
            label13.TabIndex = 45;
            label13.Text = "X";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label14.Location = new Point(1109, 342);
            label14.Name = "label14";
            label14.Size = new Size(14, 15);
            label14.TabIndex = 46;
            label14.Text = "Y";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(1109, 391);
            label15.Name = "label15";
            label15.Size = new Size(14, 15);
            label15.TabIndex = 47;
            label15.Text = "Z";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(1109, 474);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(82, 19);
            radioButton1.TabIndex = 48;
            radioButton1.TabStop = true;
            radioButton1.Text = "Translation";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(1109, 512);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(70, 19);
            radioButton2.TabIndex = 49;
            radioButton2.TabStop = true;
            radioButton2.Text = "Rotation";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // TransformationsBox
            // 
            TransformationsBox.Location = new Point(1126, 171);
            TransformationsBox.Name = "TransformationsBox";
            TransformationsBox.Size = new Size(111, 100);
            TransformationsBox.TabIndex = 50;
            TransformationsBox.TabStop = false;
            TransformationsBox.Text = "Transformations";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.Gray;
            ClientSize = new Size(1264, 681);
            Controls.Add(TransformationsBox);
            Controls.Add(XCoord);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(YCoord);
            Controls.Add(ZCoord);
            Controls.Add(ColorViewer);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(PlayBTN);
            Controls.Add(RecordBTN);
            Controls.Add(DrawMode);
            Controls.Add(label10);
            Controls.Add(Frames);
            Controls.Add(FOV);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(CameraZ);
            Controls.Add(CameraY);
            Controls.Add(label5);
            Controls.Add(CameraX);
            Controls.Add(Speed);
            Controls.Add(Scale);
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
            ((System.ComponentModel.ISupportInitialize)Scale).EndInit();
            ((System.ComponentModel.ISupportInitialize)Speed).EndInit();
            ((System.ComponentModel.ISupportInitialize)CameraX).EndInit();
            ((System.ComponentModel.ISupportInitialize)CameraY).EndInit();
            ((System.ComponentModel.ISupportInitialize)CameraZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)FOV).EndInit();
            ((System.ComponentModel.ISupportInitialize)Frames).EndInit();
            ((System.ComponentModel.ISupportInitialize)ColorViewer).EndInit();
            ((System.ComponentModel.ISupportInitialize)XCoord).EndInit();
            ((System.ComponentModel.ISupportInitialize)ZCoord).EndInit();
            ((System.ComponentModel.ISupportInitialize)YCoord).EndInit();
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
        private TrackBar Scale;
        private TrackBar Speed;
        private TrackBar CameraX;
        private Label label5;
        private TrackBar CameraY;
        private TrackBar CameraZ;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TrackBar FOV;
        private TrackBar Frames;
        private Label label10;
        private ComboBox DrawMode;
        private Button RecordBTN;
        private Button PlayBTN;
        private CheckBox checkBox1;
        private Button button3;
        private Label label11;
        private Label label12;
        private PictureBox ColorViewer;
        private ColorDialog colorDialog1;
        private TrackBar XCoord;
        private TrackBar ZCoord;
        private TrackBar YCoord;
        private Label label13;
        private Label label14;
        private Label label15;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox TransformationsBox;
    }
}