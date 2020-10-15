using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    //level name
    public string levelName;
    [SerializeField] private string newlevelPW;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")

        {
            PlayerMovement.instance.levelPW = newlevelPW;
            //SceneManager.LoadScene(levelName);
            FindObjectOfType<SceneFade>().FadeTo(levelName);
        }
            
    }
}
