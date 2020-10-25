using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Uses animation curves to customize battle chances based on biomes over times the player has moved
 * 
 * Essentially you customize your curve to be however you want, and when evaluated at "lookAt" it will tell
 * you the value of the curve at that time. So the Overworld has a slow increase until the end where it spikes up.
 * Comare this value to a random generated number to see if it's lower and you have a random encounter generator
 * 
 */
public class RandomEncounter : MonoBehaviour
{
    //Random Encounter Variables
    public AnimationCurve OverworldCurve; //TODO make curves for each type of biome

    private float lookAt = 0f;
    [SerializeField] private float offset = 0.0025f; //I like 0.001 but 25 is a good number for debugging 
    private float encounterChance;
    private float encounterThreshold;

    
    void Start()
    {
        //TODO probably need to get player info or at least biome location player is currently in
    }

    //Check if an encounter has taken place
    public void isEncounter()
    {
        //TODO check which biome player is in to see what curve to use

        encounterChance = Random.Range(0f, 1f);
        
        encounterThreshold = OverworldCurve.Evaluate(lookAt); //This is where biome comes into play
        
        if (encounterChance <= encounterThreshold)
        {
            Debug.Log("~~~~~BATTLE~~~~~");
            SceneManager.LoadScene("SimpleBattle");
            lookAt = 0f;
        }
        else
        {
            lookAt += offset;
        }
    }
}
