using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceStones : MonoBehaviour
{
  Transform Magnet;

  float _distance;
  [SerializeField]
  bool _canPull;
  void Start()
  {
    Magnet = GameObject.Find("Magnet").transform;
  }

  void PullObjects()
  {
    if (_canPull == true)
    {
      _distance = Vector3.Distance(transform.position, Magnet.position);
      if (_distance < 5)
      {
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                Magnet.position,
                Time.deltaTime * 10);
      }
    }
  }

  private void Update()
  {
    PullObjects();
  }
}
