using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class AnimationControllerScript : MonoBehaviour
{
    // Public fields
    [SerializeField] private float acceleration = 0.5f, deceleration = 0.5f, maximumInjuredLayerWeight = 0.5f;
    [SerializeField] private TextMeshProUGUI healthText;

    
    // Player health
    private const float MaximumHealth = 100;
    private float _currentHealth;
    
    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = MaximumHealth;
    }

    // Update is called once per frame
    private void Update()
    { 
        ChangeLayers();
    }
    
    private void ChangeLayers()
    {
        var hitPressed = Input.GetKeyDown(KeyCode.Space);

        if (hitPressed)
        {
            _currentHealth -= MaximumHealth / 10;

            if (_currentHealth < 0)
            {
                _currentHealth = MaximumHealth;
            }
        }

        var healthPercentage = _currentHealth / MaximumHealth;
        healthText.text = $"Health: {healthPercentage * 100}%";

        // Change (and add) code underneath
        var currentInjuredLayerWeight = 0;
        var targetInjuredLayerWeight = (1 - healthPercentage) * maximumInjuredLayerWeight;
    }
}
