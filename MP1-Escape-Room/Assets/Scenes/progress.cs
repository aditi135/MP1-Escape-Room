using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [Header("UI Settings")]
    public Slider progressBar;
    public int totalSockets = 3;

    [Header("Reward Objects")]
    public GameObject rewardObject;  // The object to appear
    public GameObject rewardText;    // The text to appear
    public Light rewardLight1;
    public Light rewardLight2;
    public Light rewardLight3;
    public Light rewardLight4;
    public Light rewardLight5;
    public Light rewardLight6;

    public Color completionColor = Color.green;

    private int correctCount = 0;
    private bool rewardShown = false;

    void Start()
    {
        correctCount = 0;

        if (progressBar != null)
        {
            progressBar.minValue = 0;
            progressBar.maxValue = totalSockets;
            progressBar.value = 0;
        }

        // Make sure reward objects start hidden
        if (rewardObject != null)
            rewardObject.SetActive(false);

        if (rewardText != null)
            rewardText.SetActive(false);
    }

    public void AddProgress()
    {
        correctCount++;
        correctCount = Mathf.Clamp(correctCount, 0, totalSockets);
        UpdateBar();
        CheckReward();
    }

    public void RemoveProgress()
    {
        correctCount--;
        correctCount = Mathf.Clamp(correctCount, 0, totalSockets);
        UpdateBar();
    }

    void UpdateBar()
    {
        if (progressBar != null)
            progressBar.value = correctCount;
    }

    void CheckReward()
    {
        if (!rewardShown && correctCount == totalSockets)
        {
            if (rewardObject != null)
                rewardObject.SetActive(true);

            if (rewardText != null)
                rewardText.SetActive(true);


            if (rewardLight1 != null)
                rewardLight1.color = completionColor; // Change light to green
            if (rewardLight2 != null)
                rewardLight2.color = completionColor; // Change light to green
            if (rewardLight3 != null)
                rewardLight3.color = completionColor; // Change light to green
            if (rewardLight4 != null)
                rewardLight4.color = completionColor; // Change light to green
            if (rewardLight5 != null)
                rewardLight5.color = completionColor; // Change light to green
            if (rewardLight6 != null)
                rewardLight6.color = completionColor; // Change light to green



            rewardShown = true;
        }
    }
}
