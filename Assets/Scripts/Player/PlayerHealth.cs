using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float maxHeatlh;
    [SerializeField] float health = 200;
    [SerializeField] Image heatlhBar;
    [SerializeField] TextMeshProUGUI heatlhText;

    void Start()
    {
        maxHeatlh = health;
        UpdateCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        this.health -= damage;
        UpdateCanvas();
        if (this.health <= 0)
        {
            Destroy(gameObject);
            DeathHandler.FindObjectOfType<DeathHandler>().HandleDeath();
        }
    }

    public void UpdateCanvas()
    {
        heatlhText.text = health.ToString() + "/" + maxHeatlh;
        heatlhBar.rectTransform.sizeDelta = new Vector2(health, 50f);
    }
}
