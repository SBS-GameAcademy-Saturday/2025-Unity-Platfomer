using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    // 경과 시간
    private float elapsedTime = 0;
    
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // 분 계산
        int minutes = (int)(elapsedTime / 60f);
        // 초 계산
        int seconds = (int)(elapsedTime % 60f);

        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}
