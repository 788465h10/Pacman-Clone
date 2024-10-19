using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerFinal : MonoBehaviour
{
    public PauseMenuFinal pauseMenu;
    public GameoverFinal gameOver;
    public FinalMovement player;
    public GameObject keyUI;
    public GameObject door;
    public TMP_Text findDoorNoti;

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
        //check if all chests are opened, open door
        if (keyCounter == 3)
        {
            door.SetActive(true);
            findDoorNoti.gameObject.SetActive(true);
        }
        //press esc to pause game
        if (Input.GetKeyDown("escape"))
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        //game over behavior
        if (player.IsDestroyed())
        {
            keyUI.gameObject.SetActive(false);
            if (Input.GetKeyDown("space"))
            {
                gameOver.gameObject.SetActive(false);
                SceneManager.LoadScene("Pacman");
            }
        }
    }

}
