using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour{
    [SerializeField]private GameModeManager gameModeManager;
    [SerializeField]private GameObject titlePanel;
    [SerializeField]private GameObject mainPanel;
    [SerializeField]private GameObject onlineLobby;
    [SerializeField]private GameObject connectingPanel;

    void Awake(){
        if(gameModeManager.IsOnline){ //Carga el menú directamente en la sala de espera si se juega en línea
            titlePanel.SetActive(false);
            onlineLobby.SetActive(true);
        }else if(gameModeManager.IsTitleStarted){
            titlePanel.SetActive(false);
            mainPanel.SetActive(true);
        }
        NetworkConfig.connectingOnline += ShowConnectingPanel;
        NetworkConfig.joiningLobby += ShowConnectingPanel;
        PhotonConfig.connectedToServer += HideConnectingPanel;
        PhotonConfig.joinedToLobby += HideConnectingPanel;
    }

    public void TitleStart(){
        gameModeManager.IsTitleStarted = true;
    }

    //Muestra un aviso que impide al jugador interactuar con el menú hasta realizarse exitosamente la conexión
    public void ShowConnectingPanel(){
        if(connectingPanel != null){
            connectingPanel.SetActive(true);
        }
    }

    //Quita el aviso y permite al jugador interactuar nuevamente con el menú
    public void HideConnectingPanel(){
        if(connectingPanel != null){
            connectingPanel.SetActive(false);
        }
    }
}