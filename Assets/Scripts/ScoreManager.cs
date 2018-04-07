using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text currentPointText;
    public Text curPointText;
    public Text highestPointText;
    public GameObject scorePanel;
    public GameObject guidePanel;
    private int currentPoint=0;
    private int highestPoint=0;
    #region simple singleton
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Use this for initialization
    void Start ()
    {
        highestPoint = PlayerPrefs.GetInt("Highest");
    }


    public void AddPoint(int point = 1)
    {
        currentPoint++;
        currentPointText.text = currentPoint.ToString();
        if (currentPoint > highestPoint)
        {
            PlayerPrefs.SetInt("Highest", currentPoint);
            PlayerPrefs.Save();
        }
    }

    public void ShowScoreBoard()
    {
        scorePanel.SetActive(true);
        curPointText.text = currentPoint.ToString();
        highestPointText.text = highestPoint.ToString();
    }

    public void HideGuidePanel()
    {
        guidePanel.SetActive(false);
    }
}
