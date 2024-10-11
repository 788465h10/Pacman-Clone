using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerFinal : MonoBehaviour
{
    public PauseMenuFinal pauseMenu;
    public GameoverFinal gameOver;
    public FinalMovement player;

    private void Update()
    {
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
