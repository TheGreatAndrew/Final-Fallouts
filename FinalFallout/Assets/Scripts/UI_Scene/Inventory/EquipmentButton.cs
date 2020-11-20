using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour {

	public Image icon;			
	Item item; 

	public void Equip (Item newItem)
	{
		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;
	}

	public void Unequip ()
	{
		item = null;
		icon.sprite = null;
		icon.enabled = false;	
	}

}