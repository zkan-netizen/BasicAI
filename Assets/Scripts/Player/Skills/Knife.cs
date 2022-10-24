using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
  private Data _knifeData;
  void Start()
  {
    _knifeData = new Data();
    _knifeData.Damage = 15;
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Enemy1")
    {
      if (other
              .gameObject
              .TryGetComponent
              <EnemyHealth>(out EnemyHealth enemyHealthComponent)
      )
      {

        enemyHealthComponent.TakeDamage(_knifeData.Damage);

        Debug.Log("knife");
      }
    }
  }
}
