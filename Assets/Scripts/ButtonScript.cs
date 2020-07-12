using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
    public string scene;
    public string nextLevel;

    private void Start() {
        nextLevel = PlayerPrefs.GetString("Level", "Level1");
    }

    public void GotoSceneSingle() {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void GoToSceneAddictive() {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
    public void QuitGame() {
        Application.Quit();
    }
    public void NextScene() {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}
