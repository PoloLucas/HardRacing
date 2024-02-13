using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworkConfig : MonoBehaviour{
    [SerializeField]private List<MonoBehaviour> scriptsToIgnore = new List<MonoBehaviour>();
    [SerializeField]private GameModeManager gameModeManager;
    private PhotonView photonView;

    void Start(){
        photonView = GetComponent<PhotonView>();
        if(gameModeManager.IsOnline && !photonView.IsMine){
            foreach(var script in scriptsToIgnore){
                script.enabled = false;
            }
        }
    }
}