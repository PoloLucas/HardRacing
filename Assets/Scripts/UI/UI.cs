using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class UI : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private CursorView cursor;
    [SerializeField]private NameList names;
    [SerializeField]private GameObject finishPanel;
    [SerializeField]private TextMeshProUGUI positionText;
    [SerializeField]private TextMeshProUGUI speedText;
    [SerializeField]private List<RectTransform> nameList = new List<RectTransform>();
    [SerializeField]private List<VehicleData> vehicleList = new List<VehicleData>();
    private int playerNumber;

    void Awake(){
        if(gameModeManager.IsOnline){
            playerNumber = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        }else{
            playerNumber = 0;
        }
        FinishLine.raceFinish += TurnOnFinishPanel;
        VehiclePositioner.checkedPositions += UpdatePositionList;
        names.SetNames(vehicleList);
        InvokeRepeating("UpdatePosition", 0.25f, 0.1f);
        InvokeRepeating("UpdateSpeed", 0.25f, 0.05f);
        //cursor.HideCursor();
    }

    public void UpdatePositionList(){
        for(int i = 0; i < vehicleList.Count; i++){
            if(nameList[i] != null){
                nameList[i].anchoredPosition = new Vector2(0, -20*(vehicleList[i].Position-1));
            }
        }
    }

    public void UpdatePosition(){
        TurnOnFinishPanel();
        positionText.text = vehicleList[playerNumber].Position + ".°";
    }

    public void UpdateSpeed(){
        speedText.text = vehicleList[playerNumber].Speed + "<size=55%> km/h";
    }

    public void TurnOnFinishPanel(){
        if(vehicleList[playerNumber].Status == 2 && finishPanel != null){
            finishPanel.SetActive(true);
            cursor.ShowCursor();
        }
    }
}