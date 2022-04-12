using System.Collections.Generic;
using ListSpace;
using UnityEngine;


public static class Statics {
	
	static public bool ShowMouse = false;
    static public bool Debug = false;
	static public bool ImportFinished;

	static public int Seed;
    static public int Nodes = 0;

	static public List<ItemList> Items = new List<ItemList> ();
	static public List<CraftList> Recipes = new List<CraftList> ();

	//Keybinds
	static public KeyCode KbInv = KeyCode.I;
	static public KeyCode KbCraft = KeyCode.U;
	static public KeyCode KbJump = KeyCode.Space;
	static public KeyCode KbInteract = KeyCode.E;


}