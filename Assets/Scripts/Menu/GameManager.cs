using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class GameManager : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private VehicleManager vehicleManager;
    private NetworkConfig networkConfig;
    private PhotonView photonView;

    void Awake(){
        networkConfig = GetComponent<NetworkConfig>();
        photonView = GetComponent<PhotonView>();
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

    public void StartOfflineRace(string levelName){
        gameModeManager.IsOnline = false;
        vehicleManager.SetPlayerValues(gameModeManager.VehicleList[0]);
        gameModeManager.SetPlayerList();
        LoadScene(levelName);
    }

    public void StartOnlineRace(string levelName){
        photonView.RPC("SyncPlayerInfo", RpcTarget.All, levelName);
    }

    [PunRPC]public void SyncPlayerInfo(string levelName){
        gameModeManager.IsOnline = true;
        foreach(Player player in PhotonNetwork.PlayerList){
            vehicleManager.SetPlayerValues(gameModeManager.VehicleList[player.GetPlayerNumber()]);
            vehicleManager.SetPlayerName(gameModeManager.VehicleList[player.GetPlayerNumber()], player.NickName);
        }
        gameModeManager.SetPlayerList();
        networkConfig.LoadLevel(levelName);
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