using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;	
	public GameObject inventoryUI;	
	public GameObject playerStatsUI; // FOR MENU quick fix 
	private PlayerInfo player;
    private bool inPlayerMenu = false;

	Inventory inventory;
 
	InventorySlot[] slots;	

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
	}

    public void Init(){
        inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;	

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
	
	void Update () {
		if (Input.GetButtonDown("Inventory"))
        {
            if (inPlayerMenu)
            {
                playerStatsUI.SetActive(false);
				inventoryUI.SetActive(false);
                inPlayerMenu = false;
                player.GetComponent<PlayerMovement>().enabled = true;
            }
            else
            {
                playerStatsUI.SetActive(true);
				inventoryUI.SetActive(true);
                inPlayerMenu = true;
                player.GetComponent<PlayerMovement>().StopPlayer();
                player.GetComponent<PlayerMovement>().enabled = false;
			}
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
