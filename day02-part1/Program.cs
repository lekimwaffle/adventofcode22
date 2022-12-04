var input = File.ReadAllLines("input.txt");
const char RockShape = 'A', RockResponse = 'X';
const char PaperShape = 'B', PaperResponse = 'Y';
const char ScissorShape = 'C', ScissorResponse = 'Z';
var scores = new Dictionary<char, int>
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
        { Shape: RockShape, Response: PaperResponse } => scores[PaperShape] + 6,
        { Shape: RockShape, Response: ScissorResponse } => scores[ScissorShape],
        { Shape: PaperShape, Response: RockResponse } => scores[RockShape],
        { Shape: PaperShape, Response: ScissorResponse } => scores[ScissorShape] + 6,
        { Shape: ScissorShape, Response: RockResponse } => scores[RockShape] + 6,
        { Shape: ScissorShape, Response: PaperResponse } => scores[PaperShape],
        _ => scores[Shape] + 3
    };
}