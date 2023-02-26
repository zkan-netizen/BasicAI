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

    // private Data _throwData;
    public Data ThrowData;

    void Start()
    { 
        ThrowData = new Data();
        ThrowData.Damage = 1;
        gameObject.GetComponent<MeshRenderer>().enabled=false;
    }

    void BulletDirection()
    {
        if (_throwXZ._canMove == true && _throwXZ.isHit == false)
        {
            if (this.gameObject == _throwXZ.BulletList[0])
            {
                transform.LookAt(_throwXZ.NearestThreeEnemies[0]);
                transform.position =
                    Vector3
                        .MoveTowards(transform.position,
                        _throwXZ.NearestThreeEnemies[0].position,
                        Time.deltaTime * 20);
            }

            //------------------------------------
            if (this.gameObject == _throwXZ.BulletList[1])
            {
                transform.LookAt(_throwXZ.NearestThreeEnemies[1]);
                transform.position =
                    Vector3
                        .MoveTowards(transform.position,
                        _throwXZ.NearestThreeEnemies[1].position,
                        Time.deltaTime * 20);
            }

            //------------------------------------
            if (this.gameObject == _throwXZ.BulletList[2])
            {
                transform.LookAt(_throwXZ.NearestThreeEnemies[2]);
                transform.position =
                    Vector3
                        .MoveTowards(transform.position,
                        _throwXZ.NearestThreeEnemies[2].position,
                        Time.deltaTime * 20);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (
            other
                .gameObject
                .TryGetComponent
                <EnemyHealth>(out EnemyHealth enemyHealthComponent)
        )
        {
            // if(this.gameObject==_throwXZ.BulletList[2]){
            //     if(other.gameObject.tag=="Enemy")
            //        _throwXZ._canMove=false;
            // }
            
            gameObject.SetActive(false);
            // gameObject.GetComponent<MeshRenderer>().enabled=false;
            enemyHealthComponent.TakeDamage(ThrowData.Damage);
            gameObject.transform.position = transform.parent.position;
            _throwXZ
                .NearestThreeEnemies
                .RemoveAll(GameObject => GameObject == null);
                // _throwXZ.isHit = true;
        }
        //   _throwXZ.isHit = false;
    }

    void Update()
    {
        BulletDirection();
    }
}
//problem=karakterlerden biri öldüğünde ilk 3 seçimdeki sıra değiştiğinden mermiler duruyor.
