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
    [SerializeField]
    private GameObject pack;
    [SerializeField]
    private GameObject astronuatController;
    float timer;
    public static float publicTimer;

    [System.Serializable]
    public struct wave
    {
        public int diffuculty;
        public int groups;
        public float baseEnemySpawnTime;
        public float maxTime;
        public int reward;
    }
    public wave[] waves;

    public Queue<(float, GameObject[])> timeLine;
    // Start is called before the first frame update
    void Start()
    {
        mES = ModyfiedEnemySpawner.Instance;
        if (waveDecider.Instance == null) Instantiate(pack);
        initiateFase(waves[waveDecider.Instance.startNewWave()]);
        //initiateFase(2,120,240);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>timeLine.Peek().Item1)
        {
            if(timeLine.Count < 2)
            {
                giveEndReward(waves[waveDecider.Instance.currentWave].reward, astronuatController, 20);
                SceneManager.LoadScene("RoundWonScene");
            }
            GameObject[] gm = timeLine.Dequeue().Item2;
            Debug.Log(gm.Length);
            Debug.Log(gm);
            if (!mES) mES = ModyfiedEnemySpawner.Instance;
            mES.SpawnEnemies(gm, (1f - (curDiffuculty / 3), 3f - (curDiffuculty / 3)), parrent);
        }
        if(transform.childCount < 1 && timer > curMaxTime)
        {
            giveEndReward(waves[waveDecider.Instance.currentWave].reward, astronuatController, 0);
            SceneManager.LoadScene("RoundWonScene");
        }
        publicTimer = timer;
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
        for (int i = 0; i < diffuculty*waves[waveDecider.Instance.currentWave].groups; i++)
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
    public void initiateFase(wave wave)
    {
        initiateFase(wave.diffuculty, wave.baseEnemySpawnTime, wave.maxTime);
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

    public void giveEndReward(int start , GameObject asc, int extraMinus)
    {
        waveDecider.Instance.giveReward(start - (asc.GetComponent<AstronautController>().maxAstronautCount - asc.GetComponent<AstronautController>().remainingAstronauts) - extraMinus);
    }
}
