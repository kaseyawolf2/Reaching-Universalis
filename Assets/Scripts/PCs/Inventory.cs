﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Item;
public class Inventory : MonoBehaviour {

    #region Initial Statements
    public float MaxVolume;
    public float MaxMass;
    public float AvlMass;
    public float AvlVolume;
    //Inventorys
    public List<ItemList> HeldItems = new List<ItemList> ();
    //Target
    public GameObject TarObj;

    #endregion


    #region Checking
    public bool Check (Item item) { //check if this can hold item
        HoldInfo ();
        if (AvlMass >= item.Mass && AvlVolume >= item.Volume) {
            return true;
        }
        return false;
    }

    public void HoldInfo () {
        float HoldMass = 0;
        float HoldVolume = 0;
        foreach (ItemList Item in HeldItems) {
            HoldMass += Item.Mass;
            HoldVolume += Item.Volume;
        }
        AvlMass = MaxMass - HoldMass;
        AvlVolume = MaxVolume - HoldVolume;
    }


    public void CheckInv () { //list the items in inventory
        Debug.Log ("Number of items in Inventory: " + HeldItems.Count);
        foreach (ItemList c in HeldItems)
            Debug.Log (c);
    }

    public bool CheckforItem (Item item) { //check inventory for item
        foreach (ItemList Item in HeldItems) {
            if (Item.Item == item) {
                return true;
            }
        }
        return false;
    }

    public int GetItemPos (Item item) { //gets the item postion in the inventory list
        if (CheckforItem (item)) {
            int Num = 0;
            foreach (ItemList Item in HeldItems) {                
                if (Item.Item == item) {
                    return Num;
                }
            Num += 1;
            }
        }
        return -1;
    }

    #endregion

    public void AddItem (Item item) {
        HeldItems.Add (Statics.Items[item.ID]);
    }

    public void RemoveItem (Item item) {
        HeldItems.Remove (item.ID);
    }
}
