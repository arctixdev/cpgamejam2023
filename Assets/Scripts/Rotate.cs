using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool randomRotationSpeed;

    [SerializeField]
    private float maxSpeed = 10;


    [SerializeField]
    private float minSpeed = 7;

    private void Start()
    {
        if(randomRotationSpeed)
        {
            speed = Random.Range(minSpeed, maxSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
