using System.Diagnostics;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");
var regex = new Regex("[0-9]+");
var stacks = Enumerable.Range(0, 9).Select(x => new List<char>()).ToArray();

int index = 0;
for (; index < input.Length; index++)
{
    if (char.IsNumber(input[index][1]))
        break;

    for(int rowIndex = 1; rowIndex < input[index].Length; rowIndex += 4)
    {
        if (char.IsWhiteSpace(input[index][rowIndex]))
            continue;

        stacks[(rowIndex - 1) / 4].Insert(0, input[index][rowIndex]);
    }
}

for (index += 2; index < input.Length; index++)
{
    var matches = regex.Matches(input[index]).Select(x => int.Parse(x.Value)).ToArray();
    (int amount, List<char> target, List<char> source) = (matches[0], stacks[matches[2] - 1], stacks[matches[1] - 1]);
    target.AddRange(Enumerable.Reverse(source.GetRange(source.Count - amount, amount)));
    source.RemoveRange(source.Count - amount, amount);
}

Debug.WriteLine($"The answer is: {new string(stacks.Where(x => x.Count > 0).Select(x => x.Last()).ToArray())}");