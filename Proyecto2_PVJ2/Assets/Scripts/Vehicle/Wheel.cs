using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour{
    public void RotateWheel(float xAxis, float yAxis, float speed){
        transform.Rotate(yAxis*speed, 0, 0 * Time.deltaTime, Space.Self);
        if(gameObject.tag == "FrontWheel"){
            TurnWheel(xAxis);
        }
    }

    public void TurnWheel(float xAxis){
        transform.parent.localEulerAngles = new Vector3(0, xAxis*20, 0);
    }
}