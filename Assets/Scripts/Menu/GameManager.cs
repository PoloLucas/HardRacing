using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private VehicleManager vehicleManager;
    [SerializeField]private PhotonView photonView;

    void Awake(){
        if(SceneManager.GetActiveScene().name == "MainMenu"){
            ResetVehicles();
            gameModeManager.ResetPlayerList();
            gameModeManager.ResetFinishingPlayers();
        }else{
            RestartRace();
        }
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Con este Boton se cierra el Juego");
    }

    public void StartOfflineRace(){
        gameModeManager.IsOnline = false;
        vehicleManager.SetPlayerValues(gameModeManager.VehicleList[0]);
        gameModeManager.SetPlayerList();
    }
    public void StartOnlineRace(){
        photonView.RPC("SyncPlayerInfo", RpcTarget.All);
    }

    [PunRPC]
    public void SyncPlayerInfo(){
        gameModeManager.IsOnline = true;
        foreach(Player player in PhotonNetwork.PlayerList){
            vehicleManager.SetPlayerValues(gameModeManager.VehicleList[player.ActorNumber-1]);
            vehicleManager.SetPlayerName(gameModeManager.VehicleList[player.ActorNumber-1], player.NickName);
        }
        gameModeManager.SetPlayerList();
    }

    public void ResetVehicles(){
        foreach(VehicleData vehicle in gameModeManager.VehicleList){
            vehicleManager.ResetValues(vehicle);
            vehicleManager.ResetCheckpoints(vehicle);
        }
    }

    public void RestartRace(){
        gameModeManager.ResetFinishingPlayers();
        foreach(VehicleData vehicle in gameModeManager.VehicleList){
            vehicleManager.ResetCheckpoints(vehicle);
        }
    }
}