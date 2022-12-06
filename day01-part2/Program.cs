var input = File.ReadAllLines("input.txt");
(int Index, int Calories)[] Top3 = { (0, 0), (0, 0), (0, 0) };
(int Index, int Calories) CurrentElf = (1, 0);
for (int i = 0; i < input.Length; i++)
{
    if (int.TryParse(input[i], out var calories))
        CurrentElf.Calories += calories;

    if (calories == 0 || i == input.Length - 1)
    {
        for (int t = 0; t < Top3.Length; t++)
        {
            if (CurrentElf.Calories > Top3[t].Calories)
            {
                var tempList = new List<(int Index, int Calories)>(Top3[0..t]) { CurrentElf };
                tempList.AddRange(Top3[t..^1]);
                Top3 = tempList.ToArray();
                break;
            }
        }

        CurrentElf = (CurrentElf.Index + 1, 0);
    }
}

Console.WriteLine($"The winning elfs are elf #{Top3.Aggregate(string.Empty, (x, y) => $"{x} {y.Index}")} with {Top3.Sum(x => x.Calories)} Calories");