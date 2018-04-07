using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameover = false;

    #region simple singleton
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    public void PlayerDie()
    {
        gameover = true;
        StartCoroutine("ShowScoreBoard");
    }


    IEnumerator ShowScoreBoard()
    {
        yield return new WaitForSeconds(2);
        ScoreManager.Instance.ShowScoreBoard();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    public void HideGuidePanel()
    {
        ScoreManager.Instance.HideGuidePanel();
    }

    
}
