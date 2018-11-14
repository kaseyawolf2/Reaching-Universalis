using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ItemSpace;


public class Reader : MonoBehaviour {

	string BaseDir;

	// Use this for initialization
	void Start () {
		BaseDir = System.IO.Path.GetFullPath("Assets");

		Statics.Items = LoadItemList("/Lists/Test.xml");
		foreach(ItemList Item in Statics.Items){
			Debug.Log(Item.ToString());
		}
		


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
						List<ItemList> CList = new List<ItemList>();
						if(Reader.GetAttribute("Crafting") != null){
							string [] Hold = Reader.GetAttribute("Crafting").Split( new Char[] {','});
							for (int i = 0; i < Hold.Length; i+=2)
							{
								CList.Add( new ItemList { Item = new Item {Name = Hold[i]}, Amount = Int32.Parse(Hold[i+1])});
							}
						}
						int CA = 0;
						if(Reader.GetAttribute("Result")!=null){
						 CA = Int32.Parse(Reader.GetAttribute("Result"));
						}
						TempList.Add(
							new ItemList {
								Item = new Item {
									ID = 	TempList.Count,
									Name = 	Reader.GetAttribute("Name"),
									Mass = 	Int32.Parse(Reader.GetAttribute("Mass")),
									Volume =Int32.Parse(Reader.GetAttribute("Volume")),
									CraftingItems = CList,
									CraftingAmount = CA
									
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
	void SaveItemList(string RelSavePath) {
	string TempDir = BaseDir + @RelSavePath;
		List<ItemList> TempList = new List<ItemList> ();
		if(File.Exists(TempDir)) {
			using (XmlTextReader Reader = new XmlTextReader(TempDir)) 
			{
				while (Reader.Read ()){
					Reader.MoveToElement();
					Debug.Log(Reader.Name);
				}
			}
        }
        else
        {
            Debug.LogError("No File Found At Path");
            return;
        }
	}
}