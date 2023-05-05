using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayEnemyHealth : MonoBehaviour
{
    public Text healthVal;

    private void OnEnable()
    {
        //health.damage += updateHealth;
    }

    private void OnDisable()
    {
        //health.damage -= updateHealth;
    }


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void updateHealth(int health)
    {
        healthVal.text = health.ToString();
    }*/
}
