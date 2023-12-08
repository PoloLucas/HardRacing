using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUInput : InputType{
    private Transform checkpoints;
    private List<Transform> checkpointList = new List<Transform>();
    private Vehicle vehicle;
    private float checkpointRotation;
    private float cpuRotation;
    private float direction;

    void Awake(){
        checkpoints = GameObject.FindWithTag("Checkpoints").transform;
        vehicle = GetComponent<Vehicle>();
        foreach(Transform child in checkpoints){
            Transform checkpoint = child.GetComponent<Transform>();
            checkpointList.Add(checkpoint);
        }
    }

    void Update(){
        cpuRotation = transform.rotation.y;
        checkpointRotation = checkpointList[vehicle.checkpoint].rotation.y;
        direction = Mathf.Abs(cpuRotation - checkpointRotation);
        GetXAxis();
        GetYAxis();
    }

    void GetXAxis(){
        if(direction > 0.004f){
            if(cpuRotation > checkpointRotation){
                xAxis = -1;
            }else{
                xAxis = 1;
            }
        }else{
            xAxis = 0;
        }
    }

    void GetYAxis(){
        if(direction < 0.15f){
            yAxis = 1;
        }else{
            yAxis = -1;
        }
    }
}