using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    public Text timer;

    private float min = 2;
    private float sec = 0;

    void Update()
    {
        sec -= Time.deltaTime;
        if (sec < 0 && min > 0)
        {
            min -= 1;
            sec = 59;
        }
        if (min < 1 && sec < 0)
        {
            timer.text = "Time's up!";
            return;
        }
        timer.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    void HandleTimerLabel()
    {

    }

}
