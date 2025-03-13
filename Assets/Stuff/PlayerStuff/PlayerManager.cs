using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerLogic player_Logic;
    [SerializeField] private Transform player_Dir;



    public Vector3 playerDir;

    private void Update()
    {
        CalculateDirection();
    }
    private void CalculateDirection()
    {
        playerDir = transform.position + player_Dir.position;
    }
}
