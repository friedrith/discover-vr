using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://skarredghost.com/2020/01/03/how-to-oculus-quest-hands-sdk-unity/

public class Cube : MonoBehaviour
{

  private bool isCalibrating;

  private int timeout;

  OVRHand rightHand;
  OVRHand leftHand;

  public enum Status
  {
    Default,
    PrepareCalibration,
    Calibration,
  }

  Status status;

  // Start is called before the first frame update
  void Start()
  {

    rightHand = GameObject.Find("OVRHandRight").GetComponent<OVRHand>();
    leftHand = GameObject.Find("OVRHandLeft").GetComponent<OVRHand>();

    isCalibrating = false;
  }

  // Update is called once per frame
  void Update()
  {
    // bool isIndexFingerPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
    // float ringFingerPinchStrength = rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);

    if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
    {
      GameObject.Find("RightCube").GetComponent<Renderer>().material.color = Color.red;
    }
    else
    {
      GameObject.Find("RightCube").GetComponent<Renderer>().material.color = Color.white;
    }

    if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
    {
      GameObject.Find("LeftCube").GetComponent<Renderer>().material.color = Color.red;
    }
    else
    {
      GameObject.Find("LeftCube").GetComponent<Renderer>().material.color = Color.white;
    }

    if (status == Status.PrepareCalibration)
    {
      GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.grey;
    }
    else if (status == Status.Calibration)
    {
      GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.red;
    }
    else
    {
      GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.white;
    }
  }

  void FixedUpdate()
  {

    if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky) && leftHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky))
    {
      status = Status.PrepareCalibration;
    }
    else
    {
      status = Status.Default;
    }

  }
}