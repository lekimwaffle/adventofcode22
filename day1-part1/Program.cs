var input = File.ReadAllLines("input.txt");
(int Index, int Calories) WinningElf = (0, 0);
(int Index, int Calories) CurrentElf = (1, 0);
for (int i = 0; i < input.Length; i++)
{
    if (int.TryParse(input[i], out var calories))
        CurrentElf.Calories += calories;
    
    if(calories == 0 || i == input.Length - 1)
    {
        if (CurrentElf.Calories > WinningElf.Calories)
            WinningElf = CurrentElf;

        CurrentElf = CurrentElf with { Index = CurrentElf.Index + 1, Calories = 0 };
    }
}

Console.WriteLine($"The winning elf is elf #{WinningElf.Index} with {WinningElf.Calories} Calories");