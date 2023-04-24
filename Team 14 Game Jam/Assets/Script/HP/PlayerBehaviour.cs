using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public PostProcessingTest PPT;

    void Start()
    {
        //GameManager.gameManager.playerHealth.Health = 100;
    }
    public TextMeshProUGUI healthDisplay;

    void Update()
    {
        float currentHealth = GameManager.gameManager.playerHealth.Health;
        float currentMaxHealth = GameManager.gameManager.playerHealth.MaxHealth;
        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            PPT.lessSaturation();
            PlayerTakeDmg(10);
            Debug.Log("PlayerHealth: " + GameManager.gameManager.playerHealth.Health.ToString());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerHeal(25);
            Debug.Log("PlayerHealth: " + GameManager.gameManager.playerHealth.Health.ToString());
        }
        if (healthDisplay != null)
        {
            healthDisplay.SetText(currentHealth + " / " + currentMaxHealth);
        }
    }



    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Bullet")
        {
            PlayerTakeDmg(5);
            
            Debug.Log("PlayerHealth: " + GameManager.gameManager.playerHealth.Health.ToString());
            if (GameManager.gameManager.playerHealth.Health <= 0)
            {
                Debug.Log("Dead");
            }
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager.playerHealth.DmgUnit(dmg);
    }
    private void PlayerHeal(int healing)
    {
        GameManager.gameManager.playerHealth.HealUnit(healing);
    }
    public void DestroyUnit()
    {
         Destroy(gameObject);
        
    }

}
