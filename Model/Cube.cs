using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeSolver.Model
{

    enum Color
    {
        White,
        Orange,
        Blue,
        Red,
        Green,
        Yellow
    }

    class CubeLine
    {

        //   0 1 2
        // 0 # # #
        // 1 # # #
        // 2 # # #

        public Color[] tiles = new Color[3];

        public bool isRow;

        public int face;
        public int index;

        public override string ToString()
        {
            return face.ToString() + ":" + string.Join(',', tiles.Select(x => x.ToString()));
        }

    }

    internal class Cube
    {
        //      ---
        //      |0|   
        //  --- --- --- ---
        //  |1| |2| |3| |4|
        //  --- --- --- ---
        //      |5|
        //      ---

        // 0 - White
        // 1 - Orange
        // 2 - Green
        // 3 - Red
        // 4 - Blue
        // 5 - Yellow


        public Color[][][] sides = new Color[6][][];
        public Cube()
        {
            Reset();
        }

        public void Reset()
        {

            sides = new Color[][][]
            {
                // 0 - White
                new Color[][]
                {
                    new Color[]
                    {
                        Color.White,Color.White,Color.White
                    },
                    new Color[]
                    {
                        Color.White,Color.White,Color.White
                    },
                    new Color[]
                    {
                        Color.White,Color.White,Color.White
                    }
                },
                // 1 - Orange
                new Color[][]
                {
                    new Color[]
                    {
                        Color.Orange,Color.Orange,Color.Orange
                    },
                    new Color[]
                    {
                        Color.Orange,Color.Orange,Color.Orange
                    },
                    new Color[]
                    {
                        Color.Orange,Color.Orange,Color.Orange
                    }
                },
                // 2 - Green
                new Color[][]
                {
                    new Color[]
                    {
                        Color.Green,Color.Green,Color.Green
                    },
                    new Color[]
                    {
                        Color.Green,Color.Green,Color.Green
                    },
                    new Color[]
                    {
                        Color.Green,Color.Green,Color.Green
                    }
                },
                // 3 - Red
                new Color[][]
                {
                    new Color[]
                    {
                        Color.Red,Color.Red,Color.Red
                    },
                    new Color[]
                    {
                        Color.Red,Color.Red,Color.Red
                    },
                    new Color[]
                    {
                        Color.Red,Color.Red,Color.Red
                    }
                },
                // 4 - Blue
                new Color[][]
                {
                    new Color[]
                    {
                        Color.Blue,Color.Blue,Color.Blue
                    },
                    new Color[]
                    {
                        Color.Blue,Color.Blue,Color.Blue
                    },
                    new Color[]
                    {
                        Color.Blue,Color.Blue,Color.Blue
                    }
                },
                // 5 - Yellow
                new Color[][]
                {
                    new Color[]
                    {
                        Color.Yellow,Color.Yellow,Color.Yellow
                    },
                    new Color[]
                    {
                        Color.Yellow,Color.Yellow,Color.Yellow
                    },
                    new Color[]
                    {
                        Color.Yellow,Color.Yellow,Color.Yellow
                    }
                },

            };
        }

        public void ParseMoves(string moves)
        {
            var splitMoves = moves.Split(' ');

            foreach (var move in splitMoves)
            {
                bool isPrime = move.Contains('\'');

                if (move.Length > 1 && int.TryParse(move[1].ToString(), out int moveAmmount))
                {
                    Move(move[0].ToString(), moveAmmount, isPrime);
                }
                else
                {
                    Move(move[0].ToString(), 1, isPrime);
                }

            }

        }

        public void Move(string move, int count = 1, bool prime = false)
        {

            var lines = new CubeLine[4];

            for (int i = 0; i < count; i++)
            {
                switch (move.ToUpper())
                {
                    case "R":
                        lines = new CubeLine[]
                        {
                        new CubeLine()
                        {
                            face = 2,
                            isRow = false,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 0,
                            isRow = false,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 4,
                            isRow = false,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 5,
                            isRow = false,
                            index = 2
                        }
                        };
                        foreach (var line in lines)
                        {
                            ResolveCubeLine(line);
                        }
                        lines = RotateLines(lines, prime);
                        foreach (var line in lines)
                        {
                            ApplyCubeLine(line);
                        }
                        //Spin the face
                        RotateFace(3, !prime);
                        continue;
                    case "L":
                        lines = new CubeLine[]
                        {
                        new CubeLine()
                        {
                            face = 2,
                            isRow = false,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 0,
                            isRow = false,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 4,
                            isRow = false,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 5,
                            isRow = false,
                            index = 0
                        }
    };
                        foreach (var line in lines)
                        {
                            ResolveCubeLine(line);
                        }
                        lines = RotateLines(lines, !prime);
                        foreach (var line in lines)
                        {
                            ApplyCubeLine(line);
                        }
                        //Spin the face
                        RotateFace(1, !prime);
                        continue;
                    case "U":
                        // Pick tiles
                        lines = new CubeLine[]
                        {
                        new CubeLine()
                        {
                            face = 1,
                            isRow = true,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 2,
                            isRow = true,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 3,
                            isRow = true,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 4,
                            isRow = true,
                            index = 0
                        }
                        };
                        foreach (var line in lines)
                        {
                            ResolveCubeLine(line);
                        }
                        lines = RotateLines(lines, !prime);
                        foreach (var line in lines)
                        {
                            ApplyCubeLine(line);
                        }
                        //Spin the face
                        RotateFace(0, prime);
                        continue;
                    case "D":
                        // Pick tiles
                        lines = new CubeLine[]
                        {
                        new CubeLine()
                        {
                            face = 1,
                            isRow = true,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 2,
                            isRow = true,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 3,
                            isRow = true,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 4,
                            isRow = true,
                            index = 2
                        }
                        };
                        foreach (var line in lines)
                        {
                            ResolveCubeLine(line);
                        }
                        lines = RotateLines(lines, prime);
                        foreach (var line in lines)
                        {
                            ApplyCubeLine(line);
                        }
                        //Spin the face
                        RotateFace(5, !prime);
                        break;
                    case "F":
                        // Pick tiles
                        lines = new CubeLine[]
                        {
                        new CubeLine()
                        {
                            face = 0,
                            isRow = true,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 3,
                            isRow = false,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 5,
                            isRow = true,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 1,
                            isRow = false,
                            index = 2
                        }
                        };
                        foreach (var line in lines)
                        {
                            ResolveCubeLine(line);
                        }
                        lines = RotateLines(lines, prime);
                        foreach (var line in lines)
                        {
                            ApplyCubeLine(line);
                        }
                        //Spin the face
                        RotateFace(2, !prime);
                        continue;
                    case "B":
                        // Pick tiles
                        lines = new CubeLine[]
                        {
                        new CubeLine()
                        {
                            face = 0,
                            isRow = true,
                            index = 0
                        },
                        new CubeLine()
                        {
                            face = 3,
                            isRow = false,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 5,
                            isRow = true,
                            index = 2
                        },
                        new CubeLine()
                        {
                            face = 1,
                            isRow = false,
                            index = 0
                        }
                        };
                        foreach (var line in lines)
                        {
                            ResolveCubeLine(line);
                        }
                        lines = RotateLines(lines, !prime);
                        foreach (var line in lines)
                        {
                            ApplyCubeLine(line);
                        }
                        //Spin the face
                        RotateFace(4, prime);
                        continue;
                    default:
                        break;
                }
            }

        }

        void RotateRow(int[] faces, int row, bool prime)
        {

            if (!prime)
            {
                Array.Reverse(faces);
            }

            Color[]? currentRow = null;
            Color[]? targetRow = null;

            for (int sideIndex = 0; sideIndex < faces.Length; sideIndex++)
            {
                if (targetRow == null)
                {
                    currentRow = sides[faces[sideIndex]][row];
                }

                if (sideIndex + 1 >= faces.Length && currentRow != null)
                {
                    targetRow = sides[faces[0]][row];
                    sides[faces[0]][row] = currentRow;
                }
                else
                {
                    targetRow = sides[faces[sideIndex + 1]][row];
                    sides[faces[sideIndex + 1]][row] = currentRow;
                }

                currentRow = targetRow;

            }
        }

        CubeLine[] RotateLines(CubeLine[] lines, bool prime)
        {
            if (!prime)
            {
                Array.Reverse(lines);
            }

            var result = new CubeLine[lines.Length];

            var temp = lines[lines.Length - 1];

            foreach (var line in lines)
            {
                if (line.face == 4)
                {
                    Array.Reverse(line.tiles);
                }
            }

            for (int i = 0; i < lines.Length - 1; i++)
            {
                result[i] = new CubeLine
                {
                    face = lines[i].face,
                    index = lines[i].index,
                    isRow = lines[i].isRow,
                    tiles = lines[i + 1].tiles
                };

            }

            result[result.Length - 1] = new CubeLine
            {
                face = temp.face,
                index = temp.index,
                isRow = temp.isRow,
                tiles = lines[0].tiles
            };

            return result;
        }

        void ResolveCubeLine(CubeLine line)
        {
            if (line.isRow)
            {
                Array.Copy(sides[line.face][line.index], line.tiles, sides[line.face][line.index].Length);
            }
            else
            {
                switch (line.index)
                {
                    case 0:
                        line.tiles[0] = sides[line.face][0][0];
                        line.tiles[1] = sides[line.face][1][0];
                        line.tiles[2] = sides[line.face][2][0];
                        break;
                    case 1:
                        line.tiles[0] = sides[line.face][0][1];
                        line.tiles[1] = sides[line.face][1][1];
                        line.tiles[2] = sides[line.face][2][1];
                        break;
                    case 2:
                        line.tiles[0] = sides[line.face][0][2];
                        line.tiles[1] = sides[line.face][1][2];
                        line.tiles[2] = sides[line.face][2][2];
                        break;
                    default:
                        break;
                }
            }

        }

        void ApplyCubeLine(CubeLine line)
        {
            if (line.isRow)
            {
                sides[line.face][line.index][0] = line.tiles[0];
                sides[line.face][line.index][1] = line.tiles[1];
                sides[line.face][line.index][2] = line.tiles[2];
            }
            else
            {
                switch (line.index)
                {
                    case 0:
                        sides[line.face][0][0] = line.tiles[0];
                        sides[line.face][1][0] = line.tiles[1];
                        sides[line.face][2][0] = line.tiles[2];
                        break;
                    case 1:
                        sides[line.face][0][1] = line.tiles[0];
                        sides[line.face][1][1] = line.tiles[1];
                        sides[line.face][2][1] = line.tiles[2];
                        break;
                    case 2:
                        sides[line.face][0][2] = line.tiles[0];
                        sides[line.face][1][2] = line.tiles[1];
                        sides[line.face][2][2] = line.tiles[2];
                        break;
                    default:
                        break;
                }
            }
        }

        void RotateFace(int faceIndex, bool prime)
        {
            if (prime)
            {
                rotate90Clockwise(sides[faceIndex], 3);
            }
            else
            {
                rotate90Clockwise(sides[faceIndex], 3);
                rotate90Clockwise(sides[faceIndex], 3);
                rotate90Clockwise(sides[faceIndex], 3);
            }
        }

        void rotate90Clockwise(Color[][] a, int N)
        {
            // Traverse each cycle
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = i; j < N - i - 1; j++)
                {

                    // Swap elements of each cycle
                    // in clockwise direction
                    Color temp = a[i][j];
                    a[i][j] = a[N - 1 - j][i];
                    a[N - 1 - j][i] = a[N - 1 - i][N - 1 - j];
                    a[N - 1 - i][N - 1 - j] = a[j][N - 1 - i];
                    a[j][N - 1 - i] = temp;
                }
            }

        }

        public string ColorToString(Color color)
        {
            return color switch
            {
                Color.White => "W",
                Color.Orange => "O",
                Color.Blue => "B",
                Color.Red => "R",
                Color.Green => "G",
                Color.Yellow => "Y",
                _ => "",
            };
        }

        public string Print()
        {
            return @$"
            |---|---|---|
            |-{ColorToString(sides[0][0][0])}-|-{ColorToString(sides[0][0][1])}-|-{ColorToString(sides[0][0][2])}-|
            |-{ColorToString(sides[0][1][0])}-|-{ColorToString(sides[0][1][1])}-|-{ColorToString(sides[0][1][2])}-|
            |-{ColorToString(sides[0][2][0])}-|-{ColorToString(sides[0][2][1])}-|-{ColorToString(sides[0][2][2])}-|
            |---|---|---|
|---|---|---|---|---|---|---|---|---|---|---|---|
|-{ColorToString(sides[1][0][0])}-|-{ColorToString(sides[1][0][1])}-|-{ColorToString(sides[1][0][2])}-|-{ColorToString(sides[2][0][0])}-|-{ColorToString(sides[2][0][1])}-|-{ColorToString(sides[2][0][2])}-|-{ColorToString(sides[3][0][0])}-|-{ColorToString(sides[3][0][1])}-|-{ColorToString(sides[3][0][2])}-|-{ColorToString(sides[4][0][2])}-|-{ColorToString(sides[4][0][1])}-|-{ColorToString(sides[4][0][0])}-|
|-{ColorToString(sides[1][1][0])}-|-{ColorToString(sides[1][1][1])}-|-{ColorToString(sides[1][1][2])}-|-{ColorToString(sides[2][1][0])}-|-{ColorToString(sides[2][1][1])}-|-{ColorToString(sides[2][1][2])}-|-{ColorToString(sides[3][1][0])}-|-{ColorToString(sides[3][1][1])}-|-{ColorToString(sides[3][1][2])}-|-{ColorToString(sides[4][1][2])}-|-{ColorToString(sides[4][1][1])}-|-{ColorToString(sides[4][1][0])}-|
|-{ColorToString(sides[1][2][0])}-|-{ColorToString(sides[1][2][1])}-|-{ColorToString(sides[1][2][2])}-|-{ColorToString(sides[2][2][0])}-|-{ColorToString(sides[2][2][1])}-|-{ColorToString(sides[2][2][2])}-|-{ColorToString(sides[3][2][0])}-|-{ColorToString(sides[3][2][1])}-|-{ColorToString(sides[3][2][2])}-|-{ColorToString(sides[4][2][2])}-|-{ColorToString(sides[4][2][1])}-|-{ColorToString(sides[4][2][0])}-|
|---|---|---|---|---|---|---|---|---|---|---|---|
            |-{ColorToString(sides[5][0][0])}-|-{ColorToString(sides[5][0][1])}-|-{ColorToString(sides[5][0][2])}-|
            |-{ColorToString(sides[5][1][0])}-|-{ColorToString(sides[5][1][1])}-|-{ColorToString(sides[5][1][2])}-|
            |-{ColorToString(sides[5][2][0])}-|-{ColorToString(sides[5][2][1])}-|-{ColorToString(sides[5][2][2])}-|
            |---|---|---|";

        }

        public override string ToString()
        {

            string result = "";

            for (int face = 0; face < sides.Length; face++)
            {
                for (int row = 0; row < sides[face].Length; row++)
                {
                    for (int col = 0; col < sides[face][row].Length; col++)
                    {
                        result += ColorToString(sides[face][col][row]);
                    }
                }
            }

            return result;
        }
    }
}
