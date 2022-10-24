using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGoing : MonoBehaviour
{
  private Data _duringData;
  void Start()
  {

    _duringData = new Data();
    _duringData.Damage = 5;


  }
  void OngoingDamage(GameObject other)
  {

    if (
                  other
                      .gameObject
                      .TryGetComponent
                      <EnemyHealth>(out EnemyHealth enemyHealthComponent)
              )
    {

      enemyHealthComponent.TakeDamage(_duringData.Damage);

    }

  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Duringg")
      OngoingDamage(this.gameObject);
  }
}
