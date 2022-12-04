var scores = new List<int> { default(char) }
    .Concat(Enumerable.Range('a', 26))
    .Concat(Enumerable.Range('A', 26))
    .Select((x, i) => (Character: (char)x, Score: i + 0))
    .ToDictionary(x => x.Character, x => x.Score);

var input = File.ReadAllLines("input.txt");
int cumulativeScore = input.Chunk(3)
    .Select(x => (Source: x[0], Group: x[^2..]))
    .Sum(x => scores[x.Source.FirstOrDefault(y => x.Group.All(z => z.Contains(y)))]);

Console.WriteLine($"The total score is {cumulativeScore}");