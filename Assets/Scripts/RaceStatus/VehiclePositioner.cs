using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePositioner : MonoBehaviour{
    public delegate void CheckedPositions();
    public static CheckedPositions checkedPositions;
    private BubbleSort bubbleSort;
    [SerializeField]private Transform vehicles;
    [SerializeField]private Transform checkpoints;
    private List<Transform> vehicleList = new List<Transform>();
    private List<Transform> checkpointList = new List<Transform>();

    void Awake(){
        bubbleSort = GetComponent<BubbleSort>();
        foreach(Transform child in vehicles){
            vehicleList.Add(child);
        }
        foreach(Transform child in checkpoints){
            checkpointList.Add(child);
        }
        InvokeRepeating("CheckPositions", 0.1f, 0.1f);
    }

    public void CheckPositions(){
        bubbleSort.SortByDistance(vehicleList);
        foreach(Transform child in vehicleList){
            Vehicle vehicle = child.GetComponent<Vehicle>();
            Vector3 currentCheckpoint = checkpointList[vehicle.checkpoint - 1].position;
            Vector3 nextCheckpoint = checkpointList[vehicle.checkpoint].position;
            vehicle.traveledDistance = vehicle.checkpoint + bubbleSort.InverseLerp(currentCheckpoint, nextCheckpoint, child.position);
            if(vehicle.enabled){
                vehicle.position = vehicleList.IndexOf(child) + 1;
            }
        }
        checkedPositions();
    }
}