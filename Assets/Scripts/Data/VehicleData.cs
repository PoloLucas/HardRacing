using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Vehicle Data", menuName = "Vehicle Data")]
public class VehicleData : ScriptableObject{
    [SerializeField]private int id;
    [SerializeField]private bool isPlayer;
    [SerializeField]private string playerName;
    [SerializeField]private Vector3 trackPosition;
    [SerializeField]private int status;
    [SerializeField]private int position;
    [SerializeField]private int checkpoint;
    [SerializeField]private float traveledDistance;
    [SerializeField]private int speed;
    [SerializeField]private float maxSpeed;
    [SerializeField]private float acceleration;
    [SerializeField]private float brakingForce;
    [SerializeField]private float turningSpeed;

    public int Id {get {return id;}}
    public bool IsPlayer {get {return isPlayer;} set {isPlayer = value;}}
    public string PlayerName {get {return playerName;} set {playerName = value;}}
    public Vector3 TrackPosition {get {return trackPosition;} set {trackPosition = value;}}
    public int Status {get {return status;} set {status = value;}}
    public int Position {get {return position;} set {position = value;}}
    public int Checkpoint {get {return checkpoint;} set {checkpoint = value;}}
    public float TraveledDistance {get {return traveledDistance;} set {traveledDistance = value;}}
    public int Speed {get {return speed;} set {speed = value;}}
    public float MaxSpeed {get {return maxSpeed;} set {maxSpeed = value;}}
    public float Acceleration {get {return acceleration;} set {acceleration = value;}}
    public float BrakingForce {get {return brakingForce;} set {brakingForce = value;}}
    public float TurningSpeed {get {return turningSpeed;} set {turningSpeed = value;}}
}