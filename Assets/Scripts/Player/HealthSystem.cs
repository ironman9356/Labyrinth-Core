using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    public int playerHealth = 100;
    public Slider healthBar;

    public Gradient healthBarColor;

    public Image fill;

    public TextMeshProUGUI healthNumber;

    private void Start()
    {
        healthBar.value = playerHealth;
        fill.color = healthBarColor.Evaluate(1f);
        healthNumber.text = playerHealth.ToString();
    }
    private void Update()
    {
        if (playerHealth == 0)
        {
            Debug.Log("Game Over");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (playerHealth > 0)
            {
                playerHealth -= 10;
                Debug.Log(playerHealth);
                SetHealth(playerHealth);
            }
        }
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
        healthNumber.text = health.ToString();
        fill.color = healthBarColor.Evaluate(healthBar.normalizedValue);
    }



}
