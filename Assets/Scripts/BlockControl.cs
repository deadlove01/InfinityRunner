using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{

    public bool ignoreMe = false;
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if(!ignoreMe)
                ScoreManager.Instance.AddPoint();
        }
    }
}
