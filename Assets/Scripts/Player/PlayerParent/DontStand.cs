using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontStand : MonoBehaviour
{
   public PlayerHealth _playerHealth;
    [SerializeField]
    private GameObject Player;

    private float Timer;

    private bool isMoving;

    [SerializeField]
    private Slider CheckLocationSlider;

    //This code is checking player is standing or not.If Player is standing,
    //it has to move again in 7 sec.İf coudln't do this it will destroy by bomb or something.(not decided what will destroy.)
    private Vector3 lastPos;

    private void Start()
    {
        CheckLocationSlider.value = 0;
        CheckLocationSlider.maxValue = 7;
    }

    void LocationSlider()
    {
        if (isMoving == true)
        {
            CheckLocationSlider.value -= Time.deltaTime;
        }
        else
        {
            CheckLocationSlider.value += Time.deltaTime;
        }
    }

    void isStanding()
    {
        if (Player.transform.position.Equals(lastPos))
        {
            Debug.Log("hareket etmiyor");
            isMoving = false;
        }
        else
        {
            isMoving = true;
            lastPos = Player.transform.position;
        }
    }

    void DangerStand()
    {
        if (CheckLocationSlider.value == 7)
        {
            Timer += Time.deltaTime;
            int _timer=(int) Timer;
            if((int) Timer==2){
                _playerHealth.TakeDamage(200);
                Timer=0;
            }
            // do{
            //    _playerHealth.TakeDamage(60);
            //    Timer=0;

            // }
            // while(Timer==3);
        }
    }

    private void Update()
    {
        Debug.Log("time"+(int)Timer);
        if (CheckLocationSlider.value == CheckLocationSlider.maxValue)
        {
            Debug.Log("- hp azalt");
        }
        DangerStand();
        isStanding();
        LocationSlider();
    }
}
