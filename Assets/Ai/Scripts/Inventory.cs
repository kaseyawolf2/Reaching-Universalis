using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    void Start () {        
    }

    void Update () {

    }


    #region Checking

    public bool Check (int ID) {
        HoldInfo ();
        if (AvlMass >= Statics.Items[ID].Mass && AvlVolume >= Statics.Items[ID].Volume) {
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


    public void CheckInv () {
        Debug.Log ("Number of items in Inventory: " + HeldItems.Count);
        foreach (ItemList c in HeldItems)
            Debug.Log (c);
    }

    public bool CheckforItem (int Id) {
        foreach (ItemList Item in HeldItems) {
            if (Item.ItemID == Id) {
                return true;
            }
        }
        return false;
    }

    public int GetItemPos (int ID) {
        if (CheckforItem (ID)) {
            int Num = 0;
            foreach (ItemList Item in HeldItems) {                
                if (Item.ItemID == ID) {
                    return Num;
                }
                Num += 1;
            }
        }
        return -1;
    }

    #endregion

    public void AddItem (int ID) {
        HeldItems.Add (Statics.Items[ID]);
    }

    public void RemoveItem (int ID) {
        HeldItems.Remove (HeldItems[ID]);
    }

}
