using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;	// Item to put in the inventory on pickup

	// When the player interacts with the item
	public override void Interact()
	{
		base.Interact();

		PickUp();	// Pick it up!
	}

	void PickUp ()
	{
		bool wasPickedUp = Inventory.instance.Add(item);

		// // If successfully picked up
		if (wasPickedUp)
			Destroy(gameObject);	
	}

}