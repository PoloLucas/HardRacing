using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLine : MonoBehaviour{
    public delegate void RaceFinish();
    public static RaceFinish raceFinish;
    private int finishPosition = 1;

    public void SetFinishPosition(Vehicle vehicle){
        vehicle.position = finishPosition;
        vehicle.enabled = false;
        finishPosition++;
        raceFinish();
    }
}