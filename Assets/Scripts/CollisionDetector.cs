using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && this.tag == "Animal")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.LoseHP();
            Debug.Log(player.health);
            Destroy(gameObject);
        }
        else if (this.tag == "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}