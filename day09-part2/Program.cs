using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
Coord[] knots = Enumerable.Range(0, 10).Select(x => new Coord(0,0)).ToArray();
var visited = new HashSet<Coord> { knots.Last() };
foreach (var line in input)
{
    Func<Coord, Coord> moveFunction = line[0] switch
    {
        'R' => c => new(c.X + 1, c.Y),
        'L' => c => new(c.X - 1, c.Y),
        'D' => c => new(c.X, c.Y + 1),
        'U' => c => new(c.X, c.Y - 1),
    };

    for (int step = 0; step < int.Parse(line[2..]); step++)
    {
        knots[0] = moveFunction(knots[0]);
        for(int knot = 0; knot < knots.Length - 1; knot++)
            knots[knot + 1] = Move(knots[knot], knots[knot + 1]);

        if (!visited.Contains(knots.Last()))
            visited.Add(knots.Last());
    }
}

static Coord Move(Coord lead, Coord follower) => lead switch
{
    _ when lead.X > follower.X + 1 && lead.Y > follower.Y + 1 => new Coord(follower.X + 1, follower.Y + 1),
    _ when lead.X < follower.X - 1 && lead.Y > follower.Y + 1 => new Coord(follower.X - 1, follower.Y + 1),
    _ when lead.Y < follower.Y - 1 && lead.X < follower.X - 1 => new Coord(follower.X - 1, follower.Y - 1),
    _ when lead.Y < follower.Y - 1 && lead.X > follower.X + 1 => new Coord(follower.X + 1, follower.Y - 1),
    _ when lead.X > follower.X + 1 => new Coord(follower.X + 1, lead.Y),
    _ when lead.X < follower.X - 1 => new Coord(follower.X - 1, lead.Y),
    _ when lead.Y > follower.Y + 1 => new Coord(lead.X, follower.Y + 1),
    _ when lead.Y < follower.Y - 1 => new Coord(lead.X, follower.Y - 1),
    _ => follower
};

Debug.WriteLine($"Amount of visited tiles is {visited.Count}");

record Coord(int X, int Y);