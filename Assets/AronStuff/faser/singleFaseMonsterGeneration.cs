using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class singleFaseMonsterGeneration : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    ModyfiedEnemySpawner mES;
    [SerializeField]
    private Transform parrent;
    [SerializeField]
    private GameObject loadNextScene;
    float timer;

    public Queue<(float, GameObject[])> timeLine;
    // Start is called before the first frame update
    void Start()
    {
        mES = ModyfiedEnemySpawner.Instance;
        initiateFase(2,120,240);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>timeLine.Peek().Item1)
        {
            GameObject[] gm = timeLine.Dequeue().Item2;
            Debug.Log(gm.Length);
            Debug.Log(gm);
            if (!mES) mES = ModyfiedEnemySpawner.Instance;
            mES.SpawnEnemies(gm, (1f - (curDiffuculty / 3), 3f - (curDiffuculty / 3)), parrent);
        }
        if(transform.childCount < 1 && timer > 40)
        {
            SceneManager.LoadScene("UpgradeScene");
        }
    }
    int curDiffuculty;
    float curBaseEnemySpawnTime;
    float curMaxTime;
    public void initiateFase(int diffuculty, float baseEnemySpawnTime, float maxTime)
    {
        timer = 0;
        curDiffuculty = diffuculty;
        curBaseEnemySpawnTime = baseEnemySpawnTime;
        curMaxTime = maxTime;
        List<(float, GameObject[])> ls = new List<(float, GameObject[])>();
        for (int i = 0; i < diffuculty*5; i++)
        {
            ls.Add((UnityEngine.Random.Range(0, baseEnemySpawnTime), fillArray(Random.Range(1 * diffuculty, 5 * diffuculty), enemies)));
            ls.Sort(delegate ((float, GameObject[]) x, (float, GameObject[]) y)
            {
                if (x.Item1 == y.Item1) return 0;
                if (x.Item1 < y.Item1) return -1;
                if (x.Item1 > y.Item1) return 1;
                else return 0;
            });
            timeLine = new Queue<(float, GameObject[])>(ls);
            timeLine.Enqueue((maxTime, new GameObject[] { loadNextScene } ));
        }
    }

    GameObject[] fillArray(int size, GameObject fill)
    {
        GameObject[] gma = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            gma[i] = fill;
        }
        return gma;
    }
    GameObject[] fillArray(int size, GameObject[] fill)
    {
        GameObject[] gma = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            gma[i] = fill[Random.Range(0,fill.Length-1)];
        }
        return gma;
    }
}