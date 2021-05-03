using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{

    public GhostEntity ghost;
    private float timer;
    private float timerValue;
    // Start is called before the first frame update
    void Awake()
    {
        if(ghost.isRecording)
        {
            ResetData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        timerValue += Time.unscaledDeltaTime;

        if(ghost.isRecording && timer >= 1/ghost.recordFrequency)
        {
            ghost.timeStamp.Add(timerValue);
            ghost.position.Add(this.transform.position);
            timer = 0;
        }
    }

    public void ResetData()
    {
        ghost.ResetData();

        timerValue = 0;
        timer = 0;
    }
}
