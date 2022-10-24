using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  [SerializeField]
  Transform Material;
  float _materialDistance;
  void Start()
  {
    Material = GameObject.Find("ExperienceStone").transform;
  }
  void TakeObject()
  {
    _materialDistance = Vector3.Distance(transform.position, Material.position);
    if (_materialDistance < 2)
    {
      Material.transform.position = Vector3.MoveTowards(transform.position, Material.position, Time.deltaTime * 5);
    }
  }
  void Update()
  {
    TakeObject();
  }
}
