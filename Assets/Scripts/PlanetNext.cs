using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNext : MonoBehaviour {
    private void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<GameManagerScript>().next = true;
        }
    }
}
