using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmmoBar : MonoBehaviour
{
    private Slider ammoBarSlider;
    private Gun playerGun;
    private TextMeshProUGUI text;
    //private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        playerGun = PlayerManager.instance.Player.GetComponentInChildren<Gun>();
        ammoBarSlider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = Mathf.Floor(playerGun.currentAmmo).ToString();
        ammoBarSlider.value = playerGun.currentAmmo / playerGun.maxAmmo;
    }
}
