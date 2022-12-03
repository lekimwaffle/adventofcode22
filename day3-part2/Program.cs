var lowerCase = Enumerable.Range('a', 26).ToList();
var upperCase = Enumerable.Range('A', 26).ToList();
lowerCase.AddRange(upperCase);
var scores = lowerCase.Select((x, i) => ((char)x, i + 1)).ToDictionary(x => x.Item1, x => x.Item2);

var input = File.ReadAllLines("input.txt");
int cumulativeScore = 0;

foreach (var group in input.Chunk(3))
{
    foreach (var type in group[0])
    {
        if (group[1].Contains(type) && group[2].Contains(type))
        {
            cumulativeScore += scores[type];
            break;
        }
    }
}

Console.WriteLine($"The total score is {cumulativeScore}");