using UnityEngine;

public class PlayerCollisionCtrl : MonoBehaviour
{
    private GameObject personA;
    private GameObject personB;
    private GameObject player;
    void Start()
    {
        personA = GameObject.Find("Person A");
        personB = GameObject.Find("Person B");
    }
    void OnTriggerEnter(Collider other)
    {
        string colliderObjectTagName = other.gameObject.tag;

        RandomObjectSpanner.removeObstacle(other.gameObject);

        if(colliderObjectTagName == "Enemy")
        {
            PlayerHealthDataStore.getInstance().reduceHealth();
            return;
        }

        InventoryStore.getInstance().AddNew(colliderObjectTagName);
    }
}
