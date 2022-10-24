using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1Enemies : MonoBehaviour
{
  public GameObject[] Childs;



  public void Awake()
  {

    Childs = new GameObject[transform.childCount];
    for (int i = 0; i < transform.childCount; i++)
    {

      Childs[i] = transform.GetChild(i).gameObject;
      Childs[i].gameObject.AddComponent<EnemyHealth>();
      Childs[i].gameObject.AddComponent<Follow>();
      Childs[i].gameObject.AddComponent<EnemyCollision>();
      Childs[i].gameObject.AddComponent<OnGoing>();
      // Childs[i].gameObject.AddComponent<Rigidbody>();
      Childs[i].gameObject.GetComponent<Transform>();


    }
  }

}
