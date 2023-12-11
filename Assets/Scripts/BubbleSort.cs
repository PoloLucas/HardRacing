using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : MonoBehaviour{
    public void SortByDistance(List<Transform> values){
        for(int i = 1; i < values.Count - 1; i++){
            for(int j = 0; j < values.Count - 1; j++){
                float value1 = values[j].GetComponent<Vehicle>().traveledDistance;
                float value2 = values[j + 1].GetComponent<Vehicle>().traveledDistance;
                if(value1.CompareTo(value2) < 0){
                    Transform temp = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = temp;
                }
            }
        }
    }

    public float InverseLerp(Vector3 a, Vector3 b, Vector3 value){
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
    }
}