var input = File.ReadAllLines("input.txt");
const char RockShape = 'A';
const char PaperShape = 'B';
const char ScissorShape = 'C';
var context = new Dictionary<char, ShapeData>
{
    [RockShape] = new(RockShape, 1), // Rock
    [PaperShape] = new(PaperShape, 2), // Paper
    [ScissorShape] = new(ScissorShape, 3) // Scissor
};

int totalScore = 0;
for (int i = 0; i < input.Length; i++)
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
        _ when Response == 'Y' => situation.Opponent.Score + 3,
        { Opponent.Shape: RockShape, Response: 'X' } => context[ScissorShape].Score,
        { Opponent.Shape: RockShape, Response: 'Z' } => context[PaperShape].Score + 6,
        { Opponent.Shape: PaperShape, Response: 'X' } => context[RockShape].Score,
        { Opponent.Shape: PaperShape, Response: 'Z' } => context[ScissorShape].Score + 6,
        { Opponent.Shape: ScissorShape, Response: 'X' } => context[PaperShape].Score,
        { Opponent.Shape: ScissorShape, Response: 'Z' } => context[RockShape].Score + 6
    };
}

record ShapeData(char Shape, int Score);