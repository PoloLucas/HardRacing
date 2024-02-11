using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernamePanel : MonoBehaviour{
    [SerializeField]private GameObject continueButton;

    public void HideButtonAtInvalidString(string name){
        if(name.Length <= 12 && name.Length > 0){
            continueButton.SetActive(true);
        }else{
            continueButton.SetActive(false);
        }
    }
}