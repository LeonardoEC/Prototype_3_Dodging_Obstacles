using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyer_Ground_Detector : MonoBehaviour
{

    public System.Action<string> onGroundByTag;
    public System.Action onGameOver;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            onGroundByTag?.Invoke("Ground");
        }

        if(other.CompareTag("Obstacle"))
        {
            onGameOver?.Invoke();
        }
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            onGroundByTag?.Invoke("Untagged");
        }
    }
}
