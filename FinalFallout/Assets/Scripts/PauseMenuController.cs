using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        if(Input.GetKey(KeyCode.Tab)){
            goPreviousScene();
        }
    }

    // TODO : save previous scene somewhere in order to exactly return to it later
    // return to previous scene
    void goPreviousScene(){
        SceneManager.LoadScene (sceneName:"FirstLevel");
    }

    public void resumeGame(){
        goPreviousScene();
    }

    public void optionsGame(){
        // TODO 
    }

    public void exitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
