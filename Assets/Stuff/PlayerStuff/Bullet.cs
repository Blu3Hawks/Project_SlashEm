using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int bullet_Damage;
    [SerializeField] private int minDamage, maxDamage;
    [SerializeField] private UnityEvent OnHittingObject;

    [SerializeField] private float speed;

    public Vector3 Direction;
    public event UnityAction<BulletCollision> OnBulletHit;

    private void Start()
    {
        RandomDamage();
    }

    private void FixedUpdate()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        rb.MovePosition(transform.position + (speed * Time.fixedDeltaTime * Direction));
    }
    private void RandomDamage()
    {
        bullet_Damage = UnityEngine.Random.Range(minDamage, maxDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            BulletHit(other.gameObject);
        }
    }

    public void BulletHit(GameObject other)
    {
        OnHittingObject.Invoke();
        OnBulletHit.Invoke(new BulletCollision { bullet = this, cube = other});
    }
}

public struct BulletCollision
{
    public Bullet bullet;
    public GameObject cube;
}