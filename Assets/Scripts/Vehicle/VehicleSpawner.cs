using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VehicleSpawner : MonoBehaviour{
    [SerializeField]private List<GameObject> playerVehicles = new List<GameObject>();
    [SerializeField]private List<GameObject> cpuVehicles = new List<GameObject>();
    [SerializeField]private List<Transform> spawnerList = new List<Transform>();
    [SerializeField]private GameModeManager gameModeManager;

    void Awake(){
        for(int i = 0; i < spawnerList.Count; i++){
            if(gameModeManager.VehicleList[i].IsPlayer){
                if(gameModeManager.IsOnline){
                    string onlineVehicle = "Vehicle" + gameModeManager.VehicleList[i].Id;
                    PhotonNetwork.Instantiate(onlineVehicle, spawnerList[i].position, spawnerList[i].rotation);
                }else{
                    Instantiate(playerVehicles[i], spawnerList[i].position, spawnerList[i].rotation);
                }
            }else{
                Instantiate(cpuVehicles[i], spawnerList[i].position, spawnerList[i].rotation);
            }
        }
    }
}