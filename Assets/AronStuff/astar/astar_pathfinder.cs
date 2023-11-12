using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astar_pathfinder : MonoBehaviour
{
    [SerializeField]
    private Transform middle;
    public int colliderRange;
    [SerializeField]
    private GameObject myCollider;

    private List<GameObject> gameObjects = new List<GameObject>();
    public bool[,] hits;

    private bool shouldUpdate;

    public static astar_pathfinder instance;

    [SerializeField]
    private Sprite box;
    // Start is called before the first frame update
    void Start()
    {
        hits = new bool[colliderRange * 2, colliderRange * 2];
        for (int i = -colliderRange;  i < colliderRange; i++)
        {
            for (int j = -colliderRange; j < colliderRange; j++)
            {
                gameObjects.Add(Instantiate(myCollider, new Vector3(middle.position.x + i, middle.position.y + j, 0), transform.rotation, transform));
            }
        }
        instance = this;

        //visAll();
        astarVisuel((0, 0), (1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldUpdate)
        {
            Debug.Log("updating astar list");
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i] == null)
                {
                    Debug.Log("collider doesnt exist");
                }
                else if (gameObjects[i].GetComponent<colliderScript>() == null)
                {
                    Debug.Log("collider doesnt have a colliderScript");
                }
                int lx = (int)gameObjects[i].transform.position.x, ly = (int)gameObjects[i].transform.position.y;
                hits[lx+colliderRange, ly+colliderRange] = gameObjects[i].GetComponent<colliderScript>().hasCollided;
            }
            shouldUpdate = false;
        }
    }

    public void updateNextTime()
    {
        shouldUpdate = true;
    }

    public List<(int,int)> astar((int, int) myPos, (int, int) destination)
    {
        return AStar.AStarSearch(hits, myPos, destination);
    }
    public List<(int, int)> astarVisuel((int, int) myPos, (int, int) destination)
    {
        List<(int,int)> ls = AStar.AStarSearch(hits, myPos, destination);
        if (ls == null) Debug.Log("ls is null");
        for(int i = 0; i < ls.Count; i++)
        {
            int i1 = ls[i].Item1, i2 = ls[i].Item2;
            GameObject g = gameObjects[(i1+1)*(i2+1)-1];
            SpriteRenderer spr = g.AddComponent<SpriteRenderer>();
            spr.sprite = box;
            spr.color = Color.red;
        }
        return ls;
    }

    public void visAll()
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject g = gameObjects[i];
            SpriteRenderer spr = g.AddComponent<SpriteRenderer>();
            spr.sprite = box;
            spr.color = Color.red;
        }
    }
}

class AStar
{
    static int[] dx = { -1, 0, 1, 0 };
    static int[] dy = { 0, 1, 0, -1 };

    static bool IsValid(int x, int y, bool[,] grid)
    {
        return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1) && grid[x, y];
    }

    static int CalculateHeuristic(int x, int y, int goalX, int goalY)
    {
        // Euclidean distance heuristic
        return (int)Math.Sqrt(Math.Pow(x - goalX, 2) + Math.Pow(y - goalY, 2));
    }

    static public List<(int, int)> AStarSearch(bool[,] grid, (int, int) start, (int, int) goal)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        int[,] cost = new int[rows, cols];
        int[,] heuristic = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cost[i, j] = int.MaxValue;
                heuristic[i, j] = CalculateHeuristic(i, j, goal.Item1, goal.Item2);
            }
        }

        cost[start.Item1, start.Item2] = 0;

        PriorityQueue<(int, int)> openSet = new PriorityQueue<(int, int)>(new CustomComparer<(int, int)>((x, y) => (cost[x.Item1, x.Item2] + heuristic[x.Item1, x.Item2]).CompareTo(cost[y.Item1, y.Item2] + heuristic[y.Item1, y.Item2])));

        openSet.Enqueue(start);

        Dictionary<(int, int), (int, int)> cameFrom = new Dictionary<(int, int), (int, int)>();

        while (openSet.Count > 0)
        {
            var current = openSet.Dequeue();

            if (current == goal)
            {
                // Reconstruct path
                List<(int, int)> finalPath = new List<(int, int)>();
                while (cameFrom.ContainsKey(current))
                {
                    finalPath.Insert(0, current);
                    current = cameFrom[current];
                }
                finalPath.Insert(0, start);
                return finalPath;
            }

            for (int i = 0; i < 4; i++)
            {
                int nextX = current.Item1 + dx[i];
                int nextY = current.Item2 + dy[i];

                if (IsValid(nextX, nextY, grid))
                {
                    int newCost = cost[current.Item1, current.Item2] + 1;

                    if (newCost < cost[nextX, nextY])
                    {
                        cost[nextX, nextY] = newCost;
                        openSet.Enqueue((nextX, nextY));
                        cameFrom[(nextX, nextY)] = current;
                    }
                }
            }
        }

        Debug.Log("no path found");
        // No path found
        return null;
    }

    static void randimMain()
    {
        bool[,] grid = new bool[,]
        {
            { true, true, true, true, true },
            { true, false, true, false, true },
            { true, true, true, true, true },
            { true, true, true, true, true },
            { true, true, true, true, true }
        };

        (int, int) start = (0, 0);
        (int, int) goal = (4, 4);

        List<(int, int)> path = AStarSearch(grid, start, goal);

        if (path != null)
        {
            Console.WriteLine("Path found:");
            foreach (var point in path)
            {
                Console.WriteLine($"({point.Item1}, {point.Item2})");
            }
        }
        else
        {
            Console.WriteLine("No path found.");
        }
    }
}


class PriorityQueue<T>
{
    private SortedSet<T> set;
    private IComparer<T> comparer;

    public PriorityQueue(IComparer<T> comparer)
    {
        this.comparer = comparer;
        set = new SortedSet<T>(comparer);
    }

    public void Enqueue(T item)
    {
        set.Add(item);
    }

    public T Dequeue()
    {
        var item = set.Min;
        set.Remove(item);
        return item;
    }

    public int Count
    {
        get { return set.Count; }
    }
}

class CustomComparer<T> : IComparer<T>
{
    private readonly Func<T, T, int> compareFunction;

    public CustomComparer(Func<T, T, int> compareFunction)
    {
        this.compareFunction = compareFunction;
    }

    public int Compare(T x, T y)
    {
        return compareFunction(x, y);
    }
}