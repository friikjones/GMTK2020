using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {

    public float gravityForce;

    private void OnTriggerStay(Collider other) {
        if (other.transform.tag == "Player") {
            Vector3 dist = transform.position - other.transform.position;
            other.GetComponent<Rigidbody>().AddForce(dist.normalized * gravityForce);
        }
    }
}