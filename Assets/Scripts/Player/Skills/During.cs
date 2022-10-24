// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class During : MonoBehaviour
// {
//   public bool deneme;
//   private Data _duringData;
//   // public static During _duringScript;
//   private GameObject _during;
//   [SerializeField] private List<GameObject> _duringEnemy;
//   public List<GameObject> DuringEnemy
//   {
//     get { return _duringEnemy; }
//   }


//   void Start()
//   {
//     _duringEnemy = new List<GameObject>();
//     _duringData = new Data();
//     _duringData.Damage = 5;


//   }

//   void True(GameObject other)
//   {
//     if (deneme == true)
//     {
//       foreach (var Other in _duringEnemy)
//       {
//         if (
//                   other
//                       .gameObject
//                       .TryGetComponent
//                       <EnemyHealth>(out EnemyHealth enemyHealthComponent)
//               )
//         {

//           enemyHealthComponent.TakeDamage(_duringData.Damage);

//         }
//       }
//     }
//     deneme = false;
//     return;

//   }


//   void Update()
//   {
//     for (int i = 0; i < _duringEnemy.Count; i++)
//     {
//       True(_duringEnemy[i].gameObject);

//     }
//     _duringEnemy.RemoveAll(g => g == null);

//   }

//   // private void OnTriggerEnter(Collider other)
//   // {
//   //   _duringEnemy.RemoveAll(g => g == null);

//   //   if (other.gameObject.name == "Enemy1")
//   //   {


//   //     // _duringEnemy.Add(other.gameObject);
//   //     foreach (var Other in _duringEnemy)
//   //     {
//   //       if (
//   //                 other
//   //                     .gameObject
//   //                     .TryGetComponent
//   //                     <EnemyHealth>(out EnemyHealth enemyHealthComponent)
//   //             )
//   //       {
//   //         // other.name="Enemy1";
//   //         enemyHealthComponent.TakeDamage(_duringData.Damage);



//   //         // gameObject.GetComponent<BoxCollider>().enabled = false;
//   //       }
//   //     }


//   //   }

//   // }
//   public void DuringSkill(GameObject other)
//   {
//     if (other.gameObject.name == "Duringg")
//     {
//       foreach (var Other in _duringEnemy)
//       {
//         if (
//                   other
//                       .gameObject
//                       .TryGetComponent
//                       <EnemyHealth>(out EnemyHealth enemyHealthComponent)
//               )
//         {

//           enemyHealthComponent.TakeDamage(_duringData.Damage);

//         }
//       }

//     }


//   }
//   // public IEnumerator HitPerSecond(Collider other)
//   // {
//   //   if (other.gameObject.name == "During")
//   //   {
//   //     if (
//   //         other
//   //             .gameObject
//   //             .TryGetComponent
//   //             <EnemyHealth>(out EnemyHealth enemyHealthComponent)
//   //     )
//   //     {
//   //       Debug.Log("during");
//   //       enemyHealthComponent.TakeDamage(_duringData.Damage);
//   //       gameObject.GetComponent<BoxCollider>().enabled = false;
//   //     }
//   //   }
//   //   yield return new WaitForSeconds(2f);
//   //   gameObject.GetComponent<BoxCollider>().enabled = true;
//   // }

//   // private void OnTriggerEnter(Collider other)
//   // {
//   //   StartCoroutine(HitPerSecond(other));


//   // }
// }
