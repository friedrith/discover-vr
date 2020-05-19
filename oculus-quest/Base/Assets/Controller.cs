using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Appears in the Inspector view from where you can set the speed
    public float speed;

    // Rigidbody variable to hold the player ball's rigidbody instance
    private Rigidbody rigibody;

    private bool isMoving = false; 
    private Vector3 initialPosition; 
    private Quaternion initialRotation;

    // Start is called before the first frame update
    void Start()
    {
         // Assigns the player ball's rigidbody instance to the variable
        rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();

        // The float variables, moveHorizontal and moveVertical, holds the value of the virtual axes, X and Z.

        // It records input from the keyboard.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float acceleration = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f ? 2f : 1f;

        float decceleration = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f ? 0f : 1f; 


        // Vector3 variable, movement, holds 3D positions of the player ball in form of X, Y, and Z axes in the space.
        Vector3 movement = new Vector3(moveHorizontal, 0 , moveVertical);

        // Adds force to the player ball to move around.
        rigibody.AddForce(movement * speed * acceleration * decceleration * Time.deltaTime);

        // https://developer.oculus.com/documentation/unity/unity-ovrinput/

        if (OVRInput.Get(OVRInput.Button.Three)) {
            GameObject ball = GameObject.Find("Ball");
            ball.transform.position = ball.transform.position + new Vector3(0.2f, 0, 0);
        }

        if (OVRInput.Get(OVRInput.Button.Four)) {
            GameObject ball = GameObject.Find("Ball");
            ball.transform.position = ball.transform.position - new Vector3(0.2f, 0, 0);
        }

        if (OVRInput.Get(OVRInput.Button.One)) {
            if (rigibody.IsSleeping()) {
                rigibody.WakeUp();
            } else {
                rigibody.Sleep();
            }
        }


        if (OVRInput.Get(OVRInput.Button.Start)) {
            GameObject ball = GameObject.Find("Ball");
            ball.transform.position = new Vector3(0, 0.5f, 0);
            rigibody.ResetInertiaTensor();
            rigibody.ResetCenterOfMass();
            rigibody.Sleep();
        }

        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.5f) {
            Vector3 position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Quaternion rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            if (isMoving) {
                GameObject ball = GameObject.Find("Ball");
                ball.transform.position = ball.transform.position + (position - initialPosition);
            } else {
                initialPosition = position; 
                initialRotation = rotation;
                isMoving = true;
            }
        } else if (isMoving) {
            isMoving = false;
        }


    }
}
