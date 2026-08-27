using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed=3f;
    private Transform player;
    [SerializeField] private MovementVisualizer movementVisualizer;
    private BFSPathFinder bFSPathFinder;
    private MazeGrid maze;
    [SerializeField] private float thinkRate=0.2f;
    private float cellSize;
    public void Start()
    {
        movementVisualizer = GetComponent<MovementVisualizer>();
        movementVisualizer.speed = speed;
        bFSPathFinder = new BFSPathFinder();
        StartCoroutine(HuntPlayerLoop());
    }
    public void Init(MazeGrid generatedMaze, Transform targetPlayer, float cellSize)
    {
        maze = generatedMaze;
        player = targetPlayer;
        this.cellSize = cellSize;
    }
    private IEnumerator HuntPlayerLoop()
    {
        while (true)
        {
            if (maze != null && player != null)
            {
                SetNextTarget();
            }
            yield return new WaitForSeconds(thinkRate);
        }
    }

    private void SetNextTarget()
    {
        MazeNode start = CalculateNode(transform.position);
        MazeNode end = CalculateNode(player.position);
        List<MazeNode> path = bFSPathFinder.FindPath(maze,start,end);
        if(path.Count > 1)
        {
            MazeNode nextNode = path[1];
            movementVisualizer.SetTargetPos(new Vector3(nextNode.X * cellSize ,nextNode.Y * cellSize ,0f));
        }
    }
    private MazeNode CalculateNode(Vector3 pos)
    {
        int GridX = Mathf.RoundToInt(pos.x / cellSize);
        int GridY = Mathf.RoundToInt(pos.y / cellSize);
        return maze.GetNode(GridX,GridY);
    }
}