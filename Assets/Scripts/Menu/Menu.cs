using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private GameObject mainPanel;
    [SerializeField]private GameObject onlineLobby;
    [SerializeField]private GameObject connectingPanel;

    void Awake(){
        if(gameModeManager.IsOnline){
            mainPanel.SetActive(false);
            onlineLobby.SetActive(true);
        }
        NetworkConfig.connectingOnline += ShowConnectingPanel;
        NetworkConfig.joiningLobby += ShowConnectingPanel;
        PhotonConfig.connectedToServer += HideConnectingPanel;
        PhotonConfig.joinedToLobby += HideConnectingPanel;
    }

    public void ShowConnectingPanel(){
        if(connectingPanel != null){
            connectingPanel.SetActive(true);
        }
    }

    public void HideConnectingPanel(){
        if(connectingPanel != null){
            connectingPanel.SetActive(false);
        }
    }
}