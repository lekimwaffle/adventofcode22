var lowerCase = Enumerable.Range('a', 26).ToList();
var upperCase = Enumerable.Range('A', 26).ToList();
lowerCase.AddRange(upperCase);
var scores = lowerCase.Select((x, i) => ((char)x, i + 1)).ToDictionary(x => x.Item1, x => x.Item2);
scores.Add(default, 0);

var input = File.ReadAllLines("input.txt");
int cumulativeScore = input.Chunk(3)
    .Select(x => (Source: x[0], Group: x[^2..]))
    .Sum(x => scores[x.Source.FirstOrDefault(y => x.Group.All(z => z.Contains(y)))]);

Console.WriteLine($"The total score is {cumulativeScore}");