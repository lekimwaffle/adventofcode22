using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
Coord head = new(0, 0);
Coord tail = new(0, 0);
var visited = new HashSet<Coord> { tail };
foreach (var line in input)
{
    Func<Coord, Coord> moveFunction = line[0] switch
    {
        'R' => c => new (c.X + 1, c.Y),
        'L' => c => new (c.X - 1, c.Y),
        'D' => c => new (c.X, c.Y + 1),
        'U' => c => new (c.X, c.Y - 1),
    };

    for(int step = 0; step < int.Parse(line[2..]); step++)
    {
        // Move head
        head = moveFunction(head);
        tail = head switch
        {
            _ when head.X > tail.X + 1 => new Coord(tail.X + 1, head.Y),
            _ when head.X < tail.X - 1 => new Coord(tail.X - 1, head.Y),
            _ when head.Y > tail.Y + 1 => new Coord(head.X, tail.Y + 1),
            _ when head.Y < tail.Y - 1 => new Coord(head.X, tail.Y - 1),
            _ => tail
        };

        if (!visited.Contains(tail))
            visited.Add(tail);
    }
}

Debug.WriteLine($"Amount of visited tiles is {visited.Count}");

record Coord(int X, int Y);