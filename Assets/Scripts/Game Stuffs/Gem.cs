using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public Player player = new Player();
    public GameObject gem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.gemsCollected++;
            gem.SetActive(false);
        }
    }

    public void Restart()
    {
        gem.SetActive(true);
    }
}
