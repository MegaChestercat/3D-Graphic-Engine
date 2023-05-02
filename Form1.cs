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
        float scale = 0.75f;
        int rotSpeed = 2;
        bool MouseDownY = false;
        float translationX, translationY, translationZ;
        float rotationX, rotationY, rotationZ = 0;
        bool play;
        int initialFrame;
        int finalFrame;
        String figName;

        public Form1()
        {
            InitializeComponent();
            Init();

        }

        public void Init()
        {
            canvas = new Canvas(PCT_CANVAS.Size);
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
                canvas.FastClear();
                canvas.SetModelInstances(instances.ToArray());
            }

            if (play)
                canvas.Animate(Frames.Value, initialFrame);
            if (play)
            {
                if (Frames.Value == Frames.Maximum)
                    Frames.Value = 0;
                else
                    Frames.Value++;
                //label1.Text = "Tiempo : " + ConvertirMilisegundosAString(TB_TIME.Value * TIMER.Interval);
            }

            PCT_CANVAS.Invalidate();

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
                currentInstance.scale = scale;
            }
            else if (Scale.Value >= 0)
            {
                scale += 0.25f;
                currentInstance.scale = scale;
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
                canvas.SaveFrame(Frames.Value);

            }
            else if (finalFrame == -1)
            {
                finalFrame = Frames.Value;
                canvas.SaveFrame(Frames.Value);
                for (int i = 0; i < canvas.instances.Count; i++)
                {
                    Instance ints = canvas.instances[i];
                    for (int j = 0; j < ints.transformations.Count; j++)
                    {
                        label2.Text += ints.transformations[j].ToString();

                    }
                }
                canvas.CalculateSteps(initialFrame, finalFrame);


            }
            else
            {
                Console.WriteLine("ERROR");
            }
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
                    currentInstance.position.X = translationX;
                }
                else if (XCoord.Value > 0)
                {
                    translationX += 0.010f;
                    currentInstance.position.X = translationX;
                }
            }
            if (RotationBTN.Checked == true)
            {
                if (XCoord.Value < 0)
                {
                    rotationX -= 10;
                    currentInstance.orientation = Matrix.RotX(rotationX);
                }
                else if (XCoord.Value > 0)
                {
                    rotationX += 10;
                    currentInstance.orientation = Matrix.RotX(rotationX);
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
                    translationY -= 0.010f;
                    currentInstance.position.Y = translationY;
                }
                else if (YCoord.Value > 0)
                {
                    translationY += 0.010f;
                    currentInstance.position.Y = translationY;
                }
            }
            if (RotationBTN.Checked == true)
            {
                if (YCoord.Value < 0)
                {
                    rotationY -= 10;
                    currentInstance.orientation = Matrix.RotY(rotationY);
                }
                else if (YCoord.Value > 0)
                {
                    rotationY += 10;
                    currentInstance.orientation = Matrix.RotY(rotationY);
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
                    translationZ -= 0.010f;
                    currentInstance.position.Z = translationZ;
                }
                else if (ZCoord.Value > 0)
                {
                    translationZ += 0.010f;
                    currentInstance.position.Z = translationZ;
                }
            }
            if (RotationBTN.Checked == true)
            {
                if (ZCoord.Value < 0)
                {
                    rotationZ -= 10;
                    currentInstance.orientation = Matrix.RotZ(rotationZ);
                }
                else if (ZCoord.Value > 0)
                {
                    rotationZ += 10;
                    currentInstance.orientation = Matrix.RotZ(rotationZ);
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

        }
    }
}