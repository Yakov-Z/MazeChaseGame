using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private MazeVisualizer mazeVisualizer;
    
    [SerializeField] private int width=10;
    
    [SerializeField] private int height=10;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject exitPointPrefab;
    private float cellSize;

    public void Start()
    {
        cellSize = mazeVisualizer.cellSize;
        DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
        MazeGrid maze = new MazeGrid(width,height);
        
        mazeGenerator.GenerateMaze(maze,0,0);
        mazeVisualizer.DrawMaze(maze);
        SpawnCharacters(maze);

        float centerX = (width - 1) / 2f * mazeVisualizer.cellSize;
        float centerY = (height - 1) / 2f * mazeVisualizer.cellSize;

        Camera.main.transform.position = new Vector3(centerX,centerY,-10f);
    }

    private void SpawnCharacters(MazeGrid maze)
    {
        Vector3 playerStartPos = new Vector3(0, 0, 0);
        GameObject playerObj = Instantiate(playerPrefab, playerStartPos, Quaternion.identity);

        int endX = width - 1;
        int endY = height - 1;
        Vector3 enemyStartPos = new Vector3(endX * cellSize, endY * cellSize, 0);
        
        GameObject enemyObj = Instantiate(enemyPrefab, enemyStartPos, Quaternion.identity);

        EnemyController enemyBrain = enemyObj.GetComponent<EnemyController>();
        if (enemyBrain != null)
        {
            enemyBrain.Init(maze, playerObj.transform, cellSize);
        }

        Vector3 exitPos = new Vector3(endX * cellSize, 0, 0);
        Instantiate(exitPointPrefab, exitPos, Quaternion.identity);
    }
}