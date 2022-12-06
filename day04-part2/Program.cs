using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
var count = input.Select(x => x.Split(',', '-').Select(int.Parse))
    .Select(x => x.ToArray())
    .Count(x => (x[0] >= x[2] && x[0] <= x[3]) ||
                (x[1] >= x[2] && x[1] <= x[3]) ||
                (x[2] >= x[0] && x[2] <= x[1]) ||
                (x[3] >= x[0] && x[3] <= x[1]));
Debug.WriteLine($"The amount of overlapping pairs = {count}");