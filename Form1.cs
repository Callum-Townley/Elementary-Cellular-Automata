using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Elemental_Cellular_Automata
{
    public partial class Form1 : Form
    {
        //amount of rows and columns
        int total = 820 / 5;
        //width of each pixel
        int w = 5;
        //y co-ordinate,used when painting to screen
        int y = 0;
        //creates 2 grids
        int[] cells = stuff.setup(5);
        int[] newcells = new int[164];
        bool clear = false;


        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
            this.StartPosition = FormStartPosition.CenterScreen;
            timer1.Interval = 1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // creates the canvas to be painted to
            Graphics g = e.Graphics;
            Brush black = new SolidBrush(Color.Black);
            //converts whatever number in the textbox into its binary counterpart
            
            string binary = Convert.ToString(Globals.choice, 2);
            //if the screen is being cleared,the value is set to 0 to clear the screen
            if (clear == true)
            {
                binary = "00000000";
            }
            //ensures the binary number has 8 bits
            while (binary.Length < 8)
            {
                binary = "0" + binary;
            }
            //paints any pixel in the array with a value of 1 black
            for (int i = 0; i < cells.Length; i++)
            {
                int x = i * w;
                if (cells[i] == 1)
                {
                    g.FillRectangle(black, x, y, w, w);
                }
            }
            //increments the y value ready to paint the next generation(row) below
            y += w;
            //checks the state of a pixel,and the pixels to its right and left
            for (int i = 1; i < cells.Length - 1; i++)
            {
                int len = cells.Length;
                int left = cells[(i - 1 + len) % len];
                int right = cells[(i + 1) % len];
                int state = cells[i];
                int newstate;
                //calculates the new state of the pixel in the next generation
                newstate = stuff.calculatestate(left, state, right, binary);
                newcells[i] = newstate;
            }
            //copies the contents of the new array to the old array,overwriting it
            newcells.CopyTo(cells, 0);
            //keeps the cells on the left and right sides the same,to ensure no index out of range error takes place
            newcells[0] = cells[0];
            newcells[cells.Length - 1] = cells[cells.Length - 1];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //calls a paint event,making the paint function paint the next generation of cells
            Invalidate(new Rectangle(0, y, 820, w));
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            clear = false;
            // validates the input in the text box for when the "Ok" button is clicked
            try
            {
                int choice = Convert.ToInt32(textBox1.Text);
                if (stuff.InputValidate(choice))
                {

                    MessageBox.Show("valid input");
                    y = 0;
                    //sets the center pixel in the first generation to 1,so the pattern can start from somewhere
                    newcells[total / 2] = 1;
                    cells[total / 2] = 1;
                    Globals.choice = Convert.ToInt32(textBox1.Text);
                    timer1.Start();



                }
                else
                {
                    MessageBox.Show("invalid input");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("invalid input");
            }






        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            //wipes the screen and sets all values to 0 when the clear button is clicked
            y = 0;
            clear = true;
            for (int i = 0; i < cells.Length; i++)
            {

                cells[i] = 0;
                newcells[i] = 0;
            }

            //sets the center pixel in the first generation to 1,so the pattern can start from somewhere
            newcells[total / 2] = 1;
            cells[total / 2] = 1;
        }
    }
}
