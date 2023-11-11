using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astar_pathfinder : MonoBehaviour
{
    [SerializeField]
    private Transform middle;
    [SerializeField]
    private int colliderRange;
    [SerializeField]
    private GameObject collider;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -colliderRange;  i < colliderRange; i++)
        {
            for (int j = -colliderRange; j < colliderRange; j++)
            {
                Instantiate(collider, new Vector3(middle.position.x + i, middle.position.y + j, 0), transform.rotation, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
