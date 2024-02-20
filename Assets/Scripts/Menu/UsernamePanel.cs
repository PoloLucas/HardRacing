using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernamePanel : MonoBehaviour{
    [SerializeField]private GameObject continueButton;

    //Permite o no al jugador confirmar su nombre si cumple los requisitos de cantidad de caracteres
    public void HideButtonAtInvalidString(string name){
        if(name.Length <= 12 && name.Length > 0){
            continueButton.SetActive(true);
        }else{
            continueButton.SetActive(false);
        }
    }
}