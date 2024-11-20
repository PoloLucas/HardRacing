using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class UI : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private Speedometer speedometer;
    [SerializeField]private CursorView cursor;
    [SerializeField]private NameList names;
    [SerializeField]private GameObject finishPanel;
    [SerializeField]private TextMeshProUGUI positionText;
    [SerializeField]private List<RectTransform> nameList = new List<RectTransform>();
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    private int playerNumber;

    void Awake(){
        if(gameModeManager.IsOnline){ //Cambia el número del jugador que se tomará de referencia para mostrar su información
            playerNumber = PhotonNetwork.LocalPlayer.GetPlayerNumber();
        }else{
            playerNumber = 0;
        }
        FinishLine.raceFinish += TurnOnFinishPanel;
        VehiclePositioner.checkedPositions += UpdatePositionList;
        names.SetNames(vehicleList);
        InvokeRepeating("UpdatePosition", 0.25f, 0.1f);
        InvokeRepeating("UpdateSpeed", 0.25f, 0.05f);
        InvokeRepeating("TurnOnFinishPanel", 0.25f, 0.1f);
        //cursor.HideCursor();
    }

    //Mueve los nombres de la lista de posiciones dependiendo de la posición de cada jugador
    public void UpdatePositionList(){
        for(int i = 0; i < vehicleList.Count; i++){
            if(nameList[i] != null){
                nameList[i].anchoredPosition = new Vector2(nameList[0].anchoredPosition.x, -25+(-50*(vehicleList[i].Position-1)));
            }
        }
    }

    //Actualiza la vista de la posición actual en la carrera
    public void UpdatePosition(){
        positionText.text = vehicleList[playerNumber].Position.ToString();
    }

    //Actualiza la vista del velocímetro con la velocidad actual
    public void UpdateSpeed(){
        speedometer.Speed = vehicleList[playerNumber].Speed;
        speedometer.MaxSpeed = vehicleList[playerNumber].MaxSpeed * 3;
    }

    //Muestra el menú al final de la carrera para cada jugador que pase la línea de meta
    public void TurnOnFinishPanel(){
        if(vehicleList[playerNumber].Status == 2 && finishPanel != null){
            finishPanel.SetActive(true);
            cursor.ShowCursor();
        }
    }
}