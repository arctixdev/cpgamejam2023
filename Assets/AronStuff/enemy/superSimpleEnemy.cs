using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superSimpleEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateTowards();
        RaycastHit2D hit = hit = Physics2D.Linecast(transform.position, player.transform.position);
        if (hit.transform.gameObject.name == player.name)
        {
            transform.Translate(Vector3.right * speed);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, new Vector2(0, 1), 2);
            if(!hit.collider)
            {
                transform.Translate(Vector3.up * speed);
            }
            else
            {
                hit = Physics2D.Raycast(transform.position, new Vector2(0,-1), 2);
                if (!hit.collider)
                {
                    transform.Translate(Vector3.down * speed);
                }
                else
                {
                    hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), 2);
                    if (!hit.collider)
                    {
                        transform.Translate(Vector3.right * speed);
                    }
                }
            }
        }
    }

    protected void rotateTowards()
    {
        Vector3 targetPosition = player.transform.position;

        Vector3 lookDirection = targetPosition - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
