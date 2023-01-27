using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject pb;
    private GameObject pointsBox;
    private Vector3 additionalHeight = new Vector3(0, 2.5f, 0);
    private float wallForce = -3.95f;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        pointsBox = (GameObject)Instantiate(pb, rb.transform.position + additionalHeight, Quaternion.identity);
    }

    void Update() {
        if(GameControl.instance.gameOver == false) {
            pointsBox.transform.position = rb.transform.position + additionalHeight;
        }
    }

    private void OnCollisionEnter(Collision collisionData) {
        if(collisionData.gameObject.name == "BarrelDestroyer") {
            Destroy(gameObject);
            Destroy(pointsBox);
            BarrelPool.instance.barrelCount--;
        }
        if(GameControl.instance.gameOver == false) {
            if(collisionData.gameObject.tag == "InvisiWall") {
                rb.AddForce(wallForce, 0.0f, 0.0f, ForceMode.Impulse);
                wallForce *= -1;
            }
        }
    }
}
