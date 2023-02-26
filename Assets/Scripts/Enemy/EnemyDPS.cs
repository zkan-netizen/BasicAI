
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class EnemyDPS : MonoBehaviour
{
  [SerializeField]
  // private During _duringScript;

  void Start()
  {
    // _duringScript = GetComponent<During>();
    // _duringScript = GameObject.Find("Duringg").GetComponent<During>();



  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Player")
    {
      if (other.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealthComponent))
      {
        playerHealthComponent.TakeDamage(10);
      }
    }
  }


















}
