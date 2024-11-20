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
    private NetworkConfig networkConfig; public NetworkConfig Network{get => networkConfig;}
    private PhotonView photonView;

    void Awake(){
        networkConfig = GetComponent<NetworkConfig>();
        photonView = GetComponent<PhotonView>();
        if(SceneManager.GetActiveScene().name == "MainMenu"){ //Reinicia vehículos y lista de jugadores al ingresar al menú principal
            ResetVehicles();
            gameModeManager.ResetPlayerList();
            gameModeManager.ResetFinishingPlayers();
        }else{
            RestartRace();
        }
    }

    //Carga la escena con el nombre que recibe
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    //Cierra el juego
    public void QuitGame(){
        Application.Quit();
        Debug.Log("Con este Boton se cierra el Juego");
    }

    //Aplica valores predefinidos necesarios para iniciar una carrera sin conexión
    public void StartOfflineRace(string levelName){
        gameModeManager.IsOnline = false;
        vehicleManager.SetPlayerValues(gameModeManager.VehicleList[0]);
        gameModeManager.SetPlayerList();
        LoadScene(levelName);
    }

    //Da la orden a todas las instancias conectadas de realizar la función indicada
    public void StartOnlineRace(string levelName){
        photonView.RPC("SyncPlayerInfo", RpcTarget.All, levelName);
    }

    //Aplica valores necesarios y nombres de jugador para iniciar una carrera en línea
    [PunRPC]public void SyncPlayerInfo(string levelName){
        gameModeManager.IsOnline = true;
        foreach(Player player in PhotonNetwork.PlayerList){
            vehicleManager.SetPlayerValues(gameModeManager.VehicleList[player.GetPlayerNumber()]);
            vehicleManager.SetPlayerName(gameModeManager.VehicleList[player.GetPlayerNumber()], player.NickName);
        }
        gameModeManager.SetPlayerList();
        networkConfig.LoadLevel(levelName);
    }

    //Reinicia valores de vehículo y de progreso de la carrera
    public void ResetVehicles(){
        foreach(VehicleData vehicle in gameModeManager.VehicleList){
            vehicleManager.ResetValues(vehicle);
            vehicleManager.ResetCheckpoints(vehicle);
        }
    }

    //Reinicia únicamente valores de progreso de la carrera
    public void RestartRace(){
        gameModeManager.ResetFinishingPlayers();
        foreach(VehicleData vehicle in gameModeManager.VehicleList){
            vehicleManager.ResetCheckpoints(vehicle);
        }
    }
}