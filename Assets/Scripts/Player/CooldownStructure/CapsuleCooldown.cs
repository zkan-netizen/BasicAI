using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CapsuleCooldown : MonoBehaviour
{
    private SkillData _capsuleData;

    [SerializeField]
    private Image Ability;

    private GameObject child;

    float speed;

    public bool CanPush;

    void Start()
    {
        child = transform.GetChild(0).gameObject;
        _capsuleData = new SkillData();
        _capsuleData.AbilityImage = Ability;
        _capsuleData.AbilityImage.fillAmount = 0;
        _capsuleData.AbilityCooldown = 5;

        //------
        transform.parent.gameObject.GetComponent<NavMeshAgent>().radius = .67f;
    }

    void BangFunction(bool CanPush)
    {
        // Diameter;
        if (CanPush == true)
        {
            transform.parent.gameObject.GetComponent<NavMeshAgent>().radius =
                Mathf
                    .Lerp(transform
                        .parent
                        .gameObject
                        .GetComponent<NavMeshAgent>()
                        .radius,
                    5f,
                    .1f);
            StartCoroutine(BiggerFalse());
        }

        if (CanPush == false)
        {
            transform.parent.gameObject.GetComponent<NavMeshAgent>().radius =
                .67f;
        }
    }

    IEnumerator BiggerFalse()
    {
        yield return new WaitForSeconds(.75f);
        CanPush = false;
        Debug.Log (CanPush);
    }

    private void AbilityCapsule()
    {
        if (_capsuleData.isCoolDown == false)
        {
            CanPush = true;
            Debug.Log (CanPush);
            // BangFunction(5);
        }
        if (
            _capsuleData.isCoolDown == true &&
            transform.parent.gameObject.GetComponent<NavMeshAgent>().radius != 5
        )
        {
            _capsuleData.AbilityImage.fillAmount -=
                1 / _capsuleData.AbilityCooldown * Time.deltaTime;
            // BangFunction(0.67f);
            // if (child.gameObject.GetComponent<MeshCollider>().isTrigger == true)
            //     child.gameObject.GetComponent<MeshCollider>().isTrigger = false;
            // _enemy.constraints =  bodyConstraints.FreezePosition;//eğer if içine alırsan _enemy.gameobject!=null şeklinde hata almazsın.
        }
        if (_capsuleData.AbilityImage.fillAmount <= 0)
        {
            _capsuleData.AbilityImage.fillAmount = 1;

            _capsuleData.isCoolDown = false;
        }
        else
        {
            _capsuleData.isCoolDown = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AbilityCapsule();
    }

    private void FixedUpdate()
    {
        BangFunction (CanPush);
    }
}
