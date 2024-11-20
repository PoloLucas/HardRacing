using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernamePanel : MonoBehaviour{
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject hintText;

    //Permite o no al jugador confirmar su nombre si cumple los requisitos de cantidad de caracteres
    public void HideButtonAtInvalidString(string name){
        if(name.Length >= 3 && name.Length <= 12){
            continueButton.interactable = true;
            hintText.SetActive(false);
        }else{
            continueButton.interactable = false;
            hintText.SetActive(true);
        }
    }
}