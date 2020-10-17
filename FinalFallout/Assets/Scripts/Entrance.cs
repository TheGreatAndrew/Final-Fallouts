using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(Input.GetKey(KeyCode.Tab)){
            openMenu();
        }
        
    }

    void openMenu(){
        PlayerPrefs.SetInt("PreviousScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene (sceneName:"MainMenu");
    }
}
