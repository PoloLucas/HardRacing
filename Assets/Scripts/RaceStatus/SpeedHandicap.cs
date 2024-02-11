using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedHandicap : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private VehicleManager vehicleManager;

    void Awake(){
        if(gameModeManager.PlayerList.Count >= 2){
            InvokeRepeating("ApplyHandicap", 0f, 1f);
            //VehiclePositioner.checkedPositions += ApplyHandicap;
        }
    }

    public void ApplyHandicap(){
        foreach(VehicleData vehicle in gameModeManager.PlayerList){
            if(vehicle.Position >= 2){
                vehicleManager.ApplySpeedHandicap(vehicle, true);
            }else{
                vehicleManager.ApplySpeedHandicap(vehicle, false);
            }
        }
    }
}