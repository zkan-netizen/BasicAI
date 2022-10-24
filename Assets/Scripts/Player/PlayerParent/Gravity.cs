using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _playerRb;
  

    void GravityCondition()
    {
        if (this.transform.position.y <2)
        {
           _playerRb.useGravity=false;
           this.gameObject.GetComponent<BoxCollider>().enabled=true;
        }
       

       
    }

    void Update()
    {
        GravityCondition();
    }
}
