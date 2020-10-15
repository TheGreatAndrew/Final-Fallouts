using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string entrancePW;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerMovement.instance.levelPW == entrancePW)
        {
            //put the player in the new scene
            PlayerMovement.instance.transform.position = transform.position; 
        }
        else
        {
            Debug.Log("Nothing");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
