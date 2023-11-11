using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerControllerTest : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float turnSpeed;
    [SerializeField]
    private float maxTurnSpeed;
    [SerializeField]
    private float flySpeed;
    [SerializeField]
    private float maxFlyingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if (!rb) rb = GetComponent<Rigidbody2D>();
        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(turnSpeed);
            if(rb.angularVelocity > maxTurnSpeed) rb.angularVelocity -= (math.abs(rb.angularVelocity) - math.abs(maxTurnSpeed)) / 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(-turnSpeed);
            if (rb.angularVelocity < -maxTurnSpeed) rb.angularVelocity += (math.abs(rb.angularVelocity) - math.abs(maxTurnSpeed)) / 2;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up*flySpeed);
            if (rb.velocity.y > maxFlyingSpeed) rb.velocity -= new Vector2(0, (math.abs(rb.velocity.y) - maxFlyingSpeed) / 2);
        }
    }
}
