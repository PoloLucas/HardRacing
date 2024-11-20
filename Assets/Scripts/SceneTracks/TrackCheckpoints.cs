using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour{
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    private List<Checkpoint> checkpointList = new List<Checkpoint>();
    private List<int> nextCheckpoint = new List<int>();

    void Awake(){
        foreach(Transform child in transform){ //Crea una lista con el script de cada checkpoint
            Checkpoint checkpoint = child.GetComponent<Checkpoint>();
            checkpoint.SetCheckpoint(this);
            checkpointList.Add(checkpoint);
        }
        foreach(VehicleData vehicleData in vehicleList){ //Crea una lista con el checkpoint objetivo de cada jugador
            nextCheckpoint.Add(1);
        }
    }

    //Comprueba si el checkpoint que acaba de atravesar el jugador era el que necesitaba atravesar
    public void PassedCheckpoint(Checkpoint checkpoint, VehicleData vehicle){
        int targetCheckpoint = nextCheckpoint[vehicle.Id-1];
        if(checkpointList.IndexOf(checkpoint) == targetCheckpoint){
            nextCheckpoint[vehicle.Id-1]++;
            vehicle.Checkpoint++;
            if(checkpoint.tag == "FinishLine"){
                checkpoint.GetComponent<FinishLine>().SetFinishPosition(vehicle);
            }
        }
    }
}