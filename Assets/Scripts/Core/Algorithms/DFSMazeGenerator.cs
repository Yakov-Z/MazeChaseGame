using System.Collections.Generic;
using System;
public class DFSMazeGenerator : IMazeGenerator
{
    public void GenerateMaze(MazeGrid maze, int startX, int startY)
    {
        HashSet<MazeNode> visited = new HashSet<MazeNode>();
        MazeNode startNode = maze.GetNode(startX,startY);
        Stack<MazeNode> stack = new Stack<MazeNode>();
        Random rand = new Random();

        visited.Add(startNode);
        stack.Push(startNode);

        while(stack.Count > 0)
        {
            MazeNode curNode = stack.Peek();
            List<MazeNode> neighbors = maze.GetAdjacentNodes(curNode);
            List<MazeNode> validNeighbors = new List<MazeNode>();
            foreach(MazeNode neighbor in neighbors)
            {
                if(!visited.Contains(neighbor))
                    validNeighbors.Add(neighbor);
            }
            if(validNeighbors.Count == 0)
            {
                stack.Pop();
                continue;
            }

            int digDir = rand.Next(validNeighbors.Count);
            MazeNode digNeighbor = validNeighbors[digDir];

            if(digNeighbor.X < curNode.X)
            {
                curNode.hasLeftWall = false;
                digNeighbor.hasRightWall = false;
            }                
            else if(digNeighbor.X > curNode.X)
            {
                curNode.hasRightWall = false;
                digNeighbor.hasLeftWall = false;
            }               
            else if(digNeighbor.Y < curNode.Y)
            {
                curNode.hasTopWall = false;
                digNeighbor.hasBottomWall = false;
            }                
            else if(digNeighbor.Y > curNode.Y)
            {
                curNode.hasBottomWall = false;
                digNeighbor.hasTopWall = false;
            }
                        
            stack.Push(digNeighbor);
            visited.Add(digNeighbor);
        }
    }
}