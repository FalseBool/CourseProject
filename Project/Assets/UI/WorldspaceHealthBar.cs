using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldspaceHealthBar : MonoBehaviour
{
    public Health health;
    public Slider healthBarSlider;
    public Transform healthBarPivot;
    public bool hideFullHealthBar = true;
    private Camera playerCamera;
    private void Start()
    {
        playerCamera = PlayerManager.instance.Player.GetComponentInChildren<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        healthBarSlider.value = health.currentHealth / health.maxHealth;

        if (playerCamera != null)
        {
            healthBarPivot.LookAt(playerCamera.transform);
        }

        if (hideFullHealthBar) {
            healthBarPivot.gameObject.SetActive(healthBarSlider.value != 1 && healthBarSlider.value > 0);
        }

    }


}
