using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int roomWidth;
    public int roomLength;

    public Room(int minRoomWidth, int maxRoomWidth, int minRoomLength, int maxRoomLength)
    {
        roomWidth = Random.Range(minRoomWidth, maxRoomWidth);
        roomLength = Random.Range(minRoomLength, maxRoomLength);
    }
}
