using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Xenonite")]
    public int xenoniteCount = 0;
    public int xenoniteGoal = 5;
    public TextMeshProUGUI xenoniteText;

    [Header("Fuel")]
    public float fuel = 100f;
    public float maxFuel = 100f;
    public float fuelDecreaseSpeed = 5f;
    public Image fuelBarFill;

    [Header("Hull")]
    public float hull = 100f;
    public float maxHull = 100f;
    public float hullDecreaseSpeed = 2.5f;
    public Image hullBarFill;

    [Header("Icon Spawn Chances (Total 100)")]
    public int asteroidChance = 50;
    public int astrophageChance = 25;
    public int rockyChance = 15;
    public int xenoniteChance = 10;

    [Header("Scenes")]
    public string nextStageName = "Stage 2";
    public string gameOverSceneName = "GameOver";

    private bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        fuel = maxFuel;
        hull = maxHull;
        UpdateUI();
    }

    void Update()
    {
        if (gameEnded) return;

        fuel -= fuelDecreaseSpeed * Time.deltaTime;
        hull -= hullDecreaseSpeed * Time.deltaTime;

        fuel = Mathf.Clamp(fuel, 0, maxFuel);
        hull = Mathf.Clamp(hull, 0, maxHull);

        if (fuel <= 0 || hull <= 0)
        {
            GameOver();
        }

        UpdateUI();
    }

    public void AddXenonite()
    {
        if (gameEnded) return;

        xenoniteCount++;

        if (xenoniteCount >= xenoniteGoal)
        {
            gameEnded = true;
            SceneManager.LoadScene(nextStageName);
        }

        UpdateUI();
    }

    public void AddFuelPercent(float percent)
    {
        fuel += maxFuel * percent;
        fuel = Mathf.Clamp(fuel, 0, maxFuel);
        UpdateUI();
    }

    public void AddHullPercent(float percent)
    {
        hull += maxHull * percent;
        hull = Mathf.Clamp(hull, 0, maxHull);
        UpdateUI();
    }

    public void DamageHullPercent(float percent)
    {
        hull -= maxHull * percent;
        hull = Mathf.Clamp(hull, 0, maxHull);
        UpdateUI();
    }

    void GameOver()
{
    gameEnded = true;

    PlayerPrefs.SetString(
        "LastScene",
        SceneManager.GetActiveScene().name
    );

    SceneManager.LoadScene(gameOverSceneName);
}

    void UpdateUI()
    {
        if (xenoniteText != null)
        {
            xenoniteText.text = "Xenonite: " + xenoniteCount + " / " + xenoniteGoal;
        }

        if (fuelBarFill != null)
        {
            fuelBarFill.fillAmount = fuel / maxFuel;
        }

        if (hullBarFill != null)
        {
            hullBarFill.fillAmount = hull / maxHull;
        }
    }
}