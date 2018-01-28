using UnityEngine;
using UnityEngine.UI;

// Based on code from Unity's Adventure Game tutorial.
// https://unity3d.com/learn/tutorials/projects/adventure-game-tutorial

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public const int numItemSlots = 4;

    private float money;
    public const float winMoney = 1.5f;

    public void AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    public Item ContainsAddress(string address)
    {
        foreach (Item i in items)
        {
            if (i != null && i.address == address)
            {
                return i;
            }
        }

        return null;
    }

    public void AddMoney(float moneyAdded)
    {
        money += moneyAdded;
        GameObject.Find("MoneyUI").GetComponentInChildren<Text>().text = "$" + money.ToString("0.00");
        if(this.money >= winMoney)
        {
            GameObject.Find("MoneyUI").GetComponentInChildren<Text>().color = new Color(0, 255, 0);
        }
    }

    public void RemoveMoney(float moneyRemoved)
    {
        money -= moneyRemoved;
        GameObject.Find("MoneyUI").GetComponentInChildren<Text>().text = "$" + money.ToString("0.00");
        if (this.money >= winMoney)
        {
            GameObject.Find("MoneyUI").GetComponentInChildren<Text>().color = new Color(0, 255, 0);
        } else
        {
            GameObject.Find("MoneyUI").GetComponentInChildren<Text>().color = new Color(0, 0, 0);
        }
    }

    public float GetMoney()
    {
        return money;
    }

    public int GetNumberOfItems()
    {
        int numItems = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                numItems++;
            }
        }
        return numItems;
    }
}