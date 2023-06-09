using System.Net;
using System.Numerics;
using System.Security.Cryptography.Xml;

namespace Optimized_3D_Graphic_Engine
{
    public partial class Form1 : Form
    {

        Canvas canvas;
        Instance[] instances;
        Model model;
        Instance currentInstance;
        float scale = 1f;
        int rotSpeed = 10;
        bool sliderLimit = false;
        float translationX, translationY, translationZ;
        float rotationX, rotationY, rotationZ = 0;
        bool play;
        int initialFrame;
        int finalFrame;
        String figName;
        int speedCounter = 0;

        public Form1()
        {
            InitializeComponent();
            Init();

        }

        public void Init()
        {
            canvas = new Canvas(PCT_CANVAS.Size);
            play = false;
            PCT_CANVAS.Image = canvas.Bitmap;
            PCT_CANVAS.Invalidate();
        }

        private void ObjBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Vertex[] vertices;
            Triangle[] triangles;

            openFileDialog.Filter = "OBJ files (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                try
                {
                    StreamReader sr = new StreamReader(filename);
                    figName = Path.GetFileNameWithoutExtension(filename);
                    List<Vertex> verticesValues = new List<Vertex>();
                    List<Triangle> trianglesValues = new List<Triangle>();
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();

                        if (line.StartsWith("v "))
                        {
                            string[] verValues = line.Split(' ');
                            verticesValues.Add(new Vertex(float.Parse(verValues[1]), float.Parse(verValues[2]), float.Parse(verValues[3])));
                        }
                        else if (line.StartsWith("f "))
                        {
                            if (line.Contains('/'))
                            {
                                string[] spaces = line.Split(' ');
                                string[] triaValues = new string[3];

                                for (int i = 0; i < spaces.Length - 1; i++)
                                {
                                    string[] diagonals = spaces[i + 1].Split('/');
                                    triaValues[i] = diagonals[0];
                                }
                                trianglesValues.Add(new Triangle(int.Parse(triaValues[0]) - 1, int.Parse(triaValues[1]) - 1, int.Parse(triaValues[2]) - 1, Color.Yellow));
                            }
                            else
                            {
                                string[] triaValues = line.Split(' ');
                                trianglesValues.Add(new Triangle(int.Parse(triaValues[1]) - 1, int.Parse(triaValues[2]) - 1, int.Parse(triaValues[3]) - 1, Color.Yellow));
                            }
                        }
                    }
                    vertices = verticesValues.ToArray();
                    triangles = trianglesValues.ToArray();

                    AddToList(new Model(vertices, triangles, new Vertex(0, 0, 0), (float)Math.Sqrt(3)));
                }
                catch
                {
                    MessageBox.Show("Oops, there was an error at the moment of opening and/or reading the file " + filename + ".\n\nPlease check if the file is correct and/or is not corrupt.");
                }
            }
        }

        private void rotTimer_Tick(object sender, EventArgs e)
        {
            if (model != null)
            {
                if (play)
                    Animate(Frames.Value, initialFrame);


                canvas.SetModelInstances(instances.ToArray());
                PCT_CANVAS.Invalidate();
                if (play)
                {
                    if (Frames.Value < Frames.Maximum && !sliderLimit)
                        Frames.Value++;
                    else if (Frames.Value > 0 && sliderLimit)
                        Frames.Value--;
                    else sliderLimit = !sliderLimit;
                    label10.Text = "Frame: " + Frames.Value + " Available Frames: " + Frames.Maximum;

                }

            }

            //PCT_CANVAS.Invalidate();

        }
        private void AddToList(Model m)
        {
            model = m;
            if (instances == null) instances = new Instance[0];
            Array.Resize(ref instances, instances.Length + 1);
            instances[instances.Length - 1] = new Instance(model, new Vertex(translationX, translationY, translationZ), Matrix.Identity, scale);

            if (instances != null)
            {
                TreeNode node = new TreeNode("Fig " + (treeView1.Nodes.Count + 1) + ": " + figName);
                node.Tag = instances[treeView1.Nodes.Count];
                treeView1.Nodes.Add(node);

                canvas.SetModelInstances(instances.ToArray());
            }
        }

        private void CubeBTN_Click(object sender, EventArgs e)
        {
            Model cube = Cube.CreateCube();
            figName = "Cube";
            AddToList(cube);
        }

        private void ConeBTN_Click(object sender, EventArgs e)
        {
            Model cone = Cone.createCone(1f, 3f, 20, false);
            figName = "Cone";
            AddToList(cone);
        }

        private void CylinderBTN_Click(object sender, EventArgs e)
        {
            Model cylinder = Cylinder.createCylinder(1f, 3f, 20, false);
            figName = "Cylinder";
            AddToList(cylinder);
        }

        private void SphereBTN_Click(object sender, EventArgs e)
        {
            Model sphere = Sphere.CreateSphere(2, 40);
            figName = "Sphere";
            AddToList(sphere);
        }

        private void ScaleField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    scale = float.Parse(ScaleField.Text);
                    float s = scale / currentInstance.scalation;
                    currentInstance.transform *= Matrix.MakeScalingMatrix(s);
                    currentInstance.scalation = scale;
                }
                catch
                {
                    MessageBox.Show("The value you set is invalid. \n\nPlease try again.");
                }
            }
        }

        private void RotField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    rotSpeed = int.Parse(RotField.Text);
                }
                catch
                {
                    MessageBox.Show("The value you set is invalid. \n\nPlease try again.");
                }
            }
        }

        private void PCT_CANVAS_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorViewer.BackColor = colorDialog1.Color;
                canvas.figureColor = colorDialog1.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Yellow;
            ColorViewer.BackColor = colorDialog1.Color;
            canvas.figureColor = colorDialog1.Color;

            translationX = 0;
            translationY = 0;
            translationZ = 8;

            play = false;

            initialFrame = -1;
            finalFrame = -1;
            Frames.Maximum = 150;
            RotField.Text = rotSpeed.ToString();
            label10.Text = "Frame: " + Frames.Value + " Available Frames: " + Frames.Maximum;
        }

        private void DrawMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrawMode.SelectedIndex == 0)
            {
                canvas.wireframe = true;
                canvas.fill = false;
            }
            else if (DrawMode.SelectedIndex == 1)
            {
                canvas.fill = true;
                canvas.wireframe = false;
            }
        }

        private void Speed_MouseUp(object sender, MouseEventArgs e)
        {
            rotSpeed += Speed.Value;
            RotField.Text = Convert.ToString(rotSpeed);
            Speed.Value = 0;

        }

        private void Scale_MouseUp(object sender, MouseEventArgs e)
        {
            if (Scale.Value < 0)
            {
                scale -= 0.25f;
                float s = scale / currentInstance.scalation;
                currentInstance.transform *= Matrix.MakeScalingMatrix(s);
                currentInstance.scalation = scale;
            }
            else if (Scale.Value >= 0)
            {
                scale += 0.25f;
                float s = scale / currentInstance.scalation;
                currentInstance.transform *= Matrix.MakeScalingMatrix(s);
                currentInstance.scalation = scale;
            }
            ScaleField.Text = Convert.ToString(scale);
            Scale.Value = 0;
        }

        private void FOV_MouseUp(object sender, MouseEventArgs e)
        {
            canvas.fovValue += FOV.Value;
            canvas.fovChanged = true;
            FOV.Value = 0;

        }

        private void CameraX_MouseUp(object sender, MouseEventArgs e)
        {
            CameraX.Value = 0;
        }

        private void CameraY_MouseUp(object sender, MouseEventArgs e)
        {
            CameraY.Value = 0;
        }

        private void CameraZ_MouseUp(object sender, MouseEventArgs e)
        {
            CameraZ.Value = 0;
        }

        private void CameraX_MouseMove(object sender, MouseEventArgs e)
        {
            if (CameraX.Value < 0) canvas.camX -= 0.020f;
            else if (CameraX.Value > 0) canvas.camX += 0.020f;
            canvas.cameraValueChanged = true;
        }

        private void CameraY_MouseMove(object sender, MouseEventArgs e)
        {
            if (CameraY.Value < 0) canvas.camY -= 0.020f;
            else if (CameraY.Value > 0) canvas.camY += 0.020f;
            canvas.cameraValueChanged = true;
        }

        private void CameraZ_MouseMove(object sender, MouseEventArgs e)
        {
            if (CameraZ.Value < 0) canvas.camZ -= 0.020f;
            else if (CameraZ.Value > 0) canvas.camZ += 0.020f;
            canvas.cameraValueChanged = true;
        }

        private void PlayBTN_Click(object sender, EventArgs e)
        {
            play = !play;
        }

        private void RecordBTN_Click(object sender, EventArgs e)
        {
            if (canvas == null)
                return;
            if (initialFrame == -1)
            {
                initialFrame = Frames.Value;
                SaveFrame(Frames.Value);

            }
            else if (finalFrame == -1)
            {
                finalFrame = Frames.Value;
                SaveFrame(Frames.Value);
                /*
                for (int i = 0; i < instances.Length; i++)
                {
                    Instance ints = instances[i];
                    for (int j = 0; j < ints.transformations.Count; j++)
                    {
                        //label2.Text += ints.transformations[j].ToString();

                    }
                }*/
                CalculateSteps(initialFrame, finalFrame);


            }
            else
            {
                finalFrame = Frames.Value;
                SaveFrame(Frames.Value);
                CalculateSteps(initialFrame, finalFrame);
                //MessageBox.Show("ERROR");

            }
        }

        public void CalculateSteps(int initialFrame, int finalFrame)
        {

            for (int i = 0; i < instances.Length; i++)
                currentInstance.CalculateSteps(initialFrame, finalFrame);
        }


        public void Animate(int frame, int initialFrame)
        {
            //Console.WriteLine(frame + "|" + initialFrame);
            if (checkBox1.Checked)
            {
                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    MatrixTransform transformation = instances[i].FindTransformation(frame);
                    if (transformation == null)
                    {

                    }
                    else if (frame == initialFrame)
                    {
                        instances[i].transform = instances[i].initialTransform;
                        return;
                    }
                    else
                    {
                        instances[i].transform = transformation.matrix;
                    }
                }
            }
            else
            {
                MatrixTransform transformation = currentInstance.FindTransformation(frame);
                if (transformation == null)
                {

                }
                else if (frame == initialFrame)
                {
                    currentInstance.transform = currentInstance.initialTransform;
                    return;
                }
                else
                {
                    currentInstance.transform = transformation.matrix;
                }
            }
        }
        public void SaveFrame(int frame)
        {
            currentInstance.SaveTransformations(frame);

        }


        private void XCoord_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void XCoord_MouseMove(object sender, MouseEventArgs e)
        {
            if (TranslationBTN.Checked == true)
            {
                if (XCoord.Value < 0)
                {
                    translationX -= 0.010f;
                    Vertex translation = new Vertex(translationX, translationY, translationZ);
                    Vertex tras = translation - currentInstance.translation;
                    currentInstance.transform *= Matrix.MakeTranslationMatrix(tras);
                    currentInstance.translation = translation;
                    //currentInstance.position.X = translationX;
                }
                else if (XCoord.Value > 0)
                {
                    translationX += 0.010f;
                    Vertex translation = new Vertex(translationX, translationY, translationZ);
                    Vertex tras = translation - currentInstance.translation;
                    currentInstance.transform *= Matrix.MakeTranslationMatrix(tras);
                    currentInstance.translation = translation;
                    /*
                    translationX += 0.010f;
                    currentInstance.position.X = translationX;*/
                }
            }
            if (RotationBTN.Checked == true)
            {
                if (XCoord.Value < 0)
                {
                    rotationX -= Math.Abs(rotSpeed);
                    /*
                    rotationX -= 10;
                    currentInstance.orientation = Matrix.RotX(rotationX);*/
                    Vertex angle = new Vertex(rotationX, rotationY, rotationZ);
                    Vertex rot = angle - currentInstance.angle;
                    currentInstance.transform *= Matrix.Rotate(rot);
                    currentInstance.angle = angle;
                }
                else if (XCoord.Value > 0)
                {
                    /*
                    rotationX += 10;
                    currentInstance.orientation = Matrix.RotX(rotationX);*/
                    rotationX += Math.Abs(rotSpeed);
                    Vertex angle = new Vertex(rotationX, rotationY, rotationZ);
                    Vertex rot = angle - currentInstance.angle;
                    currentInstance.transform *= Matrix.Rotate(rot);
                    currentInstance.angle = angle;
                }
            }
        }

        private void XCoord_MouseUp(object sender, MouseEventArgs e)
        {
            XCoord.Value = 0;
        }

        private void YCoord_MouseMove(object sender, MouseEventArgs e)
        {
            if (TranslationBTN.Checked == true)
            {
                if (YCoord.Value < 0)
                {
                    /*
                    translationY -= 0.010f;
                    currentInstance.position.Y = translationY;*/
                    translationY -= 0.010f;
                    Vertex translation = new Vertex(translationX, translationY, translationZ);
                    Vertex tras = translation - currentInstance.translation;
                    currentInstance.transform *= Matrix.MakeTranslationMatrix(tras);
                    currentInstance.translation = translation;
                }
                else if (YCoord.Value > 0)
                {
                    /*
                    translationY += 0.010f;
                    currentInstance.position.Y = translationY;*/
                    translationY += 0.010f;
                    Vertex translation = new Vertex(translationX, translationY, translationZ);
                    Vertex tras = translation - currentInstance.translation;
                    currentInstance.transform *= Matrix.MakeTranslationMatrix(tras);
                    currentInstance.translation = translation;
                }
            }
            if (RotationBTN.Checked == true)
            {
                if (YCoord.Value < 0)
                {
                    /*
                    rotationY -= 10;
                    currentInstance.orientation = Matrix.RotY(rotationY);*/
                    rotationY -= Math.Abs(rotSpeed);
                    Vertex angle = new Vertex(rotationX, rotationY, rotationZ);
                    Vertex rot = angle - currentInstance.angle;
                    currentInstance.transform *= Matrix.Rotate(rot);
                    currentInstance.angle = angle;
                }
                else if (YCoord.Value > 0)
                {
                    /*
                    rotationY += 10;
                    currentInstance.orientation = Matrix.RotY(rotationY);*/
                    rotationY += Math.Abs(rotSpeed);
                    Vertex angle = new Vertex(rotationX, rotationY, rotationZ);
                    Vertex rot = angle - currentInstance.angle;
                    currentInstance.transform *= Matrix.Rotate(rot);
                    currentInstance.angle = angle;
                }
            }
        }

        private void YCoord_MouseUp(object sender, MouseEventArgs e)
        {
            YCoord.Value = 0;
        }

        private void ZCoord_MouseMove(object sender, MouseEventArgs e)
        {
            if (TranslationBTN.Checked == true)
            {
                if (ZCoord.Value < 0)
                {
                    /*
                    translationZ -= 0.010f;
                    currentInstance.position.Z = translationZ;*/
                    translationZ -= 0.010f;
                    Vertex translation = new Vertex(translationX, translationY, translationZ);
                    Vertex tras = translation - currentInstance.translation;
                    currentInstance.transform *= Matrix.MakeTranslationMatrix(tras);
                    currentInstance.translation = translation;
                }
                else if (ZCoord.Value > 0)
                {
                    /*
                    translationZ += 0.010f;
                    currentInstance.position.Z = translationZ;*/
                    translationZ += 0.010f;
                    Vertex translation = new Vertex(translationX, translationY, translationZ);
                    Vertex tras = translation - currentInstance.translation;
                    currentInstance.transform *= Matrix.MakeTranslationMatrix(tras);
                    currentInstance.translation = translation;
                }
            }
            if (RotationBTN.Checked == true)
            {
                if (ZCoord.Value < 0)
                {
                    /*
                    rotationZ -= 10;
                    currentInstance.orientation = Matrix.RotZ(rotationZ);*/
                    rotationZ -= Math.Abs(rotSpeed);
                    Vertex angle = new Vertex(rotationX, rotationY, rotationZ);
                    Vertex rot = angle - currentInstance.angle;
                    currentInstance.transform *= Matrix.Rotate(rot);
                    currentInstance.angle = angle;
                }
                else if (ZCoord.Value > 0)
                {
                    /*
                    rotationZ += 10;
                    currentInstance.orientation = Matrix.RotZ(rotationZ);*/
                    rotationZ += Math.Abs(rotSpeed);
                    Vertex angle = new Vertex(rotationX, rotationY, rotationZ);
                    Vertex rot = angle - currentInstance.angle;
                    currentInstance.transform *= Matrix.Rotate(rot);
                    currentInstance.angle = angle;
                }

            }
        }

        private void ZCoord_MouseUp(object sender, MouseEventArgs e)
        {
            ZCoord.Value = 0;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            currentInstance = (Instance)treeView1.SelectedNode.Tag;
        }

        private void treeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            return;
        }

        private void Frames_Scroll(object sender, EventArgs e)
        {
            label10.Text = "Frame: " + Frames.Value + " Available Frames: " + Frames.Maximum;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (speedCounter)
            {
                case 0:
                    rotTimer.Interval = 60;
                    button3.Text = ">";
                    speedCounter++;
                    break;
                case 1:
                    rotTimer.Interval = 40;
                    button3.Text = ">>";
                    speedCounter++;
                    break;
                case 2:
                    rotTimer.Interval = 20;
                    button3.Text = ">>>";
                    speedCounter++;
                    break;
                case 3:
                    rotTimer.Interval = 10;
                    button3.Text = ">>>>";
                    speedCounter++;
                    break;
                case 4:
                    rotTimer.Interval = 80;
                    button3.Text = "Change Animation Speed";
                    speedCounter = 0;
                    break;
            }
        }

        private void TranslationBTN_Click(object sender, EventArgs e)
        {
            FOV.Enabled = true;
        }

        private void RotationBTN_Click(object sender, EventArgs e)
        {
            FOV.Enabled = false;
        }
    }
}