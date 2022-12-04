using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
var count = input.Select(x => x.Split(',').Select(y => y.Split('-').Select(int.Parse)))
    .Count(x => CheckOverlap(x.First().First(), x.First().Last(), x.Last().First(), x.Last().Last()));
Debug.WriteLine($"The amount of fully contained pairs = {count}");

bool CheckOverlap(int leftFirst, int leftLast, int rightFirst, int rightLast)
{
    return  (leftFirst >= rightFirst && leftFirst <= rightLast) ||
            (leftLast >= rightFirst && leftLast <= rightLast) ||
            (rightFirst >= leftFirst && rightFirst <= leftLast) ||
            (rightLast >= leftFirst && rightLast <= leftLast);
}