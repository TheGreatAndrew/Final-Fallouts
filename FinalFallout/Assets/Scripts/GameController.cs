using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 50;
    public int level = 1;
    [SerializeField] public bool isPaused = false ;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab)){
            openMenu();
        }
    }
    // open menu
    void openMenu(){
        SceneManager.LoadScene (sceneName:"MainMenu");
    }

    // public void ChangeLevel()
    // {
    //     SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCount);
    // }

    // public void RestartLevel()
    // {
    //     SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex));
    // }

    // public void PauseGame()
    // {
    //     isPaused = true;
    //     GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
    // }

}
