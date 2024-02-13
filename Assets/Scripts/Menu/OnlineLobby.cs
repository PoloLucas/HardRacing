using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineLobby : MonoBehaviour{
    [SerializeField]private GameObject startButton;

    void Start(){
        PhotonNetwork.AutomaticallySyncScene = true;
        InvokeRepeating("CheckPlayerCount", 0f, 0.5f);
    }

    public void CheckPlayerCount(){
        if(PhotonNetwork.PlayerList.Length >= 1 && PhotonNetwork.IsMasterClient){
            startButton.SetActive(true);
        }else{
            startButton.SetActive(false);
        }
    }
}
