using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 50f;
    bool isDead = false;
    public UnityAction <float> onDamaged;
    public UnityAction<float> onHealed;
    public UnityAction onDie;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (onDamaged != null)
        {
            onDamaged.Invoke(damage);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float healAmount)
    {
        float healthBefore = currentHealth;
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        float trueHealAmount = currentHealth - healthBefore;
        if (trueHealAmount > 0f && onHealed != null)
        {
            onHealed.Invoke(trueHealAmount);
        }
    }

    void Die()
    {
        if (isDead)
            return;

        if (currentHealth <= 0f)
        {
            if (onDie != null)
            {
                isDead = true;
                onDie.Invoke();
                //Destroy(gameObject);
            }
        }
    }
}
