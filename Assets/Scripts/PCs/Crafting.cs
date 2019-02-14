using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ListSpace;

public class Crafting : MonoBehaviour {
	public bool AllowOtherCraft = false;


	bool IsCrafting = false;
	bool CanCraft(Recipe recipe) {
		Inventory Inv = gameObject.GetComponent<Inventory>();
		foreach(ItemList Req in recipe.CraftingItems){
			if(Inv.CheckforItem(Req.Item)){
				if(Req.Amount <= Inv.CheckItemCount(Req.Item)) {
					continue;
				} else {
					Debug.Log("Not Enough : " + Req.Item.Name + " | Need : " + Req.Amount + " | Have : " + Inv.CheckItemCount(Req.Item) + " || Attempting To Craft missing Prereq");
					//findout if pc know how to craft prereq if they do then attempt crafting of item if not return false
					List<CraftList> PreCrafts =  GetRecipesByProduct(Req.Item);
					if( PreCrafts.Count == 0){
						Debug.Log("No Known Prereq Recipes");
					}else{
						foreach (var PreRec in PreCrafts)
						{
							if(CanCraft(PreRec.Recipe)){
								Craft(PreRec.Recipe);
								break;
							}
						}
						continue;
					}
					
					return false;
				}
			} else {
				Debug.Log("Inventory Does Not Contain : " + Req.Item.Name);
					
					List<CraftList> PreCrafts =  GetRecipesByProduct(Req.Item);
					if( PreCrafts.Count == 0){
						Debug.Log("No Known Prereq Recipes");
					}else{
						foreach (var PreRec in PreCrafts)
						{
							if(CanCraft(PreRec.Recipe)){
								await Craft(PreRec.Recipe);
								break;
							}
						}
						continue;
					}

				return false;
			}
		}
		return true;
	}
	public async void Craft(Recipe recipe) {
		if(!CanCraft(recipe) || IsCrafting){ 
			if(IsCrafting){
				Debug.Log("Busy Crafting Already");
			}
			Debug.Log("Can't Craft " + recipe.ResultingItem.Name);			
			return;
		}
		IsCrafting = true;
		foreach(ItemList Comp in recipe.CraftingItems){
			for (int i = 0; i < Comp.Amount; i++)
			{	
				gameObject.GetComponent<Inventory>().RemoveItem(Comp.Item);
			}
		}
		
		await Task.Delay(1000 * recipe.CraftingTime);
		for (int i = 0; i < recipe.ResultingAmount; i++)
		{	
			gameObject.GetComponent<Inventory>().AddItem(recipe.ResultingItem);
		}
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
