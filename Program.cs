using CubeSolver.Model;

Cube cube = new Cube();

Console.WriteLine(cube.Print());
cube.ParseMoves("R U R' U'");

Console.WriteLine(cube.Print());



