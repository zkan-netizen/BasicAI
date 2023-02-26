using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ThrowFront : MonoBehaviour
{

  private Data _throwData;
  float _enemyDistance;
  [SerializeField]



  //Problem =When I try to hit enemies with distance,Code choosing first in hirerachy.lv1enemiesden gameobjecti cağırıp foreeach döngüsünde her gameobjectin transformu alınabilir.
  void Start()
  {
    _throwData = new Data();
    _throwData.Damage = 7; 
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

        enemyHealthComponent.TakeDamage(_throwData.Damage);
       
        this.transform.position = GameObject.Find("Player").transform.position;

      }
    }
  }
}
