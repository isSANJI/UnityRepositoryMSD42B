using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float laserSpeed = -10f;

    float laserFiringTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireContinuously());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireContinuously()
    {
        //while coroutine is running
        while (true)
        {
            //instantiate the laser at the enemy position
            GameObject laser = Instantiate(enemyLaser, transform.position, transform.rotation);

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);

            laserFiringTime = Random.Range(0.5f, 1f);

            yield return new WaitForSeconds(laserFiringTime);
        }
    }
}
