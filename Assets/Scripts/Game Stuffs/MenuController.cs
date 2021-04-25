using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public AudioSource audioSource = new AudioSource();
    public Player player = new Player();
    public GameObject playerPos;
    public GameObject mainMenu;
    public GameObject gameOver;
    public GameObject win;
    public TMP_Text gem;
    public TMP_Text health;
    Vector2 playerStartPos = new Vector2(-9.5f, -.8f);
    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOver.SetActive(false);
        win.SetActive(false);
        audioSource.Play();
    }

    public void Update()
    {
        gem.SetText("Gems Colleced: " + player.gemsCollected + "/4");
        health.SetText("Hits Left: " + player.health + "/3");
        if(player.health <= 0)
        {
            gameOver.SetActive(true);
            audioSource.Pause();
        }
        if (mainMenu.active == false && player.health > 0 && player.gemsCollected == 4)
        {
            win.SetActive(true);
            audioSource.Pause();
        }
    }

    public void GoBackToMenu()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        win.SetActive(false);
        audioSource.Pause();
        player.health = 3;
        playerPos.transform.position = playerStartPos;
    }
}
