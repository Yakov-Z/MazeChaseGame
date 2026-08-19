using System.Collections.Generic;
public class BFSPathFinder : IPathFinder
{
    public List<MazeNode> FindPath(MazeGrid maze, MazeNode start, MazeNode end)
    {
        List<MazeNode> path = new List<MazeNode>();
        HashSet<MazeNode> visited = new HashSet<MazeNode>();
        Queue<MazeNode> queue = new Queue<MazeNode>();
        Dictionary<MazeNode, MazeNode> parents = new Dictionary<MazeNode, MazeNode>();
        bool foundPath = false;

        visited.Add(start);
        queue.Enqueue(start);

        while(queue.Count > 0)
        {
            MazeNode curNode = queue.Dequeue();
            if(curNode == end)
            {
                foundPath = true;
                break;
            }

            List<MazeNode> neighbors = maze.GetNeighbors(curNode);
            foreach(MazeNode neighbor in neighbors)
            {
                if(!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parents.Add(neighbor,curNode);
                    queue.Enqueue(neighbor);
                }
            }
        }
        if (!foundPath && start != end)
        {
            return path; 
        }
        MazeNode cur = end;
        path.Add(cur);
        while(cur != start)
        {
            path.Add(parents[cur]);
            cur = parents[cur];
        }
        path.Reverse();
        return path;
    }
}