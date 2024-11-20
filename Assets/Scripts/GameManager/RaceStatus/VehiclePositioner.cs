using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiclePositioner : MonoBehaviour{
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    [SerializeField]private BubbleSort bubbleSort;
    [SerializeField]private Transform checkpoints;
    private List<Transform> checkpointList = new List<Transform>();
    public delegate void CheckedPositions();
    public static CheckedPositions checkedPositions;

    void Awake(){
        foreach(Transform child in checkpoints){ //Guarda las posiciones de todos los checkpoints en una lista
            checkpointList.Add(child);
        }
        InvokeRepeating("CheckPositions", 0.25f, 0.1f);
    }

    public void CheckPositions(){
        bubbleSort.SortByDistance(vehicleList);
        foreach(VehicleData vehicle in vehicleList){ //Calcula el progreso del vehículo usando su posición entre el checkpoint actual y el siguiente
            Vector3 currentCheckpoint = checkpointList[vehicle.Checkpoint-1].position;
            Vector3 nextCheckpoint = checkpointList[vehicle.Checkpoint].position;
            vehicle.TraveledDistance = vehicle.Checkpoint + bubbleSort.InverseLerp(currentCheckpoint, nextCheckpoint, vehicle.TrackPosition);
            if(vehicle.Status != 2){ //Actualiza la posición del jugador si este aún no terminó la carrara
                vehicle.Position = vehicleList.IndexOf(vehicle)+1;
            }
        }
        checkedPositions();
    }
}