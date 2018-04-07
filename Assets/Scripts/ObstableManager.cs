using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstableManager : MonoBehaviour
{
    
    public float respawnPercent = 30f;
    public float minDistanceFromLastObstacle = 5f;
    public float distanceFromPlayer = 20f;
    public string[] obstacleTags;

    public float minX = -2.5f;
    public float maxX = 2.5f;
    private System.Random rand = new System.Random(DateTime.Now.Millisecond);

    #region simple singleton
    public static ObstableManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion


    public void Respawn(Vector3 targetPosition)
    {
        if (obstacleTags == null || obstacleTags.Length == 0)
        {
            Debug.LogError("You need to declare obstable tag names!");
            return;
        }

        var tagName = obstacleTags[rand.Next(0, obstacleTags.Length)];
     
        print("obstacle tag name: " + tagName);
        var percent = rand.Next(0, 10);
        print("percent: "+percent);
        if (tagName == "Obstacle1")
        {
            if (percent < 9)
            {
                float x = 0;
                var percentX = rand.Next(0, 3);
                if (percentX == 0)
                    x = minX;
                else if (percentX == 1)
                    x = 0;
                else if (percentX == 2)
                    x = maxX;
                ObjectPool.Instance.SpawnFromPool(tagName, new Vector3(x, 0, targetPosition.z), Quaternion.identity);
            }
        }
        else if (tagName == "Obstacle2")
        {
            if (percent < 6)
            {
                float x = 0;
                var percentX = rand.Next(0, 2);
                if (percentX == 0)
                    x = minX;
                else if (percentX == 1)
                    x = maxX;
                ObjectPool.Instance.SpawnFromPool(tagName, new Vector3(x, 0, targetPosition.z), Quaternion.identity);
            }
        }
        else if (tagName == "Obstacle3")
        {
            if (percent < 4)
            {
                ObjectPool.Instance.SpawnFromPool(tagName, new Vector3(0, 0, targetPosition.z), Quaternion.identity);
            }
            
        }
      

        //
    }

}
