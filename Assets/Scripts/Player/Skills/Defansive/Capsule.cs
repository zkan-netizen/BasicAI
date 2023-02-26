using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    // [SerializeField]
    // private CapsuleCooldown _capsuleParent;
    [SerializeField]
    private Rigidbody _enemy;

    [SerializeField]
    float _throwForce;

    private void Start()
    {
        _enemy.GetComponent<GameObject>();
    }

    void EnemyRigid(GameObject other)
    {
        _enemy = other.GetComponent<Rigidbody>();
        _enemy.gameObject.GetComponent<GameObject>();
        other = GameObject.Find("Enemy1");
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.GetComponent<Rigidbody>() == null)
        // {
        //     other.gameObject.AddComponent<Rigidbody>();
        // }
        if (other.gameObject.name == "Enemy1")
        {
            EnemyRigid(_enemy.gameObject);
            _enemy = other.gameObject.GetComponent<Rigidbody>();

            _enemy.AddForce(-other.transform.forward * _throwForce);
            Debug.Log("calisti11");

            //eğer capsule değiyorlarsa ama skill cooldown=true ise positionları freezle.
        }
    }
}
