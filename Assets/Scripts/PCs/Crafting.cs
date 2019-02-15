using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListSpace;

public class Crafting : MonoBehaviour {
	public bool AllowOtherCraft = false;
	List<CraftList> CraftingOrder = new List<CraftList>();
	
	bool IsCrafting = false;
	List<ItemList> CanCraft(Recipe recipe) {
		Inventory Inv = gameObject.GetComponent<Inventory>();
		List<ItemList> NeededItems = new List<ItemList>();

		foreach(ItemList Req in recipe.CraftingItems){
			if(Inv.CheckforItem(Req.Item)){
				if(Req.Amount <= Inv.CheckItemCount(Req.Item)) {
					continue;
				} else {
					//Debug.Log("Not Enough : " + Req.Item.Name + " | Need : " + Req.Amount + " | Have : " + Inv.CheckItemCount(Req.Item));					
					NeededItems.Add( new ItemList { Item = Req.Item, Amount = (Req.Amount - Inv.CheckItemCount(Req.Item)) } );
				}
			} else {
				//Debug.Log("Inventory Does Not Contain : " + Req.Item.Name);
				NeededItems.Add( new ItemList { Item = Req.Item, Amount = Req.Amount } );
			}
		}

		return NeededItems;
	}

	public async Task Craft(Recipe recipe) {

		Inventory Inv = gameObject.GetComponent<Inventory>();
		List<ItemList> NeededItems = CanCraft(recipe);
		//Check if you can craft recipe or if your already crafting
		//foreach needed item check if you have it
		Debug.Log("Starting || " + recipe.ResultingItem.Name);
		//if nothing needed then skip prereq crafting
		if(NeededItems.Count != 0){
			//foreach needed prereq
			foreach (var item in NeededItems) {
				//find prereq recipe
				List<CraftList> PreCrafts =  GetRecipesByProduct(item.Item);
				//if no prereq recipe is known then exit completely
				if( PreCrafts.Count == 0){
					Debug.LogWarning("Cant Craft || Missing Prereq | No Known Prereq Recipe");
					return;
				} else {//pc knows at least one prereq recipe
					Debug.Log("Start PreReq | " + item.Item.Name);
					foreach (var PreRec in PreCrafts) {
						int neededamount = item.Amount;
						//for needed items that are not consumed
						if(item.Amount==0){
							await Craft(PreRec.Recipe);
						}

						//foreach known prereq recipe
						for (int i = 0; i < neededamount; i++) {
							Debug.Log("Attempting Craft || " + PreRec.Recipe.ResultingItem.Name + " | #" + ((i+1)*PreRec.Recipe.ResultingAmount) + "/" + neededamount);
							await Craft(PreRec.Recipe);
							item.Amount=item.Amount-PreRec.Recipe.ResultingAmount;
							//if all needed prereqs are done break out
							if(item.Amount<=0){
								break;
							}					
						}
					}
				}
			}

			if(CanCraft(recipe).Count != 0){
				Debug.LogWarning("Cant Craft || " + recipe.ResultingItem.Name + " || Unknown Reason");				
				return;
			}
		}

		IsCrafting = true;
		Debug.Log("Crafting || " + recipe.ResultingItem.Name);
		foreach(ItemList Comp in recipe.CraftingItems){
			for (int i = 0; i < Comp.Amount; i++)
			{	
				Inv.RemoveItem(Comp.Item);
			}
		}
		
		await Task.Delay(1000 * recipe.CraftingTime);
		for (int i = 0; i < recipe.ResultingAmount; i++)
		{	
			Inv.AddItem(recipe.ResultingItem);
		}
		Debug.Log("Finished || " + recipe.ResultingItem.Name);
		IsCrafting = false;
	}

	public List<CraftList> GetRecipesByProduct(Item Product) {
		List<CraftList> ProductRecipes = new List<CraftList>();
		foreach (var item in gameObject.GetComponent<Attributes>().KnownCraftRes )
		{	
			if(item.Recipe.ResultingItem == Product){
				ProductRecipes.Add(item);
			}				
		}
		return ProductRecipes;
	}
}
