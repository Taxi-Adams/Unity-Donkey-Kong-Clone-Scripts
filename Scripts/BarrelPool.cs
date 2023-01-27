using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelPool : MonoBehaviour
{
    public static BarrelPool instance;
    public int barrelCount = 0;
    private GameObject barrel;
    // private GameObject pointBox;
    public GameObject barrelsPrefab;
    // public GameObject pointBoxPrefab;
    public float spawnCountdown = 10.0f;
    private Vector3 barrelSpawnPosition = new Vector3(-31.2f, 26.5f, 0.00f);
    private Vector3 secondBarrelSpawnPosition = new Vector3(-26.0f, 26.5f, 0);
    // private Vector3 pointBoxSpawnPosition = new Vector3(-31.2f, 27.3f, 0);
    // private Vector3 secondPointBoxSpawnPosition = new Vector3(-26.0f, 27.3f, 0);
    private float doubleBarrelChance = 0.0f;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        barrel = (GameObject)Instantiate(barrelsPrefab, barrelSpawnPosition, Quaternion.identity);
        // pointBox = (GameObject)Instantiate(pointBoxPrefab, pointBoxSpawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameControl.instance.gameOver == false) {
            spawnCountdown -= Time.deltaTime;
            if(spawnCountdown <= 0.0f && barrelCount < 10) {
                spawnCountdown = 10.0f;
                doubleBarrelChance = Random.Range(0.0f, 1.0f);
                if(doubleBarrelChance > 0.2f) {
                    barrel = (GameObject)Instantiate(barrelsPrefab, barrelSpawnPosition, Quaternion.identity);
                    barrelCount++;
                } else if(doubleBarrelChance < 0.2f) {
                    barrel = (GameObject)Instantiate(barrelsPrefab, barrelSpawnPosition, Quaternion.identity);

                    barrel = (GameObject)Instantiate(barrelsPrefab, secondBarrelSpawnPosition, Quaternion.identity);
                    barrelCount += 2;
                }
            }
        }
    }
}
