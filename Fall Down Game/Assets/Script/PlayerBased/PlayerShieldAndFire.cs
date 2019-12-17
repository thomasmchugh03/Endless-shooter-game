using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldAndFire : MonoBehaviour
{
    public Transform spawnPos;
    public Transform canon1;
    public Transform canon2 = null;
    public float fireRate = 0.1f;
    private float nextFire = 0.0f;

    public GameObject birthed;
    public GameObject laser;

    private GameObject newShield;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            newShield = Instantiate(birthed, spawnPos.position, spawnPos.rotation);
            newShield.transform.SetParent(spawnPos);
        }
        if(Input.GetMouseButtonUp(1))
        {
            Destroy(newShield);
        }
        //Creating a fire rate system
        if(Input.GetMouseButton(0) && Time.time > nextFire)
        {
            //As time constantly passes, update nextFire so that it halts the fireRate by adding fireRate to the elapsed time period. Ex. If fire rate is 1 and fire button is clicked, make nextFire be total time elapsed plus 1, which makes
            //the condition for this if loop untrue for 1 second.
            nextFire = Time.time + fireRate;
            Firing();
        }        
    }

    void Firing()
    {
        GameObject l1 = Instantiate(laser, canon1.position, canon1.rotation);
        GameObject l2 = Instantiate(laser, canon2.position, canon2.rotation);      
    }
}
