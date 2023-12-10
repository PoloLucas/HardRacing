using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour{
    private List<Checkpoint> checkpointList = new List<Checkpoint>();
    private List<Transform> vehicleList = new List<Transform>();
    private List<int> nextCheckpoint = new List<int>();
    [SerializeField]private Transform vehicles;

    void Awake(){
        foreach(Transform child in transform){
            Checkpoint checkpoint = child.GetComponent<Checkpoint>();
            checkpoint.SetCheckpoint(this);
            checkpointList.Add(checkpoint);
        }
        foreach(Transform child in vehicles){
            vehicleList.Add(child);
            nextCheckpoint.Add(1);
        }
    }

    public void PassedCheckpoint(Checkpoint checkpoint, Transform vehicle){
        int passedCheckpoint = nextCheckpoint[vehicleList.IndexOf(vehicle)];
        Vehicle racerStatus = vehicle.GetComponent<Vehicle>();
        if(checkpointList.IndexOf(checkpoint) == passedCheckpoint){
            nextCheckpoint[vehicleList.IndexOf(vehicle)]++;
            racerStatus.checkpoint++;
            //Debug.Log("Next");
        }
        if(checkpoint.tag == "FinishLine"){
            checkpoint.GetComponent<FinishLine>().SetFinishPosition(racerStatus);
        }
    }
}