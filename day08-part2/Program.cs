using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
var map = new int[input.Length, input[0].Length];
for (int x = 0; x < input.Length; x++)
    for (int y = 0; y < input[0].Length; y++)
        map[x, y] = input[y][x] - '0';

int highestViewingScore = Enumerable.Range(1, input.Length - 2)
                    .SelectMany(x => Enumerable.Range(1, input[0].Length - 2).Select(y => (X: x, Y: y)))
                    .Max(p => LookUpWest(p.X, p.Y) * LookUpNorth(p.X, p.Y) * LookUpEast(p.X, p.Y) * LookUpSouth(p.X, p.Y));

int LookUpWest(int startX, int startY) => startX - Enumerable.Range(0, startX).Reverse().FirstOrDefault(x => map[x, startY] >= map[startX, startY]);
int LookUpEast(int startX, int startY) => Enumerable.Range(startX + 1, input.Length - 2 - startX).FirstOrDefault(x => map[x, startY] >= map[startX, startY], input.Length - 1) - startX;
int LookUpNorth(int startX, int startY) => startY - Enumerable.Range(0, startY).Reverse().FirstOrDefault(y => map[startX, y] >= map[startX, startY]);
int LookUpSouth(int startX, int startY) => Enumerable.Range(startY + 1, input.Length - 2 - startY).FirstOrDefault(y => map[startX, y] >= map[startX, startY], input[0].Length - 1) - startY;

Debug.WriteLine($"The highest viewing score is {highestViewingScore}");