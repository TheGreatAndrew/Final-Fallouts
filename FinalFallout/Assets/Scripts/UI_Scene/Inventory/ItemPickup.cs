using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;

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