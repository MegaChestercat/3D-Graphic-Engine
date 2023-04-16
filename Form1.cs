namespace Optimized_3D_Graphic_Engine
{
    public partial class Form1 : Form
    {

        bool x, y, z, all = false;
        Canvas canvas;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            canvas = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image = canvas.Bitmap;
            canvas.SetModelInstances();
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

        private void rotTimer_Tick(object sender, EventArgs e)
        {
            canvas.FastClear();
            canvas.SetModelInstances();
            PCT_CANVAS.Invalidate();
        }
    }
}