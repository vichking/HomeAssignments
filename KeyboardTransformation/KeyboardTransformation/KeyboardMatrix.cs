using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardTransformation
{
    public class KeyboardMatrix
    {
        // Data types
        public char[][] Matrix { get; set; }
        public Dictionary<char, Coord> CoordinatesMap;
        public string TransformedString;

        public struct Coord
        {
            public Coord(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
            public int i;
            public int j;
        };


        // Initialize
        public void Initialize()
        {
            this.TransformedString = null;

            var arr1 = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var arrInt1 = arr1.Select(item => (int)item).ToArray();
            var arr2 = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            var arr3 = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';' };
            var arr4 = new char[] { 'z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.', '/' };
            this.Matrix = new char[][] { arr1, arr2, arr3, arr4 };

            CoordinatesMap = new Dictionary<char, Coord>();
            for (int i = 0; i < Matrix.Length; i++)
            {
                for (int j = 0; j < Matrix[0].Length; j++)
                {
                    CoordinatesMap.Add(Matrix[i][j], new Coord(i, j));
                }
            }
        }

        // Map
        private Coord GetCoordinatesByChar(char c)
        {
            return CoordinatesMap[c];
        }

        // Transformations
        private Coord FlipHorizontally(Coord coord)
        {
            var maxIndex = Matrix[0].Length - 1;
            return new Coord(coord.i, maxIndex - coord.j);
        }

        private Coord FlipVertically(Coord coord)
        {
            var maxIndex = Matrix.Length - 1;
            return new Coord(maxIndex - coord.i, coord.j);
        }

        private Coord ShiftRight(Coord coord)
        {
            var maxIndex = Matrix[0].Length - 1;
            if (coord.j == maxIndex)
                return new Coord(coord.i, 0);
            else
                return new Coord(coord.i, coord.j + 1);
        }

        private Coord ShiftLeft(Coord coord)
        {
            if (coord.j == 0)
                return new Coord(coord.i, Matrix[0].Length - 1);
            else
                return new Coord(coord.i, coord.j - 1);
        }

        // Character transformation
        private char TransformChar(char c, string transformation)
        {
            var coord = GetCoordinatesByChar(c);
            var flips = transformation.Split(' ').ToArray();

            for (int i = 0; i < flips.Length; i++)
            {
                switch (flips[i])
                {
                    case "H": coord = FlipHorizontally(coord); break;
                    case "V": coord = FlipVertically(coord); break;
                    case "-1": coord = ShiftLeft(coord); break;
                    case "1": coord = ShiftRight(coord); break;
                }
            }
            return Matrix[coord.i][coord.j];
        }


        // Main eventush
        public void Transform(string str, string transformation)
        {
            var result = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = TransformChar(str[i], transformation);
            }
            TransformedString = new String(result);
        }

    }
}