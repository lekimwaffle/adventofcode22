using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
var map = new int[input.Length, input[0].Length];
for (int x = 0; x < input.Length; x++)
    for (int y = 0; y < input[0].Length; y++)
        map[x, y] = input[y][x] - '0';

int visibleTrees = Enumerable.Range(0, input.Length)
                    .SelectMany(x => Enumerable.Range(0, input[0].Length).Select(y => (X: x, Y: y)))
                    .Count(p => p.X == 0 || p.Y == 0 || p.X == input.Length - 1 || p.Y == input[0].Length - 1 ||
                                LookUpWest(p.X, p.Y) || LookUpNorth(p.X, p.Y) || LookUpEast(p.X, p.Y) || LookUpSouth(p.X, p.Y));

bool LookUpWest(int startX, int startY) => Enumerable.Range(0, startX).All(x => map[x, startY] < map[startX, startY]);
bool LookUpEast(int startX, int startY) => Enumerable.Range(1, input.Length - 1 - startX).All(x => map[startX + x, startY] < map[startX, startY]);
bool LookUpNorth(int startX, int startY) => Enumerable.Range(0, startY).All(y => map[startX, y] < map[startX, startY]);
bool LookUpSouth(int startX, int startY) => Enumerable.Range(1, input[0].Length - 1 - startY).All(y => map[startX, startY + y] < map[startX, startY]);

Debug.WriteLine($"Amount of visible trees is {visibleTrees}");