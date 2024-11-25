using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationDataStore
{
    private static ConversationDataStore _conversationDataStore;
    private List<string> conversationsList;
    //private

    ConversationDataStore()
    {
        this.conversationsList = new List<string>();
    }

    public static ConversationDataStore getInstance()
    {
        if(_conversationDataStore == null)
        {
            _conversationDataStore = new ConversationDataStore();
        }

        return _conversationDataStore;
    }

    public ConversationDataStore addNew(string conversation)
    {
        this.conversationsList.Add(conversation);
        return this;
    }

    public ConversationDataStore addNew(string[] conversations)
    {
        this.conversationsList.AddRange(conversations);
        return this;
    }

    public ConversationDataStore removeAll()
    {
        this.conversationsList.Clear();
        return this;
    }

    
}
