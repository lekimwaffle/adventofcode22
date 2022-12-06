using System.Diagnostics;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");
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

        if(rowIndex == 1)
            stacks[0].Add(input[index][rowIndex]);
        else
            stacks[(rowIndex - 1) / 4].Add(input[index][rowIndex]);
    }
}

index+=2;
foreach (var stack in stacks)
    stack.Reverse();

var regex = new Regex("[0-9]+");
for (; index < input.Length; index++)
{
    var matches = regex.Matches(input[index]).Select(x => int.Parse(x.Value)).ToArray();
    var range = stacks[matches[1] - 1].GetRange(stacks[matches[1] - 1].Count - matches[0], matches[0]);
    range.Reverse();
    stacks[matches[2] - 1].AddRange(range);
    stacks[matches[1] - 1].RemoveRange(stacks[matches[1] - 1].Count - matches[0], matches[0]);
}

Debug.WriteLine($"The answer is: {new string(stacks.Where(x => x.Count > 0).Select(x => x.Last()).ToArray())}");