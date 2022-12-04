var lowerCase = Enumerable.Range('a', 26).ToList();
var upperCase = Enumerable.Range('A', 26).ToList();
lowerCase.AddRange(upperCase);
var scores = lowerCase.Select((x, i) => ((char)x, i + 1)).ToDictionary(x => x.Item1, x => x.Item2);
scores.Add(default, 0);

var input = File.ReadAllLines("input.txt");
int cumulativeScore = input.Select(x => (First: x[..(x.Length / 2)], Second: x[(x.Length / 2)..]))
    .Sum(y => scores[y.First.FirstOrDefault(x => y.Second.Contains(x))]);

Console.WriteLine($"The total score is {cumulativeScore}");