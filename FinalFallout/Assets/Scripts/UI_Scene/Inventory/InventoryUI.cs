using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;	
	public GameObject inventoryUI;	
	public GameObject playerStatsUI; // FOR MENU quick fix 

	Inventory inventory;
 
	InventorySlot[] slots;	

	void Start () {
	}

    public void Init(){
        inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;	

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
	
	void Update () {
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
			playerStatsUI.SetActive(!playerStatsUI.activeSelf);
		}
	}

	// This is called using a delegate on the Inventory.
	void UpdateUI ()
	{
 		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)	// If there is an item to add
			{
				slots[i].AddItem(inventory.items[i]);
			} else
			{
				slots[i].ClearSlot();
			}
		}
	}
}
