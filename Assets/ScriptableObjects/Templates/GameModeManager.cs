using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Mode Manager", menuName = "Game Mode Manager")]
public class GameModeManager : ScriptableObject{
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    [SerializeField]private List<VehicleData> playerList = new List<VehicleData>();
    [SerializeField]private bool isOnline;
    [SerializeField]private int finishingPlayers;

    //Cuando se ejecute el juego, aplica estos valores iniciales
    void OnEnable(){
        isOnline = false;
        finishingPlayers = 0;
    }

    //Crea la lista de jugadores tomando la lista de vehículos como base
    public void SetPlayerList(){
        foreach(VehicleData vehicle in vehicleList){
            if(vehicle.IsPlayer){
                playerList.Add(vehicle);
            }
        }
    }

    //Borra todos los elementos de la lista de jugadores
    public void ResetPlayerList(){ 
        playerList.Clear();
    }

    //Determina el número de jugadores que finalizaron una carrera en base a su estado
    public void SetFinishingPlayers(){
        finishingPlayers = 0;
        foreach(VehicleData vehicle in playerList){
            if(vehicle.Status == 2){
                finishingPlayers++;
            }
        }
    }

    //Reinicia el valor de jugadores que terminaron la carrera
    public void ResetFinishingPlayers(){
        finishingPlayers = 0;
    }

    public List<VehicleData> VehicleList {get {return vehicleList;}}
    public List<VehicleData> PlayerList {get {return playerList;}}
    public bool IsOnline {get {return isOnline;} set {isOnline = value;}}
    public int FinishingPlayers {get {return finishingPlayers;}}
}