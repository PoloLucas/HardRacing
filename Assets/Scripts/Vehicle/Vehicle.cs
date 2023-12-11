using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour{
    public int speed;
    public int position;
    public int checkpoint;
    public float traveledDistance;
    [SerializeField]public List<Wheel> wheels;
    private VehicleMovement movement;
    private InputType input;

    void Awake(){
        checkpoint = 1;
        movement = GetComponent<VehicleMovement>();
        input = GetComponent<InputType>();
    }

    void FixedUpdate(){
        Move(input.yAxis);
        Turn(input.xAxis);
        RotateWheels(input.xAxis, input.yAxis);
        SimulatedSpeed();
    }

    void Move(float yAxisValue){
        if(input.yAxis > 0){
            movement.Accelerate(yAxisValue);
        }else{
            movement.Brake(yAxisValue);
        }
    }

    void Turn(float xAxisValue){
        movement.Turn(xAxisValue);
    }

    void RotateWheels(float xAxisValue, float yAxisValue){
        foreach(Wheel wheel in wheels){
            wheel.RotateWheel(xAxisValue, yAxisValue, movement.speed);
        }
    }

    void SimulatedSpeed(){
        float realSpeed = Mathf.Clamp(movement.speed, 0, movement.maxSpeed - 0.3f) * 3;
        speed = (int) realSpeed;
    }
}