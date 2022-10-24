using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

  public GameObject _floatingTextPrefab;

  private Data Enemy1Data;

  private void Awake()
  {
    Enemy1Data = new Data();
  }

  void Start()
  {

    _floatingTextPrefab = GameObject.Find("FloatingTextParent");

    Enemy1Data.Health = 10;
  }

  // void ShowDamage(string text)
  // {
  //   if (_floatingTextPrefab)
  //   {
  //     GameObject prefab =
  //         Instantiate(_floatingTextPrefab,
  //         this.transform.position,
  //         Quaternion.identity);
  //     prefab.GetComponentInChildren<TextMesh>().text = text;


  //   }
  // }

  public void TakeDamage(int amount)
  {
    GameManager._gameManager.ShowDamage(amount.ToString(),this.transform);
    // Debug.Log(Enemy1Data.Health);
    Enemy1Data.Health -= amount;
    if (Enemy1Data.Health <= 0)
    {
      Debug.Log("EnemyIsDead");

      // if(this.gameObject!=null)
      Destroy(this.gameObject);
      //We are dead
      //Play dead anim
      //Show gameover screen
    }
  }
}
