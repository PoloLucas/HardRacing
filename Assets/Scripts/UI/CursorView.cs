using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorView : MonoBehaviour{
    public void HideCursor(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowCursor(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}