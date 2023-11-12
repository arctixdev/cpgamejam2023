using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{

    public bool hasCollided = false;
    private int hasCollidedCount = 0;
    astar_pathfinder ins;

    private void Start()
    {
        ins = astar_pathfinder.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasCollidedCount++;
        if (hasCollidedCount > 0)
        {
            hasCollided = true;
            int lx = (int)transform.position.x, ly = (int)transform.position.y;
            ins.hits[lx + ins.colliderRange, ly + ins.colliderRange] = hasCollided;
        }
        //ins.updateNextTime();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasCollidedCount--;
        if (hasCollidedCount < 1)
        {
            hasCollided = false;
            int lx = (int)transform.position.x, ly = (int)transform.position.y;
            ins.hits[lx + ins.colliderRange, ly + ins.colliderRange] = hasCollided;
        }
        //ins.updateNextTime();
    }
}