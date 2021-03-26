using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void loadScene(string scene) {
        GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PressButton");

        if (scene == "Level1") GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayScenes("Lvl1Music");
        else if (scene == "Level2") GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayScenes("Lvl2Music");
        else if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2") GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayScenes("MainTheme");

        SceneManager.LoadScene(scene);
    }

    public void ExitTheGame() {
        GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PressButton");
        Application.Quit();
    }
    
}