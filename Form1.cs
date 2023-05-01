using System.Numerics;

namespace Optimized_3D_Graphic_Engine
{
    public partial class Form1 : Form
    {

        bool x, y, z, all, semi = false;
        Canvas canvas;
        Instance[] instances;
        Model model, model2;
        int angle = 0;
        float scale = 0.75f;
        int rotSpeed = 2;
        bool MouseDownY = false;
        float translationX, translationY, translationZ;
        float rotationX, rotationY, rotationZ = 0;

        public Form1()
        {
            InitializeComponent();
            Init();
            translationX = 0;
            translationY = 0;
            translationZ = 8;
        }

        public void Init()
        {
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.Bitmap;
            PCT_CANVAS.Invalidate();
        }

        private void rotBTN_Click(object sender, EventArgs e)
        {
            x = true;
            y = z = all = false;
        }

        private void rotBTN2_Click(object sender, EventArgs e)
        {
            y = true;
            x = z = all = false;
        }

        private void rotBTN3_Click(object sender, EventArgs e)
        {
            z = true;
            x = y = all = false;
        }

        private void rotBTN4_Click(object sender, EventArgs e)
        {
            all = true;
            x = y = z = false;
        }

        private void ObjBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Vertex[] vertices;
            Triangle[] triangles;
            semi = false;

            openFileDialog.Filter = "OBJ files (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                try
                {
                    StreamReader sr = new StreamReader(filename);
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

                    RenderFigures(vertices, triangles);
                }
                catch
                {
                    MessageBox.Show("Oops, there was an error at the moment of opening and/or reading the file " + filename + ".\n\nPlease check if the file is correct and/or is not corrupt.");
                }
            }
        }

        private void RenderFigures(Vertex[] vertices, Triangle[] triangles)
        {
            model = new Model(vertices, triangles, new Vertex(0, 0, 0), (float)Math.Sqrt(3));
            instances = new Instance[1];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
        }

        private void rotTimer_Tick(object sender, EventArgs e)
        {
            if (model != null)
            {

                canvas.FastClear();
                canvas.SetModelInstances(instances);
                if (x)
                {
                    if (semi == false)
                    {
                        instances[0] = new Instance(model, new Vertex(translationX, translationY, translationZ), Matrix.RotX(angle), scale);
                        angle += rotSpeed;
                    }
                    else
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.RotX(angle), scale);
                        instances[1] = new Instance(model2, new Vertex(0, 0, 8), Matrix.RotX(angle), scale);
                        angle += rotSpeed;
                    }
                }
                else if (y)
                {
                    if (semi == false)
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.RotY(angle), scale);
                        angle += rotSpeed;
                    }
                    else
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.RotY(angle), scale);
                        instances[1] = new Instance(model2, new Vertex(0, 0, 8), Matrix.RotY(angle), scale);
                        angle += rotSpeed;
                    }
                }
                else if (z)
                {
                    if (semi == false)
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.RotZ(angle), scale);
                        angle += rotSpeed;
                    }
                    else
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.RotZ(angle), scale);
                        instances[1] = new Instance(model2, new Vertex(0, 0, 8), Matrix.RotZ(angle), scale);
                        angle += rotSpeed;
                    }
                }
                else if (all)
                {
                    if (semi == false)
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Rotate(angle), scale);
                        angle += rotSpeed;
                    }
                    else
                    {
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Rotate(angle), scale);
                        instances[1] = new Instance(model2, new Vertex(0, 0, 8), Matrix.Rotate(angle), scale);
                        angle += rotSpeed;
                    }
                }

                PCT_CANVAS.Invalidate();
            }



        }

        private void CubeBTN_Click(object sender, EventArgs e)
        {
            semi = false;
            model = Cube.CreateCube();
            instances = new Instance[2];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
            instances[1] = new Instance(model, new Vertex(0, 0, 6), Matrix.Identity, scale);
        }

        private void ConeBTN_Click(object sender, EventArgs e)
        {
            semi = false;
            model = Cone.createCone(1f, 3f, 20, false);
            instances = new Instance[1];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
        }

        private void CylinderBTN_Click(object sender, EventArgs e)
        {
            semi = false;
            model = Cylinder.createCylinder(1f, 3f, 20, false);
            instances = new Instance[1];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
        }

        private void SphereBTN_Click(object sender, EventArgs e)
        {
            semi = false;
            model = Sphere.CreateSphere(2, 40);
            instances = new Instance[1];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
        }

        private void SemiSphere_Click(object sender, EventArgs e)
        {
            semi = true;
            instances = new Instance[2];
            model = Pizza.CreateCircle(2, 0, 40);
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
            model2 = HalfSphere.CreateSemi(2, 40);
            instances[1] = new Instance(model2, new Vertex(0, 0, 8), Matrix.Identity, scale);
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
            if (Scale.Value < 0) scale -= 0.25f;
            else if (Scale.Value >= 0) scale += 0.25f;
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

        }

        private void RecordBTN_Click(object sender, EventArgs e)
        {

        }

        private void XCoord_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void XCoord_MouseMove(object sender, MouseEventArgs e)
        {
            if (TranslationBTN.Checked == true)
            {
                if (XCoord.Value < 0) translationX -= 0.010f;
                else if (XCoord.Value > 0) translationX += 0.010f;
            }
            if (RotationBTN.Checked == true)
            {
                if (YCoord.Value < 0) rotationX -= 10;
                else if (YCoord.Value > 0) rotationX += 10;
                x = true;
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
                if (YCoord.Value < 0) translationY -= 0.010f;
                else if (YCoord.Value > 0) translationY += 0.010f;
            }
            if (RotationBTN.Checked == true)
            {
                if (YCoord.Value < 0) rotationY -= 10;
                else if (YCoord.Value > 0) rotationY += 10;
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
                if (ZCoord.Value < 0) translationZ -= 0.010f;
                else if (ZCoord.Value > 0) translationZ += 0.010f;
            }
            if (RotationBTN.Checked == true)
            {
                if (YCoord.Value < 0) rotationZ -= 10;
                else if (YCoord.Value > 0) rotationZ += 10;

            }
        }

        private void ZCoord_MouseUp(object sender, MouseEventArgs e)
        {
            ZCoord.Value = 0;
        }
    }
}