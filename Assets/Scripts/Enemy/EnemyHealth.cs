using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject _floatingTextPrefab;

    private Vector3 spawningpos;

    private Data Enemy1Data;

    // public Transform randomT=new Vector3( Random.Range(-3, +3),(this.transform.position.y),(transform.position.z));
    private void Awake()
    {
        Enemy1Data = new Data();
    }

    void Start()
    {
        _floatingTextPrefab = GameObject.Find("FloatingTextParent");

        Enemy1Data.Health = 15;
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
        spawningpos =
            new Vector3(transform.position.x + Random.Range(-3, 3),
                transform.position.y,
                transform.position.z);

        GameManager._gameManager.ShowDamage(amount.ToString(),this.transform);

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
