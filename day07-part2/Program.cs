using System.Diagnostics;

var input = File.ReadAllLines("input.txt");
var currentNode = new TreeNode(null, "/");
for (int i = 1; i < input.Length; i++)
{
    if (char.IsNumber(input[i][0]))
        currentNode.Sizes.Add(int.Parse(input[i].Split(' ')[0]));
    else if (input[i].StartsWith("dir"))
        currentNode.Children.Add(new TreeNode(currentNode, input[i][4..]));
    else if (input[i].StartsWith("$ cd .."))
        currentNode = currentNode.Parent;
    else if (input[i].StartsWith("$ cd"))
        currentNode = currentNode.Children.First(x => x.Name.Equals(input[i][5..]));
}

var ordered = GetDirectories(FindRoot(currentNode)).OrderByDescending(x => x);
var unusedSpace = 70000000 - ordered.First();
var savior = ordered.Skip(1).Last(x => unusedSpace + x > 30000000);

Debug.WriteLine($"Size of directory to delete is {savior}");

TreeNode FindRoot(TreeNode node) => node.Parent == null ? node : FindRoot(node.Parent);
IEnumerable<int> GetDirectories(TreeNode nextNode)
{
    var directories = new List<int> { nextNode.TotalSize() };
    if (nextNode.Children.Any())
        foreach (var child in nextNode.Children)
            directories.AddRange(GetDirectories(child));

    return directories;
}

record TreeNode(TreeNode Parent, string Name)
{
    public ICollection<TreeNode> Children { get; } = new List<TreeNode>();
    public ICollection<int> Sizes { get; } = new List<int>();

    public int TotalSize() => Sizes.Sum() + Children.Sum(x => x.TotalSize());
}