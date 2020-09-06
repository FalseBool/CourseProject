using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HeatlhBar : MonoBehaviour
{
    public Slider healthBarSlider;
    private Health playerHealth;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        playerHealth = PlayerManager.instance.Player.GetComponent<Health>();
        text.text = Mathf.Round(playerHealth.currentHealth).ToString();
        healthBarSlider.value = playerHealth.currentHealth/playerHealth.maxHealth;
        playerHealth.onDamaged += OnDamageTaken;
        playerHealth.onDie += OnDie;
        playerHealth.onHealed += OnHealTaken;
    }
    void OnDamageTaken(float damage)
    {
        healthBarSlider.value -= damage / playerHealth.maxHealth;
        text.text = Mathf.Round(playerHealth.currentHealth).ToString();
    }
    void OnHealTaken(float heal)
    {
        healthBarSlider.value += heal / playerHealth.maxHealth;
        text.text = Mathf.Round(playerHealth.currentHealth).ToString();
    }
    void OnDie()
    {
        healthBarSlider.value = 0;
        playerHealth.onDamaged -= OnDamageTaken;
        playerHealth.onDie -= OnDie;
        playerHealth.onHealed -= OnDamageTaken;
    }
}
