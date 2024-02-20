using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vehicle Manager", menuName = "Vehicle Manager")]
public class VehicleManager : ScriptableObject{
    [SerializeField]private List<string> cpuDefaultNames = new List<string>();
    [SerializeField]private List<string> playerDefaultNames = new List<string>();
    [SerializeField]private List<int> basePosition = new List<int>();
    [SerializeField]private List<float> baseMaxSpeed = new List<float>();
    [SerializeField]private float baseAcceleration;
    [SerializeField]private float baseTurningSpeed;
    [SerializeField]private float basePlayerMaxSpeed;
    [SerializeField]private float basePlayerAcceleration;
    [SerializeField]private float basePlayerTurningSpeed;
    [SerializeField]private float multiplayerSpeedHandicap;

    //Reinicia todos las variables de los vehículos a sus valores iniciales
    public void ResetValues(VehicleData vehicle){
        vehicle.IsPlayer = false;
        vehicle.PlayerName = cpuDefaultNames[vehicle.Id-1];
        vehicle.Position = basePosition[vehicle.Id-1];
        vehicle.Speed = 0;
        vehicle.MaxSpeed = baseMaxSpeed[vehicle.Id-1];
        vehicle.Acceleration = baseAcceleration;
        vehicle.TurningSpeed = baseTurningSpeed;
    }

    //Asigna variables de jugador a un vehículo
    public void SetPlayerValues(VehicleData vehicle){
        vehicle.IsPlayer = true;
        vehicle.MaxSpeed = basePlayerMaxSpeed;
        vehicle.Acceleration = basePlayerAcceleration;
        vehicle.TurningSpeed = basePlayerTurningSpeed;
    }

    //Restablece todos los valores de progreso que cambiaron durante la carrera
    public void ResetCheckpoints(VehicleData vehicle){
        vehicle.Status = 0;
        vehicle.Checkpoint = 1;
        vehicle.TraveledDistance = 1;
        vehicle.TrackPosition = new Vector3(0, 0, 0);
    }

    //Asigna un nuevo nombre al vehículo
    public void SetPlayerName(VehicleData vehicle, string newName){
        vehicle.PlayerName = newName;
    }

    //Añade una ventaja si el jugador no va en primer lugar
    public void ApplySpeedHandicap(VehicleData vehicle, bool isLosing){
        if(isLosing){
            vehicle.MaxSpeed = basePlayerMaxSpeed + multiplayerSpeedHandicap;
        }else{
            vehicle.MaxSpeed = basePlayerMaxSpeed;
        }
    }

    public List<string> CPUDefaultNames {get {return cpuDefaultNames;}}
    public List<string> PlayerDefaultNames {get {return playerDefaultNames;}}
    public List<int> BasePosition {get {return basePosition;}}
    public List<float> BaseMaxSpeed {get {return baseMaxSpeed;}}
    public float BaseAcceleration {get {return baseAcceleration;}}
    public float BaseTurningSpeed {get {return baseTurningSpeed;}}
    public float BasePlayerMaxSpeed {get {return basePlayerMaxSpeed;}}
    public float BasePlayerAcceleration {get {return basePlayerAcceleration;}}
    public float BasePlayerTurningSpeed {get {return basePlayerTurningSpeed;}}
    public float MultiplayerSpeedHandicap {get {return multiplayerSpeedHandicap;}}
}