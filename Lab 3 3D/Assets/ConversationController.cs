using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConversationController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ShowConversationCanvas(string convo)
    {
        textMeshPro.text = convo;
        this.gameObject.SetActive(true);
    }

    public void HideConversationCanvas()
    {
        textMeshPro.text = "";
        this.gameObject.SetActive(false);
    }
}


//public class ConversationController : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI textMeshPro;
//    [SerializeField] private float conversationSpeedSec = 1f;

//    private List<string> conversation;
//    private System.DateTime nextWaitTime;
//    private int currentConvoIndex = 0;
//    private bool conversationCompleted = false;

//    void Start()
//    {
//        conversation = new List<string>();
//        nextWaitTime = System.DateTime.Now;
//    }

//    public void ShowConversationCanvas(string[] convo)
//    {
//        if (this.gameObject.activeSelf)
//        {
//            return;
//        }

//        this.conversation.AddRange(convo);
//        nextWaitTime = System.DateTime.Now;
//        this.currentConvoIndex = 0;
//        this.conversationCompleted = false;
//        this.gameObject.SetActive(true);
//    }

//    public void HideConversationCanvas()
//    {
//        if (!this.gameObject.activeSelf)
//        {
//            return;
//        }

//        this.conversationCompleted = currentConvoIndex >= conversation.Count;
//        currentConvoIndex = 0;
//        this.conversation.Clear();
//        this.gameObject.SetActive(false);
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(this.conversation.Count == 0 || currentConvoIndex >= conversation.Count)
//        {
//            HideConversationCanvas();
//            return;
//        }

//        if (nextWaitTime > System.DateTime.Now)
//        {
//            return;
//        }

//        this.textMeshPro.text = this.conversation[currentConvoIndex];

//        currentConvoIndex++;

//        nextWaitTime = System.DateTime.Now.AddSeconds(conversationSpeedSec);
//    }

//    public bool IsConversationActive()
//    {
//        return this.gameObject.activeSelf;
//    }
//}
