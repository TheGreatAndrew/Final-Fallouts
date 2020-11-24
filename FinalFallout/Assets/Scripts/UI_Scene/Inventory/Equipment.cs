using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;	// Slot to store equipment in, set in editor

	public int armorModifier;		// Increase/decrease in armor
	public int damageModifier;      
    public SkinnedMeshRenderer mesh;
    public EquipmentManager.MeshBlendShape[] coveredMeshRegions;
 	public override void Use()
	{
		base.Use();


		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();					
	}

}

public enum EquipmentSlot { Head, Chest, Weapon, SubWeapon, Feet }