using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour{
    [SerializeField]private GameObject finishPanel;
    [SerializeField]private TextMeshProUGUI positionText;
    [SerializeField]private TextMeshProUGUI speedText;
    [SerializeField]private Transform names;
    [SerializeField]private Transform vehicles;
    private List<RectTransform> nameList = new List<RectTransform>();
    private List<Vehicle> vehicleList = new List<Vehicle>();

    void Awake(){
        FinishLine.raceFinish += TurnOnFinishPanel;
        VehiclePositioner.checkedPositions += UpdatePositions;
        foreach(RectTransform child in names){
            nameList.Add(child);
        }
        foreach(Transform child in vehicles){
            Vehicle vehicle = child.GetComponent<Vehicle>();
            vehicleList.Add(vehicle);
        }
        InvokeRepeating("UpdateSpeed", 0f, 0.05f);
    }

    public void UpdatePositions(){
        positionText.text = vehicleList[9].position + ".°";
        for(int i = 0; i < nameList.Count; i++){
            nameList[i].anchoredPosition = new Vector2(0, -20*(vehicleList[i].position-1));
        }
    }

    public void UpdateSpeed(){
        speedText.text = vehicleList[9].speed + "<size=55%> km/h";
    }

    public void TurnOnFinishPanel(){
        if(!vehicleList[9].enabled){
            finishPanel.SetActive(true);
        }
    }
}