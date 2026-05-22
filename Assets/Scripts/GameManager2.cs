using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager2 : MonoBehaviour
{
    [Header("Rocky Ship")]
    public RockySpaceship rockyShip;

    [Header("UI Group")]
    public GameObject timingUIGroup;

    [Header("Moving Gauge")]
    public RectTransform movingMarker;
    public float markerSpeed = 500f;
    public float minX = -300f;
    public float maxX = 300f;

    [Header("Target Zone")]
    public RectTransform targetZone;
    public float targetMinX = -250f;
    public float targetMaxX = 250f;

    [Header("Game Rules")]
    public int maxAttempts = 5;
    public int requiredSuccesses = 3;

    private int attempts = 0;
    private int successes = 0;
    private int direction = 1;

    [Header("UI Text")]
    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI successText;
    public TextMeshProUGUI messageText;

    [Header("Scene")]
    public string nextStageName = "Stage3";
    public string gameOverSceneName = "GameOver";

    private bool gameActive = false;
    private bool uiShown = false;

    void Start()
    {
        if (timingUIGroup != null)
        {
            timingUIGroup.SetActive(false);
        }

        MoveTargetZone();
        UpdateUI();
    }

    void Update()
    {
        if (!gameActive)
        {
            if (rockyShip == null)
            {
                //Debug.Log("Rocky Ship is NOT connected!");
                return;
            }

            if (rockyShip.arrived)
            {
                //Debug.Log("Grace meet Rocky's spaceship. Try to connect tunnel to encounter Rocky.");

                gameActive = true;

                if (timingUIGroup != null)
                {
                    timingUIGroup.SetActive(true);
                }
                else
                {
                    //Debug.Log("Timing UI Group is NOT connected!");
                }

                if (messageText != null)
                {
                    messageText.text =
                        "Press SPACE when the marker is inside the target zone!";
                }
            }

            return;
        }

        MoveMarker();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckTiming();
        }
    }

    void MoveMarker()
    {
        if (movingMarker == null) return;

        Vector2 pos = movingMarker.anchoredPosition;

        pos.x += direction * markerSpeed * Time.deltaTime;

        if (pos.x >= maxX)
        {
            pos.x = maxX;
            direction = -1;
        }
        else if (pos.x <= minX)
        {
            pos.x = minX;
            direction = 1;
        }

        movingMarker.anchoredPosition = pos;
    }

    void CheckTiming()
    {
        attempts++;

        float markerX = movingMarker.anchoredPosition.x;

        float targetX = targetZone.anchoredPosition.x;
        float targetWidth = targetZone.rect.width;

        float leftEdge = targetX - targetWidth / 2f;
        float rightEdge = targetX + targetWidth / 2f;

        if (markerX >= leftEdge && markerX <= rightEdge)
        {
            successes++;

            if (messageText != null)
            {
                messageText.text =
                    "Success! Tunnel alignment stable.";
            }
        }
        else
        {
            if (messageText != null)
            {
                messageText.text =
                    "Failed! Tunnel alignment unstable.";
            }
        }

        if (successes >= requiredSuccesses)
        {
            SceneManager.LoadScene(nextStageName);
            return;
        }

        if (attempts >= maxAttempts)
        {
            GameOver();
        }

        MoveTargetZone();
        UpdateUI();
    }

    void MoveTargetZone()
    {
        if (targetZone == null) return;

        float randomX = Random.Range(targetMinX, targetMaxX);

        targetZone.anchoredPosition =
            new Vector2(randomX, targetZone.anchoredPosition.y);
    }

    void UpdateUI()
    {
        if (attemptsText != null)
        {
            attemptsText.text =
                "Attempts: " + attempts + " / " + maxAttempts;
        }

        if (successText != null)
        {
            successText.text =
                "Success: " + successes + " / " + requiredSuccesses;
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetString(
            "LastScene",
            SceneManager.GetActiveScene().name
        );

        SceneManager.LoadScene(gameOverSceneName);
    }
}