using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class astroidSpawner : MonoBehaviour
{

    [SerializeField]
    private Transform astroidSpawnPosition;
    [SerializeField]
    private float minSpawnDistance;
    [SerializeField]
    private float maxSpawnDistance;
    //[SerializeField]
    //private int reselution;
    //public float seed;
    [SerializeField]
    private float perlinSpacing;
    [SerializeField]
    private GameObject[] astroidPrefabs;
    [SerializeField]
    private int astroidAmount;
    [SerializeField]
    private bool shouldGenerateAstroidField = true;
    [SerializeField]
    private float minAstroidSize, maxAstroidSize;

    //[HideInInspector]
    public List<GameObject> spawnedAstroids = new List<GameObject>();

    private 
    // Start is called before the first frame update
    void Start()
    {
        //generateAstroidField(minSpawnDistance, maxSpawnDistance, astroidSpawnPosition.position, astroidPrefabs);
        if(minAstroidSize>maxAstroidSize) minAstroidSize = maxAstroidSize;
    }

    //private int mf(float f)
    //{
    //    return (int)Mathf.Floor(f);
    //}
    //private int mc(float f)
    //{
    //    return (int)Mathf.Ceil(f);
    //}
    private int r(float f)
    {
        return (int)math.round(f);
    }

    private float shrinkToFit(float f,float f2)
    {
        return f / (f / f2);
    }

    public bool generateAstroidField(float min, float max, Vector3 spawnPosition, GameObject[] astroidPrefabs)
    {
        //float[,] map = generateAstroidMap();
        //for (int i = 0; i < max; i++)
        //{
        //    for (int j = 0; j < max; j++)
        //    {
        //        int ii = i-(i/2), jj = j-(j/2);
        //        //Debug.Log(ii+" "+jj);
        //        //astroidPrefabs[(int)math.floor(map[i, j] * astroidPrefabs.Length)].Instantiate();
        //        if(ii < max && ii > min && jj < max && jj > min)
        //        {
        //            int getPerlinVal = (int)math.floor(map[i, j] * astroidPrefabs.Length);
        //            Debug.Log("gpv is " + getPerlinVal);
        //            quaternion qu = quaternion.EulerZXY(0, 0, UnityEngine.Random.Range(-180, 180));
        //            Debug.Log("qu is " + qu);
        //            Instantiate(astroidPrefabs[getPerlinVal], new Vector3(ii, jj, 0), qu);
        //            Debug.Log("inst at "+ii+" "+jj);
        //        }
        //        
        //    }
        //}
        for (int i = 0; i < astroidAmount; i++)
        {
            Vector2 pos = new Vector2(UnityEngine.Random.Range(-max, max), UnityEngine.Random.Range(-max, max));
            float dis = math.distance(pos, new Vector2(spawnPosition.x,spawnPosition.y));
            while(dis > max || dis < min)
            {
                pos = new Vector2(UnityEngine.Random.Range(-max, max), UnityEngine.Random.Range(-max, max));
                dis = math.distance(pos, new Vector2(spawnPosition.x, spawnPosition.y));
            }
            quaternion qu = quaternion.EulerZXY(0, 0, UnityEngine.Random.Range(-180, 180));
            float getPerlinValFloat = Mathf.PerlinNoise(pos.x*perlinSpacing,pos.y*perlinSpacing) * (astroidPrefabs.Length-1);
            Debug.Log(getPerlinValFloat);
            int getPerlinVal = r(getPerlinValFloat);
            Debug.Log(getPerlinVal);
            GameObject go = Instantiate(astroidPrefabs[getPerlinVal], pos, qu, astroidSpawnPosition);
            go.transform.localScale = Vector3.one*UnityEngine.Random.Range(minAstroidSize,maxAstroidSize);
            spawnedAstroids.Add(go);
        }
        return true;
    }

    //public float[,] generateAstroidMap()
    //{
    //    float[,] map = new float[reselution, reselution];
    //    for (int i = 0; i < reselution; i++)
    //    {
    //        for (int j = 0; j < reselution; j++)
    //        {
    //            map[i, j] = Mathf.PerlinNoise(i + (seed * 100) * (perlinSpacing+1), j + (seed * 100) * (perlinSpacing+1));
    //        }
    //    }
    //    return map;
    //}

    private Vector2 generateSeededPos(Vector2 pos, float seed)
    {
        float mseed = seed * 100;
        return new Vector2(pos.x * mseed, pos.y * mseed);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldGenerateAstroidField)
        {
            for(int i = 0; i < spawnedAstroids.Count; i++)
            {
                Destroy(spawnedAstroids[i]);
            }
            spawnedAstroids.Clear();
            generateAstroidField(minSpawnDistance, maxSpawnDistance, astroidSpawnPosition.position, astroidPrefabs);
            shouldGenerateAstroidField = false;
        }
    }
}
