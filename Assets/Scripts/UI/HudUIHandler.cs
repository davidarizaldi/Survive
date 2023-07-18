using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject healthBarObject;
    [SerializeField] private TMP_Text nameText;
    //[SerializeField] private GameObject energyBarObject;

    private BarUI healthBar;
    //private BarUI energyBar;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = MainManager.playerName;
        
        healthBar = healthBarObject.transform.GetComponent<BarUI>();
        //energyBar = energyBarObject.transform.GetComponent<BarUI>();
        healthBar.SetMaxValue(20 * Mathf.Pow(4, MainManager.animalIndex));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar(healthBar);
    }

    void UpdateBar(BarUI bar)
    {
        bar.SetValue(GameManager.playerObject.HP);
    }
}
