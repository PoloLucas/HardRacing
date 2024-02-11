using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Mode Manager", menuName = "Game Mode Manager")]
public class GameModeManager : ScriptableObject{
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    [SerializeField]private List<VehicleData> playerList = new List<VehicleData>();
    [SerializeField]private bool isOnline;
    [SerializeField]private int finishingPlayers;

    void OnEnable(){
        isOnline = false;
        finishingPlayers = 0;
    }

    public void SetPlayerList(){
        foreach(VehicleData vehicle in vehicleList){
            if(vehicle.IsPlayer){
                playerList.Add(vehicle);
            }
        }
    }

    public void ResetPlayerList(){
        playerList.Clear();
    }

    public void SetFinishingPlayers(){
        finishingPlayers = 0;
        foreach(VehicleData vehicle in playerList){
            if(vehicle.Status == 2){
                finishingPlayers++;
            }
        }
    }

    public void ResetFinishingPlayers(){
        finishingPlayers = 0;
    }

    public List<VehicleData> VehicleList {get {return vehicleList;}}
    public List<VehicleData> PlayerList {get {return playerList;}}
    public bool IsOnline {get {return isOnline;} set {isOnline = value;}}
    public int FinishingPlayers {get {return finishingPlayers;}}
}