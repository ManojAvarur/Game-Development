using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConversationController : MonoBehaviour
{
    [SerializeField] private ConversationController conversationController;
    [SerializeField] private GameObject playerController;
    [SerializeField] private float conversationSpeedSec = 3f;

    [Header("Interaction Settings")]
    [SerializeField] private GameObject personA;
    [SerializeField] private GameObject personB;
    [SerializeField] private float minConvoDistance = 2f;

    //Person A Conversation Details
    private bool conversationStarted = false;
    private Queue<string> convoArr = new Queue<string>();
    private System.DateTime nextWaitTime;
    private char currentProcessingPerson = '\0';


    void Update()
    {
        float personADistance = Vector3.Distance(personA.transform.position, playerController.transform.position);
        float personBDistance = Vector3.Distance(personB.transform.position, playerController.transform.position);

        if (conversationStarted)
        {
            if ((personADistance > minConvoDistance) && (personBDistance > minConvoDistance))
            {
                conversationStarted = false;
                conversationController.HideConversationCanvas();
                return;
            }

            displayConvo();
        }

        if (personADistance <= minConvoDistance && !conversationStarted)
        {
            conversationStarted = true;
            PersonAConvo();
            return;
        }

        if (personBDistance <= minConvoDistance && !conversationStarted)
        {
            conversationStarted = true;
            PersonBConvo();
            return;
        }
    }

    private void displayConvo()
    {
        if (nextWaitTime > System.DateTime.Now)
        {
            return;
        }

        nextWaitTime = System.DateTime.Now.AddSeconds(conversationSpeedSec);

        if (currentProcessingPerson.Equals('A'))
        {
            ProcessPersonAConvo();
            return;
        }

        ProcessPersonBConvo();
    }

    private void ProcessPersonAConvo()
    {
        if (convoArr.Count <= 0)
        {
            return;
        }

        conversationController.ShowConversationCanvas(convoArr.Dequeue());
    }

    private void ProcessPersonBConvo()
    {
        if (convoArr.Count <= 0)
        {
            InventoryStore.getInstance().RemoveBookOfWisdom();
            return;
        }

        conversationController.ShowConversationCanvas(convoArr.Dequeue());
    }

    private void PersonAConvo()
    {
        currentProcessingPerson = 'A';
        nextWaitTime = System.DateTime.Now;
        convoArr.Clear();
        convoArr.Enqueue("Person: Hello Manoj, Welcome to the world! Hope you enjoy it...");
        
    }   

    private void PersonBConvo()
    {
        currentProcessingPerson = 'B';
        nextWaitTime = System.DateTime.Now;
        convoArr.Clear();
        
        if (InventoryStore.getInstance().UserHasBookOfWisdom())
        {
            convoArr.Enqueue("Person: Hello! You have the book in your possession, right?");
            convoArr.Enqueue("Manoj: Yes..");
            convoArr.Enqueue("Person: Could you please hand over the 'Book of Wisdom'?");
            convoArr.Enqueue("Manoj: Sure.");
            convoArr.Enqueue("Person: Thank you.");
            return;
        }

        convoArr.Enqueue("Person: Hello! You do not have the book in your possession, right?");
        convoArr.Enqueue("Manoj: Yes..");
        convoArr.Enqueue("Person: Go and find the 'Book of Wisdom'");
        convoArr.Enqueue("Manoj: Sure.");
    }
}




//public class PlayerConversationController : MonoBehaviour
//{
//    [SerializeField] private ConversationController conversationController;
//    [SerializeField] private GameObject playerController;

//    [Header("Interaction Settings")]
//    [SerializeField] private GameObject personA;
//    [SerializeField] private GameObject personB;
//    [SerializeField] private float minConvoDistance = 2f;

//    private bool conversationCompleted = false;
//    void Setup()
//    {
//        //playerController = this.gameObject;
//    }


//    void Update()
//    {
//        float personADistance = Vector3.Distance(personA.transform.position, playerController.transform.position);
//        if (personADistance <= minConvoDistance)
//        {
//            PersonAConvo();
//            return;
//        }

//        float personBDistance = Vector3.Distance(personB.transform.position, playerController.transform.position);
//        if (personBDistance <= minConvoDistance)
//        {
//            PersonBConvo();
//            return;
//        }

//        //conversationCompleted = false;
//        conversationController.HideConversationCanvas();
//    }

//    private void PersonAConvo()
//    {
//        if (conversationCompleted)
//        {
//            //return;
//        }

//        conversationCompleted = true;
//        string[] strArr = new string[1] { "Hi, Baron - Anirudh - Rakshil" };
//        conversationController.ShowConversationCanvas(strArr);
//    }

//    private void PersonBConvo()
//    {
//        //conversationController.ShowConversationCanvas();    
//    }
//}


