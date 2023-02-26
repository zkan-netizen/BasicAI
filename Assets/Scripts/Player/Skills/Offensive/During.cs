using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class During : MonoBehaviour
{
    private SkillData _duringData;

    private Data _damageData;

    [SerializeField]
    private Image Ability;

    void Start()
    {
        _damageData = new Data();
        _duringData = new SkillData();
        _damageData.Damage = 2;
        _duringData.AbilityImage = Ability;
        _duringData.AbilityImage.fillAmount = 0;
        _duringData.AbilityCooldown = 1;
    }

    private void AbilityDuring()
    {
        if (_duringData.isCoolDown == false)
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            _duringData.AbilityImage.fillAmount = 1;
        }
        if (_duringData.isCoolDown == true)
        {
            if (gameObject.GetComponent<BoxCollider>().isTrigger != true)
                gameObject.GetComponent<BoxCollider>().isTrigger = true;
            _duringData.AbilityImage.fillAmount -=
                1 / _duringData.AbilityCooldown * Time.deltaTime;
        }
        if (_duringData.AbilityImage.fillAmount <= 0)
        {
            _duringData.AbilityImage.fillAmount = 1;
            _duringData.isCoolDown = false;
        }
        else
        {
            _duringData.isCoolDown = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (
            other
                .gameObject
                .TryGetComponent
                <EnemyHealth>(out EnemyHealth enemyHealthComponent)
        )
        {
            Debug.Log("lol");
            enemyHealthComponent.TakeDamage(_damageData.Damage);
        }
    }

    private void FixedUpdate()
    {
        AbilityDuring();
    }
}
