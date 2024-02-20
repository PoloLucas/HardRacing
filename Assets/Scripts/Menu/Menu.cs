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
        if(gameModeManager.IsOnline){ //Carga el menú directamente en la sala de espera si se juega en línea
            mainPanel.SetActive(false);
            onlineLobby.SetActive(true);
        }
        NetworkConfig.connectingOnline += ShowConnectingPanel;
        NetworkConfig.joiningLobby += ShowConnectingPanel;
        PhotonConfig.connectedToServer += HideConnectingPanel;
        PhotonConfig.joinedToLobby += HideConnectingPanel;
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