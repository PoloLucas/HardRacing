using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour{
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    private List<Checkpoint> checkpointList = new List<Checkpoint>();
    private List<int> nextCheckpoint = new List<int>();

    void Awake(){
        foreach(Transform child in transform){
            Checkpoint checkpoint = child.GetComponent<Checkpoint>();
            checkpoint.SetCheckpoint(this);
            checkpointList.Add(checkpoint);
        }
        foreach(VehicleData vehicleData in vehicleList){
            nextCheckpoint.Add(1);
        }
    }

    public void PassedCheckpoint(Checkpoint checkpoint, VehicleData vehicle){
        int passedCheckpoint = nextCheckpoint[vehicle.Id-1];
        if(checkpointList.IndexOf(checkpoint) == passedCheckpoint){
            nextCheckpoint[vehicle.Id-1]++;
            vehicle.Checkpoint++;
            if(checkpoint.tag == "FinishLine"){
                checkpoint.GetComponent<FinishLine>().SetFinishPosition(vehicle);
            }
        }
    }
}