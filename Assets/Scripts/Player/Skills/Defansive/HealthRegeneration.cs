using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField]
    private SkillData _healtRegenData;

    private Data _damageData;

    [SerializeField]
    public PlayerHealth _playerHealth;

    [SerializeField]
    private Image Ability;

    private void Start()
    {
        _playerHealth.GetComponent<PlayerHealth>();
        _healtRegenData = new SkillData();
        _damageData = new Data();
        _damageData.Damage = 45; //this part will use to get health regen.
        _healtRegenData.AbilityImage = Ability;
        _healtRegenData.AbilityImage.fillAmount = 0;
        _healtRegenData.AbilityCooldown =12;
    }

    private void AbilityHealthRegen()
    {
        if (_healtRegenData.isCoolDown == false)
        {
            _healtRegenData.AbilityImage.fillAmount = 1;
            _playerHealth.TakeHeal(_damageData.Damage);
        }
        if (_healtRegenData.isCoolDown == true)
        {
            _healtRegenData.AbilityImage.fillAmount -=
                1 / _healtRegenData.AbilityCooldown * Time.deltaTime;
        }
        if (_healtRegenData.AbilityImage.fillAmount <= 0)
        {
            _healtRegenData.AbilityImage.fillAmount = 1;
            _healtRegenData.isCoolDown = false;
        }
        else
        {
            _healtRegenData.isCoolDown = true;
        }
    }

    private void Update()
    {
        AbilityHealthRegen();
    }
}
