using System.Diagnostics;

var input = File.ReadAllText("input.txt");

for (int i = 0; i < input.Length - 13; i++)
{
    if (input[i..(i + 14)].Distinct().Count() == 14)
    {
        Debug.WriteLine($"The amount of characters = {i + 14}");
        break;
    }
}