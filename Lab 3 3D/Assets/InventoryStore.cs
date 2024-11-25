using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryStore
{
    private static InventoryStore _inventoryStore;
    private List<string> _inventoryArray;

    public static InventoryStore getInstance()
    {
        if(_inventoryStore == null)
        {
            _inventoryStore = new InventoryStore();
        }

        return _inventoryStore;
    }

    InventoryStore()
    {
        this._inventoryArray = new List<string>();
    }

    public InventoryStore AddNew(string gameObjectTag)
    {
        if (this._inventoryArray.Count >= 5) { 
            return _inventoryStore;
        }

        if (gameObjectTag == "Book of Wisdom" && this._inventoryArray.IndexOf(gameObjectTag) >= 0)
        {
            return this;
        }

        this._inventoryArray.Add(gameObjectTag);
        
        return _inventoryStore;
    }

    public List<string> GetAllInventory()
    {
        return this._inventoryArray;
    }

    public InventoryStore RemoveAnItemFromInventor(string gameObjectTag)
    {
        this._inventoryArray.Remove(gameObjectTag);
        return this;
    }

    public InventoryStore ClearAll()
    {
        this._inventoryArray.Clear();
        return this;
    }

    public bool UserHasBookOfWisdom()
    {
        return this._inventoryArray.IndexOf("Book of Wisdom") >= 0;
    }

    public void RemoveBookOfWisdom()
    {
        this._inventoryArray.Remove("Book of Wisdom");
    }
}


