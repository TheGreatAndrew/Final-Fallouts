using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton

    public enum MeshBlendShape {Torso, Arms, Legs };
    public Equipment[] defaultEquipment;

	public static EquipmentManager instance;
	public SkinnedMeshRenderer targetMesh;

    SkinnedMeshRenderer[] currentMeshes;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of EquipmentManager found!");
			return;
		}

		instance = this;
	}

	#endregion

	public Equipment[] currentEquipment;  
	public EquipmentButton headButton;
	public EquipmentButton chestButton;
	public EquipmentButton weaponButton;
	public EquipmentButton shieldButton;
	public EquipmentButton feetButton;
	public PlayerInfo playerInfo;


	// Callback for when an item is equipped/unequipped
	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;
   

	Inventory inventory;	

	void Start ()
	{
		inventory = Inventory.instance;	
		playerInfo = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInfo>();

		int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
        // currentMeshes = new SkinnedMeshRenderer[numSlots];
        EquipDefaults();
		
	}

	// Equip a new item
	public void Equip (Equipment newItem)
	{
		int slotIndex = (int)newItem.equipSlot;

		// check if slot already have item or null
        Equipment oldItem = Unequip(slotIndex);

		if (onEquipmentChanged != null)
		{
			onEquipmentChanged.Invoke(newItem, oldItem);
		}

		currentEquipment[slotIndex] = newItem;


		Debug.Log("AAA" + headButton);
		// equip weapon
		if(slotIndex == 0)
			headButton.Equip(newItem);
		if(slotIndex == 1)
			chestButton.Equip(newItem);
		if(slotIndex == 2)
			weaponButton.Equip(newItem);
		if(slotIndex == 3)
			shieldButton.Equip(newItem);
		if(slotIndex == 4)
			feetButton.Equip(newItem);
		playerInfo.armor += newItem.armorModifier;
		playerInfo.weaponDmg += newItem.damageModifier;

        // AttachToMesh(newItem, slotIndex);
	}

	// Cause Unity onClick don't show up
	public void UnequipHelper(int slotIndex){
		Unequip(slotIndex);
	}

	// Unequip an item with a particular index
	public Equipment Unequip (int slotIndex)
	{


        Equipment oldItem = null;
		if (currentEquipment[slotIndex] != null)
		{
			// for menu
			if(slotIndex == 0)
				headButton.Unequip();
			if(slotIndex == 1)
				chestButton.Unequip();
			if(slotIndex == 2)
				weaponButton.Unequip();
			if(slotIndex == 3)
				shieldButton.Unequip();
			if(slotIndex == 4)
				feetButton.Unequip();
			playerInfo.armor -= currentEquipment[slotIndex].armorModifier;
			playerInfo.weaponDmg -= currentEquipment[slotIndex].damageModifier;

		
			// Add the item to the inventory
			oldItem = currentEquipment[slotIndex];
			inventory.Add(oldItem);

            SetBlendShapeWeight(oldItem, 0);

            // Destroy the mesh
            // if (currentMeshes[slotIndex] != null)
            // {
            //     Destroy(currentMeshes[slotIndex].gameObject);
            // }

			currentEquipment[slotIndex] = null;

			if (onEquipmentChanged != null)
			{
				onEquipmentChanged.Invoke(null, oldItem);
			}
		}

        return oldItem;
	}

	// Unequip all items
	public void UnequipAll ()
	{
		for (int i = 0; i < currentEquipment.Length; i++)
		{
			Unequip(i);
		}

        EquipDefaults();
	}

    void AttachToMesh(Equipment item, int slotIndex)
	{

        SkinnedMeshRenderer newMesh = Instantiate(item.mesh) as SkinnedMeshRenderer;
        newMesh.transform.parent = targetMesh.transform.parent;

        newMesh.rootBone = targetMesh.rootBone;
		newMesh.bones = targetMesh.bones;
		
		// currentMeshes[slotIndex] = newMesh;


        SetBlendShapeWeight(item, 100);
       
	}

    void SetBlendShapeWeight(Equipment item, int weight)
    {
		foreach (MeshBlendShape blendshape in item.coveredMeshRegions)
		{
			int shapeIndex = (int)blendshape;
            targetMesh.SetBlendShapeWeight(shapeIndex, weight);
		}
    }

    void EquipDefaults()
    {
		foreach (Equipment e in defaultEquipment)
		{
			Equip(e);
		}
    }

}