using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class NameList : MonoBehaviour{
    [SerializeField]private List<TextMeshProUGUI> nameText = new List<TextMeshProUGUI>();
    [SerializeField]private VehicleManager vehicleManager;
    [SerializeField]private GameModeManager gameModeManager;

    public void SetNames(List<VehicleData> vehicle){
        for(int i = 0; i < nameText.Count; i++){
            if(vehicle[i].IsPlayer){
                if(!gameModeManager.IsOnline){
                    vehicle[i].PlayerName = vehicleManager.PlayerDefaultNames[i];
                }
            }else{
                vehicle[i].PlayerName = vehicleManager.CPUDefaultNames[i];
            }
            nameText[i].text = vehicle[i].PlayerName;
        }
    }
}