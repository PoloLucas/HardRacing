using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class SpeedMeter : MonoBehaviour{
    [SerializeField]private TextMeshProUGUI speedText;

    void Start(){
        InvokeRepeating("UpdateSpeed", 0f, 0.05f);
    }

    public void UpdateSpeed(){
        //speedText.text = vehicleList[PhotonNetwork.LocalPlayer.ActorNumber].speed + "<size=55%> km/h";
    }
}