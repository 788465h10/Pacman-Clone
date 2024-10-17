using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerFinal : MonoBehaviour
{
    public PauseMenuFinal pauseMenu;
    public GameoverFinal gameOver;
    public FinalMovement player;

    public Chest[] chests;
    public int[] checkIfOpened = { 0, 0, 0 };

    public TMP_Text currentKey;
    public float keyCounter;

    private void Awake()
    {
        currentKey.text = "0 / 3";
        keyCounter = 0;
    }

    private void Update()
    {
        //check if chest is opened, increase key count
        for(int i = 0; i < chests.Length; i++)
        {
            if (chests[i].isOpened && checkIfOpened[i] == 0)
            {
                checkIfOpened[i] = 1;
                keyCounter++;
                currentKey.text = keyCounter + " / 3";
            }
        }
        //press esc to pause game
        if (Input.GetKeyDown("escape"))
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        //if game over, press space to start new game from lv1
        if (player.IsDestroyed() && Input.GetKeyDown("space"))
        {
            gameOver.gameObject.SetActive(false);
            //if you lose, end game by showing your score but don't save it (update later)
        }
        //if you win, show win scene and save score (update later)
        
    }

}
