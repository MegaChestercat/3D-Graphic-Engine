using System.Numerics;

namespace Optimized_3D_Graphic_Engine
{
    public partial class Form1 : Form
    {

        bool x, y, z, all = false;
        Canvas canvas;
        Instance[] instances;
        Model model;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.Bitmap;
            //canvas.SetModelInstances();
            PCT_CANVAS.Invalidate();
        }

        private void rotBTN_Click(object sender, EventArgs e)
        {

        }

        private void rotBTN2_Click(object sender, EventArgs e)
        {

        }

        private void rotBTN3_Click(object sender, EventArgs e)
        {

        }

        private void rotBTN4_Click(object sender, EventArgs e)
        {

        }

        private void ObjBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            Vertex[] vertices;
            Triangle[] triangles ;

            openFileDialog.Filter = "OBJ files (*.obj)|*.obj";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
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
                        else if(line.StartsWith("f "))
                        {
                            if (line.Contains('/'))
                            {
                                string[] spaces = line.Split(' ');
                                string[] triaValues = new string[3];

                                for (int i = 0; i < spaces.Length-1; i++)
                                {
                                    string[] diagonals = spaces[i+1].Split('/');
                                    triaValues[i] = diagonals[0];
                                }
                                trianglesValues.Add(new Triangle(int.Parse(triaValues[0])-1, int.Parse(triaValues[1])-1, int.Parse(triaValues[2])-1, Color.Yellow));
                            }
                            else
                            {
                                string[] triaValues = line.Split(' ');
                                trianglesValues.Add(new Triangle(int.Parse(triaValues[1])-1, int.Parse(triaValues[2])-1, int.Parse(triaValues[3])-1, Color.Yellow));
                            }
                        }
                        //MessageBox.Show(triaValues);
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
            instances[0] = new Instance(model, new Vertex(0, 0, 8), Matrix.Identity, 0.75f);
        }

        private void rotTimer_Tick(object sender, EventArgs e)
        {
            if(model != null)
            {
                canvas.FastClear();
                canvas.SetModelInstances(instances);
                PCT_CANVAS.Invalidate();
            }
            
        }
    }
}