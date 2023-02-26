using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;

    public Data PlayerData;

    Color colour;

    void Start()
    {
        MaxHealth = 1000;
        PlayerData.Health = 1000;
    }

    public void TakeDamage(int amount)
    {
        GameManager._gameManager.ShowDamage(amount.ToString(), this.transform);
        PlayerData.Health -= amount;
        if (PlayerData.Health <= 0)
        {
            PlayerData.Health = 0;
            Debug.Log("Öldük");
            //We are dead
            //Play dead anim
            //Show gameover screen
        }
    }

    public void TakeHeal(int amount)
    {
        GameManager._gameManager.ShowHeal(amount.ToString(), this.transform);

        PlayerData.Health += amount;
        if (PlayerData.Health > MaxHealth)
        {
            PlayerData.Health = ((int) MaxHealth);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            TakeHeal(55);
        }
    }
}
