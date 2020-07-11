using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public bool alive;
    public GameObject player;
    public Canvas canvas;
    public RectTransform dialR, dialP, dialY;

    private void Start() {
        alive = true;
        player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        dialP = GameObject.Find("Canvas/Dial P").GetComponent<RectTransform>();
        dialR = GameObject.Find("Canvas/Dial R").GetComponent<RectTransform>();
        dialY = GameObject.Find("Canvas/Dial Y").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        UpdateUI();
    }

    void UpdateUI() {
        dialR.localRotation = Quaternion.Euler(0, 0, UnityEditor.TransformUtils.GetInspectorRotation(player.transform).z);
        dialP.localRotation = Quaternion.Euler(0, 0, UnityEditor.TransformUtils.GetInspectorRotation(player.transform).x);
        dialY.localRotation = Quaternion.Euler(0, 0, UnityEditor.TransformUtils.GetInspectorRotation(player.transform).y);
    }
}
