using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ListSpace;


public class Reader : MonoBehaviour {

	string BaseDir;

	// Use this for initialization
	void Start () {
		BaseDir = System.IO.Path.GetFullPath("Assets");

		Statics.Items = LoadItemList("/Lists/Test.xml");
		Statics.Recipes = LoadCraftingList("/Lists/Test.xml");
		Destroy(this);
	}
	List<ItemList> LoadItemList(string RelFilePath) {
		string TempDir = BaseDir + @RelFilePath;
		//Debug.Log(TempDir);
		List<ItemList> TempList = new List<ItemList> ();
		if(File.Exists(TempDir)) {
			using (XmlTextReader Reader = new XmlTextReader(TempDir)) 
			{
				while (Reader.Read ()){
					if(Reader.NodeType == XmlNodeType.Element && Reader.Name == "Item" && Reader.HasAttributes){
						TempList.Add(
							new ItemList {
								Item = new Item {
									ID = 	Int32.Parse(Reader.GetAttribute("ID")),
									Name = 	Reader.GetAttribute("Name"),
									Mass = 	Int32.Parse(Reader.GetAttribute("Mass")),
									Volume= Int32.Parse(Reader.GetAttribute("Volume"))									
								}
							}
						);
					}
				}
			}
			return TempList;
        }
        else
        {
            Debug.LogError("No File Found At Path");
            return TempList;
        }
	}
	Item FindByID(int ID, List<ItemList> ListToSearch){
		Item Temp = new Item { ID = ID };
		foreach(ItemList Item in ListToSearch){
			if(Item.Item.ID == Temp.ID){
				return Item.Item;
			}
		}
		return Temp;
	}
	List<CraftList> LoadCraftingList(string RelFilePath) {
		string TempDir = BaseDir + @RelFilePath;
		//Debug.Log(TempDir);
		List<CraftList> TempList = new List<CraftList> ();
		if(File.Exists(TempDir)) {
			using (XmlTextReader Reader = new XmlTextReader(TempDir)) 
			{
				while (Reader.Read ()){
					if(Reader.NodeType == XmlNodeType.Element && Reader.Name == "Recipe" && Reader.HasAttributes){
						List<ItemList> CList = new List<ItemList>();
						string [] Hold = Reader.GetAttribute("CraftingIngredients").Split( new Char[] {','});
						for (int i = 0; i < Hold.Length; i+=2)
						{
							CList.Add( new ItemList { Item = FindByID(Int32.Parse(Hold[i]),Statics.Items), Amount = Int32.Parse(Hold[i+1])});
						}



						TempList.Add( 
							new CraftList {
								Recipe = new Recipe {
									CraftingItems = CList,
									ResultingItem = FindByID(Int32.Parse(Reader.GetAttribute("ResultID")),Statics.Items),
									ResultingAmount = Int32.Parse(Reader.GetAttribute("AmountCrafted")),
									CraftingTime = Int32.Parse(Reader.GetAttribute("CraftingTime"))
								}
							}
						);
					}
				}
			}
		}

		
	return TempList;
	}
}