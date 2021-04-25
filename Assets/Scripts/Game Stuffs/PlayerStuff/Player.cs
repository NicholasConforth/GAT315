using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public int gemsCollected = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="Enemy")
        {
            health--;
        }
    }
}
