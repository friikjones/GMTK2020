using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetWin : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().win = true;
        }
    }
}