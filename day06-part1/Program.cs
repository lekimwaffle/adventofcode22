using System.Diagnostics;

var input = File.ReadAllText("input.txt");

for (int i = 0; i < input.Length - 3; i++)
{
    if (input[i..(i+4)].Distinct().Count() == 4)
    {
        Debug.WriteLine($"The amount of characters = {i + 4}");
        break;
    }
}