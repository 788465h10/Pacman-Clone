using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWinBg : MonoBehaviour
{
    public GameWinFinal gameWin;
    private void OnEnable()
    {
        gameWin.Setup(GameManager.currentScores);
    }
}
