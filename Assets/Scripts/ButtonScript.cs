using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
    public string scene;

    public void GotoSceneSingle() {
        Debug.Log("Single pressed");
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void GoToSceneAddictive() {
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
