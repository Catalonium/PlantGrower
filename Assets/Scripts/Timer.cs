using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    public Text timer;

    private float min = 3;
    private float sec = 0;

    void Update()
    {
        // Timer for the upper right corner of the timer text in game.
        // Show time in real digital clock style format, for example [01:23].
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

}
