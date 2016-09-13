using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepMakeSense.Models
{
    public static class BoxPosition
    {
        public static int[,] GetPositionrArray (int count)
        {
            switch (count)
            {
                case 1:
                    return oneBox;
                case 2:
                    return twoBox;
                case 3:
                    return threeBox;
                case 4:
                    return fourBox;
                case 5:
                    return fiveBox;
                case 6:
                    return sixBox;
            }

            return null;
        }


        private static int[,] oneBox = new int[1, 2] { { 0, 160 } };

        private static int [,] twoBox = new int[2, 2] { { 0, 80 }, { 0, 240 }};

        private static int [,] threeBox = new int[3, 2] { { 0, 0 }, { 0, 160 }, { 0, 320 }};

        private static int [,] fourBox = new int[4, 2] { { 0, 80 }, { 0, 240 }, { 110, 80 }, { 110, 240 } };

        private static int [,] fiveBox = new int [5,2] { { 0, 0 }, { 0, 160 }, { 0, 320 }, { 110, 80 }, { 110, 240 } };

        private static int[,] sixBox = new int[6, 2] { { 0, 0 }, { 0, 160 }, { 0, 320 }, { 110, 0 }, { 110, 160 }, { 110, 320 } };
    }
}