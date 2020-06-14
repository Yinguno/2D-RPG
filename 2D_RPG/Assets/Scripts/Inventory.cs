using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    int capacity;
    Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    public bool AddItem(Item itemAdded)
    {
        if (!inventory.ContainsKey(itemAdded))
        {
            inventory.Add(itemAdded, 0);
        }
        inventory[itemAdded] += 1;
        int i = inventory.Count;

        string log = "";
        log += itemAdded + " is added. " + "\n current item in inventory is:\n";
        foreach (var item in inventory)
        {
            log += "\n" + item.Key + " : " + item.Value + "\n";
        }
        Debug.Log(log);
        return true;
    }
}
