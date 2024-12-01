using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    public Vector2Int BottomLeftSpaceCorner;
    public Vector2Int TopRightSpaceCorner;

    public Vector2Int BottomRightSpaceCorner;
    public Vector2Int TopLeftSpaceCorner;

    // a public constructor for the points of the space - a square
    public Space(Vector2Int bottomLeftCorner, Vector2Int topRightCorner)
    {
        BottomLeftSpaceCorner = bottomLeftCorner;
        TopRightSpaceCorner = topRightCorner;

        BottomRightSpaceCorner = new Vector2Int(bottomLeftCorner.y, topRightCorner.x);
        TopLeftSpaceCorner = new Vector2Int(bottomLeftCorner.x, topRightCorner.y);
    }

    public int Width { get => (int)(TopRightSpaceCorner.x - BottomLeftSpaceCorner.x); }
    public int Length { get => (int)(TopRightSpaceCorner.y - BottomLeftSpaceCorner.y); }
}
