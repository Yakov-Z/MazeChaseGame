using System.Collections.Generic;

public class MazeGrid
{
    public MazeNode[,] Grid { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }

    public MazeGrid(int width, int height)
    {
        Width = width;
        Height = height;
        Grid = new MazeNode[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Grid[x, y] = new MazeNode(x, y);
            }
        }
    }

    public MazeNode GetNode(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return null;
        return Grid[x, y];
    }

    public List<MazeNode> GetNeighbors(MazeNode node)
    {
        List<MazeNode> neighbors = new List<MazeNode>();
        
        // Y+1 is UP in Unity, so we must check if there is NO Top Wall blocking us
        if(!node.hasTopWall && node.Y + 1 < Height)
            neighbors.Add(Grid[node.X, node.Y + 1]);
            
        // Y-1 is DOWN, so we must check if there is NO Bottom Wall
        if(!node.hasBottomWall && node.Y - 1 >= 0)
            neighbors.Add(Grid[node.X, node.Y - 1]);
            
        // X+1 is RIGHT
        if(!node.hasRightWall && node.X + 1 < Width)
            neighbors.Add(Grid[node.X + 1, node.Y]);
            
        // X-1 is LEFT
        if(!node.hasLeftWall && node.X - 1 >= 0)
            neighbors.Add(Grid[node.X - 1, node.Y]);
            
        return neighbors;
    }

    public List<MazeNode> GetAdjacentNodes(MazeNode node)
    {
        List<MazeNode> neighbors = new List<MazeNode>();
        
        if(node.Y + 1 < Height)
            neighbors.Add(Grid[node.X, node.Y + 1]);
            
        if(node.Y - 1 >= 0)
            neighbors.Add(Grid[node.X, node.Y - 1]);
            
        if(node.X + 1 < Width)
            neighbors.Add(Grid[node.X + 1, node.Y]);
            
        if(node.X - 1 >= 0)
            neighbors.Add(Grid[node.X - 1, node.Y]);
            
        return neighbors;
    }
}