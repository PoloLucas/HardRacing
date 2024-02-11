using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomConfig : MonoBehaviourPunCallbacks{
    public Transform vehicleParent;

    void Awake(){
        GameObject newVehicle = PhotonNetwork.Instantiate("Vehicle2", new Vector3(23.48f, 0.5f, 120.2f), new Quaternion(0f,-0.0381136537f,0f,0.999273479f));
        newVehicle.transform.parent = vehicleParent;
        //Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber);
    }
}