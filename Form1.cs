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
            model = new Model(vertices, triangles);
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
                        instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.RotX(angle), scale);
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
            instances = new Instance[1];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
        }

        private void ConeBTN_Click(object sender, EventArgs e)
        {
            semi = false;
            model = Cone.createCone(1f, 3f, 20);
            instances = new Instance[1];
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, scale);
        }

        private void CylinderBTN_Click(object sender, EventArgs e)
        {
            semi = false;
            model = Cylinder.createCylinder(1f, 3f, 20);
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
            if(e.KeyChar == Convert.ToChar(Keys.Enter)) 
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
    }
}