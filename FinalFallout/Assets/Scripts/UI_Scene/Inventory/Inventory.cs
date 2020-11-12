﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO : reward after battle
// TODO : vendor to buy from
// TODO : DonDestroyOnLoad still create multiple instance of EquipmentManager and Inventory

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	public InventoryUI inventoryUI;
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
		inventoryUI.Init();
	}

	#endregion

	// Callback which is triggered when
	// an item gets added/removed.
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;	// Amount of slots in inventory

	public List<Item> items = new List<Item>();

	// Add a new item. Check if there is enough room 
	public bool Add(Item item)
	{
		Debug.Log("Add Item : " + item.name);
		// Don't do anything if it's a default item
		if (!item.isDefaultItem)
		{
			// Check if out of space
			if (items.Count >= space)
			{
				Debug.Log("Not enough room.");
				return false;
			}

			items.Add(item);

			// Trigger callback
			if (onItemChangedCallback != null){
				onItemChangedCallback.Invoke();
			}
			else { 
			}
		}

		return true;
	}

	// Remove an item
	public void Remove (Item item)
	{
		items.Remove(item);		

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}