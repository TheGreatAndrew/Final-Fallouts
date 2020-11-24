using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item {

	public int healthEffect;
	public int attackEffect;   
    public int defenseEffect;   
	public PlayerInfo playerInfo;

    private void Start() {
        // doesn't work for some reason
        // playerInfo = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInfo>();

    }

 	public override void Use()
	{
		base.Use();

        // add health permanently 
        // but add effects for 1 minutes 
        if(this.healthEffect >= 0){
            playerInfo = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInfo>();
            playerInfo.health += this.healthEffect;
        }
        if(this.attackEffect >= 0 || this.defenseEffect >= 0){
            playerInfo = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerInfo>();
            playerInfo.StartCoroutine(temporaryEffect());
        }

		RemoveFromInventory();					
	}

    IEnumerator temporaryEffect(){
        playerInfo.attack += this.attackEffect;
        playerInfo.defense += this.defenseEffect;
        yield return new WaitForSeconds(60);
        playerInfo.attack -= this.attackEffect;
        playerInfo.defense -= this.defenseEffect;
    }

}
