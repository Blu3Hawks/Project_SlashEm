using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeObject : MonoBehaviour
{
    public UnityEvent hitBullet;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            hitBullet.Invoke();
            Debug.Log("Hell yeah");
        }
    }

    public void OnHitting()
    {
        Debug.Log("We hit something!");
    }
}
