using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ThrowThree : MonoBehaviour
{
    public ThrowTrigger _throwTrigger;

    public List<GameObject> BulletList;

    public List<GameObject> NearEnemy;

    public List<Transform> NearestThreeEnemies;

    public SkillData _throwData;

    public Data _damageData;

    [SerializeField]
    private Image ThrowAbility;

    Transform _nearestEnemy;

    public int EnemyValue = 5; //to pick first 3 enemy

    public bool _canMove;

    public bool isHit;

    void Start()
    {
        _damageData = new Data();
        _throwTrigger.GetComponent<ThrowTrigger>();
        BulletList = GameObject.FindGameObjectsWithTag("Bullet").ToList();

        //--------------------------------------
        _throwData = new SkillData();
        _throwData.AbilityImage = ThrowAbility;
        _throwData.AbilityImage.fillAmount = 0;
        _throwData.AbilityCooldown = 3;
        _damageData.Damage = 1;
        NearEnemy = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        for (int i = 0; i < EnemyValue; i++)
        {
            NearestEnemies(); //--------------------------------------bu kısım skilleri en başta denemek için sonrasında kaldırılacak
        }
    }

    public void NearestEnemies()
    {
        float _lowestDistance =
            Vector3
                .Distance(transform.position, NearEnemy[0].transform.position);
        for (int z = 0; z < NearEnemy.Count; z++)
        {
            if (
                Vector3
                    .Distance(transform.position,
                    NearEnemy[z].transform.position) <
                _lowestDistance
            )
            {
                _lowestDistance =
                    Vector3
                        .Distance(transform.position,
                        NearEnemy[z].transform.position);

                _nearestEnemy = NearEnemy[z].transform;
            }
        }
        NearEnemy.Remove(_nearestEnemy.gameObject);
        NearestThreeEnemies.Add (_nearestEnemy);
    }

    //------------------------------------
    void ThrowCondition()
    {
        // if (_throwXZ.NearestThreeEnemies.Count <= 2)
        // {
        for (int i = 0; i < EnemyValue; i++)
        {
            NearestEnemies();
        }
        // }
    }

    //------------------------------------
    private void AbilityThrow()
    {
        //cooldoownda olmadığında 3 mermi en yakın 3 rakipe gidecek cooldown true dönse bile bu işlem sağlıklı bir şekilde sonlanıcak.cooldown tekrar
        //dolduğunda tekrar aynı işlem tekrarlanacak
        if (_throwData.isCoolDown == false)
        {
            // ThrowCondition();
            //eğer can move false ise mermiler playera dönmeli ve setactive false olmalı.
            //throw conidition sadece cooldown dolunca calısıyor bu  esnada liste 3den küçükse mermiler duruyor.
            _throwData.AbilityImage.fillAmount = 0.9f;
        }

        if (_throwData.isCoolDown == true)
        {
            _throwData.AbilityImage.fillAmount -=
                1 / _throwData.AbilityCooldown * Time.deltaTime;
        }

        //------------------------------------
        if (_throwData.AbilityImage.fillAmount <= 0)
        {
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].gameObject.GetComponent<MeshRenderer>().enabled =
                    true;
                BulletList[i].gameObject.SetActive(true);
            }
            ThrowCondition();
            isHit = false;
            _canMove = true;
            _throwData.AbilityImage.fillAmount = 1;
            _throwData.isCoolDown = false;
        }
        else
        {
            _throwData.isCoolDown = true;
        }
    }

    //------------------------------------
    //------------------------------------
    void Update()
    {
        AbilityThrow();
    }
}
