using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFieldScript : MonoBehaviour {

    private GameObject player;
    private PlayerController playerController;
    private int disableTick;

    public float changeTimerInSeconds;
    public bool active;
    public int disableTarget;


    private void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            player = other.gameObject;
            playerController = player.GetComponent<PlayerController>();
            active = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log(other.transform.tag);
        //TODO Fix this crap
        if (other.transform.tag == "Player") {
            playerController.ResetValues();
        }
    }

    private void FixedUpdate() {
        if (active) {
            disableTick++;
            //Start the process
            if (disableTick == 1) {
                disableTarget = Random.Range(0, 4);
            }
            //Execute disabling
            playerController.enabledControls[disableTarget] = 0f;
            if (disableTarget == 3) {
                playerController.overrideControls[3] = 1f;
            }
            //Change disabling over time
            if (disableTick > (changeTimerInSeconds * 50)) {
                disableTick = 0;
                playerController.ResetValues();
            }
        }
    }

}
