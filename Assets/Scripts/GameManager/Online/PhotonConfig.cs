using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class PhotonConfig : MonoBehaviourPunCallbacks{
    public static PhotonConfig instance;
    public delegate void ConnectedToServer();
    public delegate void JoinedToLobby();
    public static ConnectedToServer connectedToServer;
    public static JoinedToLobby joinedToLobby;

    void Awake(){
        DontDestroyOnLoad(this);
        if(instance == null){ //Se asegura que solo haya un objeto de este tipo
            instance = this;
            NetworkConfig.connectingOnline += ConnectToServer;
            NetworkConfig.disconnectingOnline += DisconnectToServer;
            NetworkConfig.joiningLobby += JoinLobby;
            NetworkConfig.loadingLevel += LoadLevel;
        }else{
            Destroy(gameObject);
        }
    }

    //Se conecta a los servidores de Photon
    public void ConnectToServer(){
        if(!PhotonNetwork.IsConnected){
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    //Si la conexión fue exitosa, activa el evento
    public override void OnConnectedToMaster(){
        connectedToServer();
        Debug.Log("Conectado al Servidor");
    }

    //Se desconecta del servidor
    public void DisconnectToServer(){
        PhotonNetwork.Disconnect();
        Debug.Log("Desconectado del Servidor");
    }

    //Se una a una sala de espera
    public void JoinLobby(){
        PhotonNetwork.JoinLobby();
    }

    //Si ya se unió a una sala de espera, crear una sala de juego
    public override void OnJoinedLobby(){
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions {MaxPlayers = 10}, TypedLobby.Default);
    }

    //Si ya se unió a una sala de juego, activa el evento
    public override void OnJoinedRoom(){
        joinedToLobby();
        Debug.Log("Conectado al Lobby");
    }

    //Carga una escena en el servidor
    public void LoadLevel(string levelName){
        PhotonNetwork.LoadLevel(levelName);
    }
}