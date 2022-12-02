var input = File.ReadAllLines("input.txt");
const char RockShape = 'A', RockResponse = 'X';
const char PaperShape = 'B', PaperResponse = 'Y';
const char ScissorShape = 'C', ScissorResponse = 'Z';
var context = new Dictionary<char, ShapeData>
{
    [RockShape] = new (RockShape, 1, RockResponse), // Rock
    [PaperShape] = new (PaperShape, 2, PaperResponse), // Paper
    [ScissorShape] = new (ScissorShape, 3, ScissorResponse) // Scissor
};
int totalScore = 0;for (int i = 0; i < input.Length; i++)
{
    var round = input[i].Replace(" ", string.Empty);
    totalScore += GetScore(round[0], round[1]);
}

Console.WriteLine($"The total score is {totalScore}");

int GetScore(char Shape, char Response)
{
    (ShapeData Opponent, char Response) situation = (context[Shape], Response);
    return situation switch
    {
        _ when situation.Opponent.Response == Response => situation.Opponent.Score + 3,
        { Opponent.Shape: RockShape, Response: PaperResponse } => context[PaperShape].Score + 6,
        { Opponent.Shape: RockShape, Response: ScissorResponse } => context[ScissorShape].Score,
        { Opponent.Shape: PaperShape, Response: RockResponse } => context[RockShape].Score,
        { Opponent.Shape: PaperShape, Response: ScissorResponse } => context[ScissorShape].Score + 6,
        { Opponent.Shape: ScissorShape, Response: RockResponse } => context[RockShape].Score + 6,
        { Opponent.Shape: ScissorShape, Response: PaperResponse } => context[PaperShape].Score
    };
}

record ShapeData(char Shape, int Score, char Response);