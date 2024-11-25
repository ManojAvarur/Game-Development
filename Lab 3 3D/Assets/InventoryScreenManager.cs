using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryCanvas;
    [SerializeField] private Button gameResumeButton;

    //[SerializeField] private RawImage healthInventoryView;
    //[SerializeField] private RawImage bookInventoryView;
    //[SerializeField] private RawImage timeIncreaseInventoryView;
    //[SerializeField] private RawImage timeDecreaseInventoryView;


    [SerializeField] private Button healthInventoryView;
    [SerializeField] private Button bookInventoryView;
    [SerializeField] private Button timeIncreaseInventoryView;
    [SerializeField] private Button timeDecreaseInventoryView;


    //[SerializeField] private GameObject slot1;
    //[SerializeField] private GameObject slot2;
    //[SerializeField] private GameObject slot3;
    //[SerializeField] private GameObject slot4;
    //[SerializeField] private GameObject slot5;

    [SerializeField] private Vector3 slot1 = new Vector3(185, 202, 0);
    [SerializeField] private Vector3 slot2 = new Vector3(420, 202, 0);
    [SerializeField] private Vector3 slot3 = new Vector3(655, 202, 0);
    [SerializeField] private Vector3 slot4 = new Vector3(302, 76, 0);
    [SerializeField] private Vector3 slot5 = new Vector3(537, 76, 0);

    private Vector3[] slots;
    private List<Button> activeButtons;

    void Start()
    {
        gameResumeButton.onClick.AddListener(ResumeGame);
        activeButtons = new List<Button>();
        slots = new Vector3[5]{ slot1, slot2, slot3, slot4, slot5 };
    }

    private void Update()
    {
        if (inventoryCanvas.activeSelf)
        {
            return;
        }

        foreach (Button button in activeButtons)
        {
            DestroyImmediate(button.gameObject);
            DestroyImmediate(button);
        }

        activeButtons.Clear(); 
    }


    public void ShowInventory()
    {
        if (inventoryCanvas == null)
        {
            return;
        }
        
        SetUpInventoryPage();

        inventoryCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void SetUpInventoryPage()
    {
        List<string> inventories = InventoryStore.getInstance().GetAllInventory();

        for (int i = 0; i < inventories.Count; i++)
        {
            string item = inventories[i];

            Button newButton = null;
            Action callBackFun = () => { };

            if (item == "Health")
            {
                newButton = Instantiate(healthInventoryView, inventoryCanvas.transform, false);
                callBackFun = () =>
                {
                    PlayerHealthDataStore.getInstance().increaseHealth();
                };
            }

            if (item == "Time Adder")
            {
                newButton = Instantiate(timeIncreaseInventoryView, inventoryCanvas.transform, false);
                callBackFun = () =>
                {
                    GameTimeStore.getInstance().increaseTime();
                };
            }

            if (item == "Time Reducer")
            {
                newButton = Instantiate(timeDecreaseInventoryView, inventoryCanvas.transform, false);
                callBackFun = () =>
                {
                    GameTimeStore.getInstance().decreaseTime();
                };
            }

            if (item == "Book of Wisdom")
            {
                newButton = Instantiate(bookInventoryView, inventoryCanvas.transform, false);
            }

            newButton.transform.position = slots[i];
            newButton.onClick.AddListener(() => processInvetryItemSelection(callBackFun, newButton));
            newButton.gameObject.SetActive(true);

            activeButtons.Add(newButton);
        }

    }

    private void processInvetryItemSelection(Action cb, Button button)
    {
        if(button.tag == "Book of Wisdom")
        {
            return;
        }

        InventoryStore.getInstance().RemoveAnItemFromInventor(button.tag);
        button.gameObject.SetActive(false);
        cb();
    }

    public bool isInventoryScreenActive()
    {
        return inventoryCanvas.activeSelf;
    }

    public void ResumeGame()
    {
        if(gameResumeButton == null)
        {
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
        inventoryCanvas.SetActive(false);
    }

}
