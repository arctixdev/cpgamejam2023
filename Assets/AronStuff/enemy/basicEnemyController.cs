using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject astroidDetectionObject;
    [SerializeField]
    private GameObject spawner;

    [SerializeField]
    private float wantedAstroidDistance;
    [SerializeField]
    private float astroidDistanceSlack;
    [SerializeField]
    private float wantedSpawnerDistance;
    [SerializeField]
    private float spawnerDistanceSlack;


    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
