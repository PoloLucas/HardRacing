using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class VehicleSpawner : MonoBehaviour{
    [SerializeField]private List<GameObject> playerVehicles = new List<GameObject>();
    [SerializeField]private List<GameObject> cpuVehicles = new List<GameObject>();
    [SerializeField]private List<Transform> spawnerList = new List<Transform>();
    [SerializeField]private GameModeManager gameModeManager;

    void Awake(){
        if(gameModeManager.IsOnline){
            SpawnOnlineVehicles();
        }else{
            SpawnOfflineVehicles();
        }
    }

    //Instancia el vehículo del jugador y, si se es dueño de la sala, los CPU de los que no sean jugadores
    public void SpawnOnlineVehicles(){
        int playerNumber = PhotonNetwork.LocalPlayer.GetPlayerNumber();
        PhotonNetwork.Instantiate(playerVehicles[playerNumber].name, spawnerList[playerNumber].position, spawnerList[playerNumber].rotation);
        for(int i = 0; i < spawnerList.Count; i++){
            if(!gameModeManager.VehicleList[i].IsPlayer && PhotonNetwork.IsMasterClient){
                PhotonNetwork.Instantiate(cpuVehicles[i].name, spawnerList[i].position, spawnerList[i].rotation);
            }
        }
    }

    //Instancia un vehículo jugador, o CPU si no hay más jugadores
    public void SpawnOfflineVehicles(){
        for(int i = 0; i < spawnerList.Count; i++){
            if(gameModeManager.VehicleList[i].IsPlayer){
                Instantiate(playerVehicles[i], spawnerList[i].position, spawnerList[i].rotation);
            }else{
                Instantiate(cpuVehicles[i], spawnerList[i].position, spawnerList[i].rotation);
            }
        }
    }
}