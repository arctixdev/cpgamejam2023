using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class damageHandler : MonoBehaviour
{

    [SerializeField]
    private healthHandler healthHandler;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void takeDamage(float damage)
    {
        healthHandler.damage(damage);
    }
}
