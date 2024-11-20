using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUInput : InputType{
    [SerializeField]public List<VehicleData> vehicleList = new List<VehicleData>();
    private Transform checkpoints;
    private List<Transform> checkpointList = new List<Transform>();
    private float checkpointRotation;
    private float cpuRotation;
    private float direction;

    void Awake(){
        checkpoints = GameObject.FindWithTag("Checkpoints").transform;
        foreach(Transform child in checkpoints){ //Extrae la posición y rotación de cada checkpoint
            Transform checkpoint = child.GetComponent<Transform>();
            checkpointList.Add(checkpoint);
        }
    }

    void Update(){
        cpuRotation = transform.rotation.y;
        checkpointRotation = checkpointList[vehicleList[id].Checkpoint].rotation.y; //Obtiene la rotación del checkpoint actual
        direction = Mathf.Abs(cpuRotation - checkpointRotation); //Calcula qué tan cerca está el vehículo de tener la misma rotación que el checkpoint
        GetXAxis();
        GetYAxis();
    }

    //Gira hacia la izquierda o derecha si tiene más o menos rotación que el checkpoint
    void GetXAxis(){
        if(direction > 0.005f){
            if(cpuRotation > checkpointRotation){
                xAxis = -1;
            }else{
                xAxis = 1;
            }
        }else{
            xAxis = 0;
        }
    }

    //Acelera si la rotación está cerca de la del checkpoint, si no, frena
    void GetYAxis(){
        if(direction < 0.15f){
            yAxis = 1;
        }else{
            yAxis = -1;
        }
    }
}