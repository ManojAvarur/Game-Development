using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthCtrl : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        string colliderObjectTagName = other.gameObject.tag;

        if(colliderObjectTagName == "Enemy")
        {
            PlayerHealthDataStore.getInstance().reduceHealth();
        }

        if(colliderObjectTagName == "Health")
        {
            PlayerHealthDataStore.getInstance().increaseHealth();
        }

        RandomObjectSpanner.removeObstacle(other.gameObject);
    }
}
