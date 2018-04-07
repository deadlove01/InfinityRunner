using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{

    public float delayTime = 1f;

    public GameObject needToHideGO;
	// Use this for initialization


    void OnTriggerExit(Collider collider)
    {
        print("trigger");
        if (collider.tag == "Player")
        {
            StartCoroutine("HideMe");
        }
    }


    IEnumerator HideMe()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        needToHideGO.SetActive(false);
    }
}
