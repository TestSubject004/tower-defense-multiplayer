using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int totalHealth = 100;
    [SerializeField] private int currentHealth;

    public delegate void takeDamage(int healthVal);
    public static event takeDamage damage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        //damage(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 6)
        {
            Debug.Log("the collision is" + collision.gameObject.name);
            currentHealth -= 10;
            //damage(currentHealth);
            Destroy(collision.gameObject);
        }
    }
}
