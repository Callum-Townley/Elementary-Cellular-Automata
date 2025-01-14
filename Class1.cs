using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Elemental_Cellular_Automata
{
    internal class Class1
    {
    }
    // for "global" variables
    public static class Globals
    {
        public static int choice;
       
    }
    public class stuff
    {
        public static int calculatestate(int a, int b, int c, string B)
        {
            if (a == 1 && b == 1 && c == 1)
            {
                char C = B[0];
                return C - '0';
            }//128
            if (a == 1 && b == 1 && c == 0)
            {
                char C = B[1];
                return C - '0';

            }//64
            if (a == 1 && b == 0 && c == 1)
            {
                char C = B[2];
                return C - '0';

            }//32
            if (a == 1 && b == 0 && c == 0)
            {
                char C = B[3];
                return C - '0';


            }//16
            if (a == 0 && b == 1 && c == 1)
            {
                char C = B[4];
                return C - '0';
            }//8
            if (a == 0 && b == 1 && c == 0)
            {
                char C = B[5];
                return C - '0';
            }//4
            if (a == 0 && b == 0 && c == 1)
            {
                char C = B[6];
                return C - '0';
            }//2
            if (a == 0 && b == 0 && c == 0)
            {
                char C = B[7];
                return C - '0';
            }//1
            else return 0;
        }
        public static int[] setup(int W)
        {

            int total = 820 / W;
            int[] cells = new int[total];
            for (int i = 0; i < total; i++)
            {
                cells[i] = 0;
            }
            cells[total / 2] = 1;
            return cells;
        }
        public static bool InputValidate(int A)
        {
            if (A > 0 && A < 257)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


