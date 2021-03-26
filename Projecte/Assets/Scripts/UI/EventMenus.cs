using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMenus : MonoBehaviour {
    public GameObject gameOverMenu, winMenu;
    public static bool GameIsOver = false;

    public void Win() {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
    }

    public void Pause() {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
    }

    public void loadScene(string scene) {
        Time.timeScale = 1f;
        GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PressButton");

        if (scene == "Level1") GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayScenes("Lvl1Music");
        else if (scene == "Level2") GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayScenes("Lvl2Music");
        else if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2") GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlayScenes("MainTheme");

        SceneManager.LoadScene(scene);
    }
    
    public void QuitGame() {
        GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PressButton");
        Application.Quit();
    }
    
}
