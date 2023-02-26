using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RotateKnife : MonoBehaviour
{
    [SerializeField]
    private Vector3 Direction;

    int openX;

    float openXdegree;

    [SerializeField]
    private int _objrotatespeed;

    public List<GameObject> Knifes;

    void Start()
    {
        openX = 1;
        Knifes = GameObject.FindGameObjectsWithTag("Knife").ToList();
    }

    void Rotater()
    {
        transform.Rotate(Direction, _objrotatespeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            
            openX += 1;
            Knifes[0].transform.position =
                new Vector3(transform.parent.position.x + openX,
                    transform.position.y,
                    transform.position.z);
            Knifes[1].transform.position =
                new Vector3(transform.parent.position.x - openX,
                    transform.position.y,
                    transform.position.z);
            Knifes[0].transform.rotation = transform.parent.rotation;
             Knifes[1].transform.rotation = transform.parent.rotation;
        }
        Rotater();
    }
}
