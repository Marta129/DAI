using System.Media;
using System.Threading;

namespace DAI
{
    public partial class Form1 : Form
    {
        Thread th;
        Bitmap bm = new Bitmap(new Bitmap("Assets/Cursor.png"), 32, 32);
        public Form1()
        {
            InitializeComponent();
            this.Cursor = new Cursor(bm.GetHicon());
        }

        private void Play(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenNewForm(object? obj)
        {
            Application.Run(new Character_Selection());
        }

        private void Keyboard_Controls(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
        }
    }
}