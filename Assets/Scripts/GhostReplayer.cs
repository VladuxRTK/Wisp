using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GhostReplayer : ScriptableObject
{
    public bool isReplaying;
    public float recordFrequency;

    public List<float> timeStamp;

    public List<Vector3> position=new List<Vector3>(999999);

    // Start is called before the first frame update
   

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