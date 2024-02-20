using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkVehicle : MonoBehaviour{
    [SerializeField]private List<MonoBehaviour> scriptsToIgnore = new List<MonoBehaviour>();
    [SerializeField]private GameModeManager gameModeManager;
    private PhotonView photonView;
    private Vector3 realPosition = Vector3.zero;
    private Quaternion realRotation = Quaternion.identity;

    void Start(){
        photonView = GetComponent<PhotonView>();
        if(gameModeManager.IsOnline && !photonView.IsMine){ //Desactiva los componentes innecesarios para quienes no controlan este vehículo
            foreach(var script in scriptsToIgnore){
                script.enabled = false;
            }
        }
    }

    /*void Update(){
        if(!photonView.IsMine && gameModeManager.IsOnline){
            transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
            transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
        }
    }

    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info){
        if(stream.IsWriting){
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }else{
            realPosition = (Vector3) stream.ReceiveNext();
            realRotation = (Quaternion) stream.ReceiveNext();
        }
    }*/
}