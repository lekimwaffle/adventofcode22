using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
var count = input.Select(x => x.Split(',').Select(y => y.Split('-').Select(int.Parse)))
    .Count(x => 
    (x.First().First() >= x.Last().First() && x.First().Last() <= x.Last().Last()) || 
    (x.First().First() <= x.Last().First() && x.First().Last() >= x.Last().Last()));
Debug.WriteLine($"The amount of fully contained pairs = {count}");