using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : MonoBehaviour
{
    public GhostReplayer ghost;
    public bool move;
    private float timeValue;
    private int index1;
    private int index2;

    // Start is called before the first frame update
    void Awake()
    {
        timeValue = 0;
        move = false;
        
       
    }

    // Update is called once per frame
    void Update()
    {
       
        
            timeValue += Time.unscaledDeltaTime;

            if (ghost.position.Count > 0 && this.transform.position != GameObject.FindGameObjectWithTag("Player").transform.position)
            {
                GetIndex();
                SetTransform();
            }

           
        

        if (this.transform.position == ghost.position[ghost.position.Count - 1])
        {
            timeValue = 0f;
            // this.transform.position = new Vector3(9999f, 9999f, 0f);
            Debug.Log("Here");
           ghost.ResetData();
            //move = false;
        }



    }
    

    private void GetIndex()
    {
        for(int i = 0;i<ghost.timeStamp.Count-2;i++)
        {
            if (ghost.timeStamp[i] == timeValue)
            {
                index1 = i;
                index2 = i;
                return;
            }
            else if(ghost.timeStamp[i] < timeValue && timeValue<ghost.timeStamp[i+1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }
        }
        index1 = ghost.timeStamp.Count - 1;
        index2 = ghost.timeStamp.Count - 1;
        
    }

    private void SetTransform()
    {
    
        if (index1 == index2)
        {
            this.transform.position = ghost.position[index1];
        }
        
        else
        {
            float interpolationFactor = (timeValue - ghost.timeStamp[index1]) / (ghost.timeStamp[index2] - ghost.timeStamp[index1]);
            this.transform.position = Vector3.Lerp(ghost.position[index1], ghost.position[index2], interpolationFactor);
        }

    }
    
}
