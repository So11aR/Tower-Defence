using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    private Transform camera;
    
    void OnEnable()
    {
        camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }

    public void UpdateHealthBar(float current, float max)
    {
        bar.fillAmount = current / max;
    }
}
