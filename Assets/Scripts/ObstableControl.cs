using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstableControl : MonoBehaviour
{

    private float timeDuration = 0.2f;
    private float countDown = 0;
    private bool isEntered = false;

    private Collider lastCollider;
    void Update()
    {
        if (isEntered)
        {
            countDown += Time.deltaTime;
           
            if (countDown >= timeDuration)
            {
                if (lastCollider != null)
                {
                    lastCollider.gameObject.GetComponent<PlayerRunnerController>().PlayerDie();
                }
                GameManager.Instance.PlayerDie();
            }
        }
        


    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            lastCollider = collider;
            countDown = 0;
            isEntered = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            isEntered = false;
            lastCollider = null;
        }
    }
}
