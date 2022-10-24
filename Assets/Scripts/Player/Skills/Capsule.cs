using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Capsule : MonoBehaviour
{

  private Data _capsuleData;
  private SkillData _capsuleSkill;
  [SerializeField]
  private Image Ability;
  [SerializeField]
  private Rigidbody _enemy;

  [SerializeField]
  float _throwForce;
  void Start()
  {

    _capsuleData = new Data();
    _capsuleData.AbilityImage = Ability;
    _capsuleData.AbilityImage.fillAmount = 0;
    _capsuleData.AbilityCooldown = 5;
  }

  private void AbilityCapsule()
  {

    if (_capsuleData.isCoolDown == false)
    {
      gameObject.GetComponent<SphereCollider>().isTrigger = true;

      _capsuleData.AbilityImage.fillAmount = 1;
      // if (_enemy.gameObject != null)
      // {
      //   // _enemy.constraints = RigidbodyConstraints.None;
      // }
    }
    if (_capsuleData.isCoolDown == true)
    {


      if (gameObject.GetComponent<SphereCollider>().isTrigger != false)
        gameObject.GetComponent<SphereCollider>().isTrigger = false;
      _capsuleData.AbilityImage.fillAmount -= 1 / _capsuleData.AbilityCooldown * Time.deltaTime;
      // _enemy.constraints = RigidbodyConstraints.FreezePosition;//eğer if içine alırsan _enemy.gameobject!=null şeklinde hata almazsın.
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
  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.GetComponent<Rigidbody>() == null)
    {
      other.gameObject.AddComponent<Rigidbody>();
    }
    if (other.gameObject.name == "Enemy1")
    {

      _enemy = other.gameObject.GetComponent<Rigidbody>();
      // _enemy.drag = 5f;
      _enemy.AddForce(-other.transform.forward * _throwForce);
      // Destroy(_enemy,3f);
      Debug.Log("touching");
    //eğer capsule değiyorlarsa ama skill cooldown=true ise positionları freezle.
    }


  }
  private void FixedUpdate()
  {
    AbilityCapsule();
  }
}
