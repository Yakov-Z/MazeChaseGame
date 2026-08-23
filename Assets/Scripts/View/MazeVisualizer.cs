using UnityEngine;

public class MazeVisualizer : MonoBehaviour
{
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public float cellSize = 1f;

    // Draws the maze based on the provided logic grid
    public void DrawMaze(MazeGrid grid)
    {
        for (int x = 0; x < grid.Width; x++)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                MazeNode node = grid.GetNode(x, y);
                
                // Calculate the world position for this cell
                Vector3 position = new Vector3(x * cellSize, 0, y * cellSize);

                // Instantiate the floor tile
                Instantiate(floorPrefab, position, Quaternion.identity, transform);

                // Calculate half size for wall offsets
                float offset = cellSize / 2f;

                // Top wall
                if (node.hasTopWall)
                    Instantiate(wallPrefab, position + new Vector3(0, 0, offset), Quaternion.identity, transform);
                
                // Bottom wall
                if (node.hasBottomWall)
                    Instantiate(wallPrefab, position + new Vector3(0, 0, -offset), Quaternion.identity, transform);

                // Right wall (Rotated 90 degrees)
                if (node.hasRightWall)
                    Instantiate(wallPrefab, position + new Vector3(offset, 0, 0), Quaternion.Euler(0, 90, 0), transform);

                // Left wall (Rotated 90 degrees)
                if (node.hasLeftWall)
                    Instantiate(wallPrefab, position + new Vector3(-offset, 0, 0), Quaternion.Euler(0, 90, 0), transform);
            }
        }
    }
}