using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesployShips : MonoBehaviour
{
    public GameObject ship;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(shipWave());
    }

    private void spawnShip()
    {
        GameObject shipPrefab = Instantiate(ship) as GameObject;
        shipPrefab.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 1.1f);
    }

    IEnumerator shipWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnShip();
        }
    }
}
