
// A class that represents a single node in the maze grid.
public class MazeNode
{
    // Properties to store the X and Y coordinates of the node
    public int X { get; private set; }
    public int Y { get; private set; }

    // Properties to indicate the presence of walls around the node
    public bool hasTopWall { get; set; }
    public bool hasBottomWall { get; set; }
    public bool hasLeftWall { get; set; }
    public bool hasRightWall { get; set; }

    public MazeNode(int x, int y)
    {
        X = x;
        Y = y;
        hasTopWall = true;
        hasBottomWall = true;
        hasLeftWall = true;
        hasRightWall = true;
    }
}
