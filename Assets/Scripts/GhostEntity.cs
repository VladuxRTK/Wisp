using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GhostEntity : ScriptableObject
{
    public bool isRecording;
    public bool isReplaying;
    public float recordFrequency;

    public List<float> timeStamp;
   
    public List<Vector3> position;
   
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetData()
    {
      
        
        timeStamp.Clear();
        position.Clear(); 

    }
}
