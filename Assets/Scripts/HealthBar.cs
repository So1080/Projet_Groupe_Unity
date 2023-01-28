using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    public Camera cam;

    private void Start()
    {
        //Solyane
        cam = (Camera) GetComponent("MainCamera");

    }

    public void UpdateHealthBar(int health, int healthMax)
    {
        float hlt = (float)health;
        float maxHlt = (float)healthMax;
        float ratio = hlt / maxHlt;
        //Debug.Log(" HEALTH " + hlt + " and HEALTHMAX " + maxHlt + " THE RATIO IS " + ratio);
        healthBar.fillAmount = ratio;
    }

    void Update()
    {
        if (gameObject.tag == "HealthBar")
        {

            transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        }
    }
}
