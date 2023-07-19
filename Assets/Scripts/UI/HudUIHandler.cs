using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject healthBarObject;
    //[SerializeField] private GameObject energyBarObject;
    [SerializeField] private TMP_Text nameText;
    private static GameObject popupUI;
    [SerializeField] private GameObject _popupUI;
    private static GameObject rabbitTip;
    [SerializeField] private GameObject _rabbitTip;

    public static HudUIHandler Instance;
    private BarUI healthBar;
    //private BarUI energyBar;

    private void Awake()
    {
        Instance = this;
        popupUI = _popupUI;
        rabbitTip = _rabbitTip;
    }

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = MainManager.playerName;
        
        healthBar = healthBarObject.transform.GetComponent<BarUI>();
        //energyBar = energyBarObject.transform.GetComponent<BarUI>();
        healthBar.SetMaxValue(20 * Mathf.Pow(3, MainManager.animalIndex));
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

    public void ShowTip()
    {
        StartCoroutine(ShowTipRabbit());
    }

    IEnumerator ShowTipRabbit()
    {
        rabbitTip.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        rabbitTip.SetActive(false);
    }

    public static void ShowGameOver()
    {
        System.TimeSpan timeSurvived = new(0, 0, TimeUI.elapsedTime);
        popupUI.SetActive(true);
        popupUI.transform.GetChild(2).GetComponent<TMP_Text>().text = System.String.Format("You Survived for {0} minute(s) and {1} second(s).", timeSurvived.Minutes, timeSurvived.Seconds);
    }

    public static void HideGameOver()
    {
        popupUI.SetActive(false);
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
