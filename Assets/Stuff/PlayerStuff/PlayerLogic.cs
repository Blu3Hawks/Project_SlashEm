using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private Bullet bullet;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject bulletSpawnPoint;

    private int score;
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    public void AddScore()
    {
        score++;
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            Bullet currentBullet = Instantiate(bullet, bulletSpawnPoint.transform.position, Quaternion.identity);
            currentBullet.OnBulletHit += PrintOnBulletHit;
            currentBullet.Direction = transform.forward;
        }
    }

    private void PrintOnBulletHit(BulletCollision bulletCollision)
    {
        Debug.Log("Stuff happened");
        Destroy(bulletCollision.bullet);
        Destroy(bulletCollision.cube);
    }
}
