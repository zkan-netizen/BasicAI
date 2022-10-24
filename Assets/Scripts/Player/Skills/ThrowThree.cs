using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ThrowThree : MonoBehaviour
{

  Transform _nearestEnemy;


  public List<GameObject> NearEnemy;
  public List<Transform> NearestThreeEnemies;

  public int EnemyValue = 3;//to pick first 3 enemy
  void Start()
  {
    NearEnemy = GameObject.FindGameObjectsWithTag("Enemy").ToList();


    for (int i = 0; i < EnemyValue; i++)
    {
      NearestEnemies();
    }

  }
  public void NearestEnemies()
  {
    float _lowestDistance = Vector3.Distance(transform.position, NearEnemy[0].transform.position);
    for (int z = 0; z < NearEnemy.Count; z++)
    {
      if (Vector3.Distance(transform.position, NearEnemy[z].transform.position) < _lowestDistance)
      {
        _lowestDistance = Vector3.Distance(transform.position, NearEnemy[z].transform.position);

        _nearestEnemy = NearEnemy[z].transform;

      }
    }
    NearEnemy.Remove(_nearestEnemy.gameObject);
    NearestThreeEnemies.Add(_nearestEnemy);
    NearestThreeEnemies.RemoveAll(Transform => Transform.transform == null);
  }
  void ChildToEnemy()
  {

    // if (_canMove == true)
    // {
    //   transform.GetChild(0).position = Vector3.MoveTowards(transform.GetChild(0).position, firstEnemy, Time.deltaTime * 20);
    //   transform.GetChild(1).position = Vector3.MoveTowards(transform.GetChild(1).position, secondEnemy, Time.deltaTime * 20);
    //   transform.GetChild(2).position = Vector3.MoveTowards(transform.GetChild(2).position, thirdEnemy, Time.deltaTime * 20);
    // }



    // for (int i = 0; i < NearestThreeEnemies.Count; i++)
    // {
    //   if (NearestThreeEnemies[i].gameObject == null)
    //   {

    //   }
    // }

  }

}
