using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThrowTrigger : MonoBehaviour
{

  //skill cooldowndayken mermi atmayı bırakacak cooldown dolduğu anda liste yenilenecek mermi atacak tekrar cooldown girilecek.
  [SerializeField]
  private ThrowThree _throwXZ;
  [SerializeField]
  private Image ThrowAbility;
  private Data _throwData;
  [SerializeField]
  private bool _canMove;
  [SerializeField]
  private bool touchTrick;
  void Start()
  {
    _canMove = false;
    _throwData = new Data();
    _throwData.AbilityImage = ThrowAbility;
    _throwData.AbilityImage.fillAmount = 0;
    _throwData.AbilityCooldown = 10;
    _throwData.Damage = 1;

  }
  void ThrowCondition()
  {
    // if (_throwXZ.NearestThreeEnemies.Count <= 2)
    // {
    for (int i = 0; i < _throwXZ.EnemyValue; i++)
    {
      _throwXZ.NearestEnemies();
    }
    // }
  }
  private void AbilityThrow()
  {

    if (_throwData.isCoolDown == false)
    {
      _canMove = true;
      ThrowCondition();//throw conidition sadece cooldown dolunca calısıyor bu  esnada liste 3den küçükse mermiler duruyor.
      _throwData.AbilityImage.fillAmount = 1;

    }
    if (_throwData.isCoolDown == true)
    {
      if (_canMove != false && touchTrick == false)
        _canMove = false;

      _throwData.AbilityImage.fillAmount -= 1 / _throwData.AbilityCooldown * Time.deltaTime;

    }
    if (_throwData.AbilityImage.fillAmount <= 0)
    {
      _throwXZ.NearestThreeEnemies.RemoveAll(Transform => Transform.transform == null);
      _throwData.AbilityImage.fillAmount = 1;
      _throwData.isCoolDown = false;
      touchTrick = true;

    }
    else
    {
      _throwData.isCoolDown = true;


    }

  }

  void BulletDirection()
  {
    // if (_throwXZ.NearestThreeEnemies[0] == null)
    // {
    //   transform.position = transform.parent.position;
    // }
    // if (_throwXZ.NearestThreeEnemies[1] == null)
    // {
    //   transform.position = transform.parent.position;
    // }
    // if (_throwXZ.NearestThreeEnemies[2] == null)
    // {
    //   transform.position = transform.parent.position;
    // }
    // if (_throwXZ.NearestThreeEnemies[0] == null)
    // {
    //   _throwXZ.NearestThreeEnemies.RemoveAll(item => item == null);
    //   for (int i = 0; i < _throwXZ.EnemyValue; i++)
    //   {
    //     _throwXZ.NearestEnemies();
    //   }
    // }
    if (_canMove == true)
    {

      if (this.gameObject.name == "Throw1" && _throwXZ.NearestThreeEnemies[1].position != null)
      {

        transform.LookAt(_throwXZ.NearestThreeEnemies[0]);
        transform.position = Vector3.MoveTowards(transform.position, _throwXZ.NearestThreeEnemies[0].position, Time.deltaTime * 20);

      }

      if (this.gameObject.name == "Throw2" && _throwXZ.NearestThreeEnemies[1].position != null)
      {

        transform.LookAt(_throwXZ.NearestThreeEnemies[1]);
        transform.position = Vector3.MoveTowards(transform.position, _throwXZ.NearestThreeEnemies[1].position, Time.deltaTime * 20);

      }

      if (this.gameObject.name == "Throw3" && _throwXZ.NearestThreeEnemies[2].position != null)
      {
        transform.LookAt(_throwXZ.NearestThreeEnemies[2]);
        transform.position = Vector3.MoveTowards(transform.position, _throwXZ.NearestThreeEnemies[2].position, Time.deltaTime * 20);
        touchTrick = false;
      }

    }


    _throwXZ.NearestThreeEnemies.RemoveAll(item => item == null);
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other
                .gameObject
                .TryGetComponent
                <EnemyHealth>(out EnemyHealth enemyHealthComponent)
        )
    {
      enemyHealthComponent.TakeDamage(_throwData.Damage);
      this.gameObject.transform.position = transform.parent.position;

      // Destroy(this.gameObject);
    }
  }
  void Update()
  {
    Debug.Log(_canMove);
    AbilityThrow();
    BulletDirection();
  }
}
//problem=karakterlerden biri öldüğünde ilk 3 seçimdeki sıra değiştiğinden mermiler duruyor.