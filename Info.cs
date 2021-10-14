using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{

    public GameObject Player;
    public GameObject enemy;
    public GameObject enemy2;

    //距離算出＆計算用
    
  
    Vector3 diff;
    Vector3 diff1;

    


    // Start is called before the first frame update
    void Start()
    {
        //距離計算
        diff=Player.transform.position-enemy.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        diff=Player.transform.position-enemy.transform.position;
        diff1=Player.transform.position-enemy2.transform.position;
        
        if(diff.magnitude < 7.0f  || diff1.magnitude < 7.0f) //magnitudeは絶対値
        {
            Text uiText = GetComponent<Text>();
            uiText.text = "Finding!!";
            
        }
        else
        {
            Text uiText = GetComponent<Text>();
            uiText.text = "Not Finding!!";
        }
        
    }
}
