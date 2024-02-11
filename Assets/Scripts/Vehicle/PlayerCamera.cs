using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerCamera : MonoBehaviour{
    [SerializeField]private GameObject playerCamera;
    [SerializeField]private PhotonView photonView;

    void Awake(){
        if(photonView.IsMine){
            playerCamera.SetActive(true);
        }
    }
}