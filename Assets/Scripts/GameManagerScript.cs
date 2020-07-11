using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public bool alive;
    public GameObject player;
    public PlayerController playerController;
    public Canvas canvas;
    public RectTransform dialR, dialP, dialY;
    public RectTransform arrowT, arrowR, arrowP, arrowY;

    private void Start() {
        alive = true;
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        dialP = GameObject.Find("Canvas/Dial P").GetComponent<RectTransform>();
        dialR = GameObject.Find("Canvas/Dial R").GetComponent<RectTransform>();
        dialY = GameObject.Find("Canvas/Dial Y").GetComponent<RectTransform>();
        arrowT = GameObject.Find("Canvas/Throttle/Arrow").GetComponent<RectTransform>();
        arrowR = GameObject.Find("Canvas/Roll/Arrow").GetComponent<RectTransform>();
        arrowP = GameObject.Find("Canvas/Pitch/Arrow").GetComponent<RectTransform>();
        arrowY = GameObject.Find("Canvas/Yaw/Arrow").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        UpdateUI();
    }

    void UpdateUI() {
        dialR.localRotation = Quaternion.Euler(0, 0, player.transform.rotation.eulerAngles.z);
        dialP.localRotation = Quaternion.Euler(0, 0, player.transform.rotation.eulerAngles.x);
        dialY.localRotation = Quaternion.Euler(0, 0, player.transform.rotation.eulerAngles.y);
        arrowT.localScale = new Vector3(1, playerController.resultZ, 1);
        arrowR.localScale = new Vector3(1, playerController.resultRoll, 1);
        arrowP.localScale = new Vector3(1, playerController.resultPitch, 1);
        arrowY.localScale = new Vector3(1, playerController.resultYaw, 1);
    }
}
