using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public PlayerHealth playerHealth;

    // public Image FillImage;

    [SerializeField]
    private Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void SliderAmount()
    {
        float FillValue = playerHealth.PlayerData.Health / playerHealth.MaxHealth;
        _slider.value = FillValue;
    }

    private void Update()
    {
       
        SliderAmount();
    }
}
