using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// https://skarredghost.com/2020/01/03/how-to-oculus-quest-hands-sdk-unity/

public class Cube : MonoBehaviour {

  private bool isCalibrating;

  private int timeout;

  OVRHand rightHand;
  OVRHand leftHand;

  GameObject rightHandObject;
  GameObject leftHandObject;

  Renderer captureLight;
  Renderer snapLight;

  UnityEvent snapEvent;
  int snapTimer;
  DateTime startSnapTime;
  bool isSnapping = false;

  public enum Status {
    Default,
    PrepareCalibration,
    Calibration,
  }

  Status status;

  Vector3 thumb0PreviousPosition;
  bool isTranslating = false;

  GameObject box;
  GameObject text;

  bool isBoxOn = false;

  // Start is called before the first frame update
  void Start() {

    box = GameObject.Find("Box");
    text = GameObject.Find("Text");

    text.SetActive(false);

    rightHandObject = GameObject.Find("OVRCustomHandPrefab_R");
    leftHandObject = GameObject.Find("OVRCustomHandPrefab_L");

    rightHand = rightHandObject.GetComponent<OVRHand>();
    leftHand = leftHandObject.GetComponent<OVRHand>();

    isCalibrating = false;

    captureLight = GameObject.Find("Capture").GetComponent<Renderer>();
    snapLight = GameObject.Find("SnapLight").GetComponent<Renderer>();

    if (snapEvent == null)
      snapEvent = new UnityEvent();

    // snapEvent.AddListener(Ping);
  }

  bool IsStartingSnap(OVRHand hand) {
    OVRHand.TrackingConfidence confidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

    return hand.GetFingerIsPinching(OVRHand.HandFinger.Middle) && confidence == OVRHand.TrackingConfidence.High;
  }

  bool IsEndingRightSnap() {
    Vector3 trapeziumThumbPosition = GameObject.Find("b_r_thumb0").transform.position;
    Vector3 distalMiddlePosition = GameObject.Find("b_r_middle3").transform.position;

    float dist = Vector3.Distance(distalMiddlePosition, trapeziumThumbPosition);

    return dist < 0.08;
  }

  // Update is called once per frame
  void Update() {
    // bool isIndexFingerPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
    // float ringFingerPinchStrength = rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);

    if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index)) {
      GameObject.Find("RightCube").GetComponent<Renderer>().material.color = Color.red;
    } else {
      GameObject.Find("RightCube").GetComponent<Renderer>().material.color = Color.white;
    }

    if (leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index)) {
      GameObject.Find("LeftCube").GetComponent<Renderer>().material.color = Color.red;
    } else {
      GameObject.Find("LeftCube").GetComponent<Renderer>().material.color = Color.white;
    }

    if (status == Status.PrepareCalibration) {
      GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.grey;
    } else if (status == Status.Calibration) {
      GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.red;
    } else {
      GameObject.Find("Cube").GetComponent<Renderer>().material.color = Color.white;
    }

    if (rightHand.IsTracked || leftHand.IsTracked) {
      captureLight.material.color = Color.red;
    } else {
      captureLight.material.color = Color.white;
    }

    if (IsEndingRightSnap()) {
      System.TimeSpan diff = System.DateTime.UtcNow - startSnapTime;
      if (diff.Milliseconds <= 100 && isSnapping) {
        isBoxOn = !isBoxOn;
        text.SetActive(isBoxOn);

        if (isBoxOn) {
          // box.GetComponent<Renderer>().material.color = Color.green;
        } else {
          // box.GetComponent<Renderer>().material.color = Color.red;
        }
      }
      isSnapping = false;

    } else if (IsStartingSnap(rightHand)) {
      startSnapTime = System.DateTime.UtcNow;
      isSnapping = true;
    } else {
      isSnapping = false;
    }

    // if (IsStartingSnap(rightHand)) {
    //   startSnapTime = System.DateTime.UtcNow;
    // }

    if (IsEndingRightSnap()) {
      snapLight.material.color = Color.blue;
    } else if (IsStartingSnap(rightHand) || IsStartingSnap(leftHand)) {
      snapLight.material.color = Color.green;

      // Vector3 thumb0Position = GameObject.Find("b_r_thumb0").transform.position;

      // if (isTranslating) {
      //   Vector3 translate = thumb0Position - thumb0PreviousPosition;
      //   box.transform.position += translate;
      // }
      // isTranslating = true;
      // thumb0PreviousPosition = thumb0Position;
    } else {
      snapLight.material.color = Color.white;
      isTranslating = false;
    }
  }

  void FixedUpdate() {

    if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky) && leftHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky)) {
      status = Status.PrepareCalibration;
    } else {
      status = Status.Default;
    }

  }
}