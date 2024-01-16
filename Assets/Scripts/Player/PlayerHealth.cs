using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text hpValue;
    [SerializeField] private Image hpImage;
    [SerializeField] private int maxHp;
    public int health;
    void Start()
    {
        health = maxHp;
        UpdateUI();
    }

    private void UpdateUI()
    {
        hpValue.text = health.ToString();
        hpImage.fillAmount = health / (float)maxHp;
    }

    public void DecreaseHealth(int value)
    {
        if (health <= value)
        {
            health = 0;
            Debug.LogWarning(gameObject.name + " is dead!");
        }
        else health -= value;
        UpdateUI();
    }
}
