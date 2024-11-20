using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour{
    public delegate void RaceFinish();
    public static RaceFinish raceFinish;
    private int finishPosition = 1;

    //Le asigna al jugador la posición final y el estado de que teminó la carrera
    public void SetFinishPosition(VehicleData vehicle){
        vehicle.Status = 2;
        vehicle.Position = finishPosition;
        raceFinish();
        finishPosition++;
    }
}