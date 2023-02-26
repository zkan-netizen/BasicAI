using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovementSpeed : MonoBehaviour
{
   
private Data _speedData;
[SerializeField]
private Image Ability;
private void Start() {
    _speedData=new Data();
    _speedData.Damage=2%5;
    Debug.Log(_speedData.Damage);
}

   
}
