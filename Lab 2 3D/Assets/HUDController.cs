using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI maxHealth;
    [SerializeField] private TextMeshProUGUI currentHealth;
    [SerializeField] private TextMeshProUGUI XZCords;
    [SerializeField] private TextMeshProUGUI yAngle;
    [SerializeField] private Transform target;
    private void Start()
    {
        maxHealth.text = PlayerHealthDataStore.getInstance().getMaxHealth().ToString();
        updateHealthDetails();
        UpdateTimerDisplay();
        updateCharacterXYZValues();
    }
    private void Update()
    {
        UpdateTimerDisplay();
        updateHealthDetails();
        updateCharacterXYZValues();
    }
    private void updateHealthDetails()
    {
        currentHealth.text = PlayerHealthDataStore.getInstance().getCurrentHealth().ToString();
    }
    private void updateCharacterXYZValues()
    {
        if (!target)
            return;
        XZCords.text = $"{Math.Round(target.position.x, 2)}, {Math.Round(target.position.z, 2)}";
        yAngle.text = ((int) Math.Round((target.eulerAngles.y + 360) % 360)).ToString() + " Deg";
    }
    private void UpdateTimerDisplay()
    {
        timerText.text = GameTimeStore.getInstance().updateTime(Time.deltaTime).getCurrentTime();
    }
}









