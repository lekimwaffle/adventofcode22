var scores = new List<int> { default(char) }
    .Concat(Enumerable.Range('a', 26))
    .Concat(Enumerable.Range('A', 26))
    .Select((x, i) => (Character: (char)x, Score: i + 0))
    .ToDictionary(x => x.Character, x => x.Score);

var input = File.ReadAllLines("input.txt");
int cumulativeScore = input.Select(x => (First: x[..(x.Length / 2)], Second: x[(x.Length / 2)..]))
    .Sum(y => scores[y.First.FirstOrDefault(x => y.Second.Contains(x))]);

Console.WriteLine($"The total score is {cumulativeScore}");