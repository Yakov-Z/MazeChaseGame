using System.Collections.Generic;
public interface IPathFinder
{
    List<MazeNode> FindPath(MazeGrid maze, MazeNode start, MazeNode end);
}