using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Movement
    private Rigidbody rb;
    private float inputPitch, inputYaw, inputRoll, inputZ;
    private float resultPitch, resultYaw, resultRoll, resultZ;
    public float[] enabledControls;
    public float[] overrideControls;
    public float moveSpeed;
    public float rotateSpeed;
    public float maxSpeed;
    public float maxRotSpeed;

    //Air
    public float airGauge;
    public float airLossPerSecond;

    //Misc
    private GameManagerScript gmScript;

    void Start() {
        rb = GetComponent<Rigidbody>();
        // Pitch, Roll, Yaw, Throttle
        enabledControls = new float[4] { 1f, 1f, 1f, 1f };
        overrideControls = new float[4] { 0f, 0f, 0f, 0f };
        rb.velocity = Vector3.zero;
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void FixedUpdate() {
        UpdateInputs();
        UpdateStatus();
    }

    void UpdateInputs() {
        inputPitch = Input.GetAxis("Pitch");
        inputRoll = Input.GetAxis("Roll");
        inputYaw = Input.GetAxis("Yaw");
        inputZ = Input.GetAxis("Throttle");

        //Inputed rotations
        if (rb.angularVelocity.magnitude < maxRotSpeed) {
            resultPitch = inputPitch * enabledControls[0] + overrideControls[0];
            resultYaw = inputYaw * enabledControls[1] + overrideControls[1];
            resultRoll = inputRoll * enabledControls[2] + overrideControls[2];
            Vector3 torque = new Vector3(resultPitch, resultYaw, resultRoll);
            rb.AddRelativeTorque(torque * rotateSpeed, ForceMode.VelocityChange);
        }

        if (rb.velocity.magnitude < maxSpeed) {
            //Inputed Velocities
            resultZ = inputZ * enabledControls[3] + overrideControls[3];
            Vector3 force = new Vector3(0, 0, resultZ);
            rb.AddRelativeForce(force * moveSpeed, ForceMode.VelocityChange);
        }
    }

    void UpdateStatus() {
        airGauge -= airLossPerSecond / 50;
        if (airGauge < 0) {
            gmScript.alive = false;
        }
    }

    public void ResetValues() {
        enabledControls = new float[4] { 1f, 1f, 1f, 1f };
        overrideControls = new float[4] { 0, 0, 0, 0 };
    }
}
