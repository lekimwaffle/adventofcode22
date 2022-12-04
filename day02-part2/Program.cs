var input = File.ReadAllLines("input.txt");
const char RockShape = 'A';
const char PaperShape = 'B';
const char ScissorShape = 'C';
var context = new Dictionary<char, int>
{
    [RockShape] = 1, // Rock
    [PaperShape] = 2, // Paper
    [ScissorShape] = 3 // Scissor
};

int totalScore = 0;
for (int i = 0; i < input.Length; i++)
    totalScore += GetScore(input[i][0], input[i][2]);

Console.WriteLine($"The total score is {totalScore}");

int GetScore(char Shape, char Response)
{
    return (Shape, Response) switch
    {
        { Shape: RockShape, Response: 'X' } => context[ScissorShape],
        { Shape: RockShape, Response: 'Z' } => context[PaperShape] + 6,
        { Shape: PaperShape, Response: 'X' } => context[RockShape],
        { Shape: PaperShape, Response: 'Z' } => context[ScissorShape] + 6,
        { Shape: ScissorShape, Response: 'X' } => context[PaperShape],
        { Shape: ScissorShape, Response: 'Z' } => context[RockShape] + 6,
        _ => context[Shape] + 3
    };
}