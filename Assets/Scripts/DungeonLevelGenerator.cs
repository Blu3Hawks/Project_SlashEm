using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonLevelGenerator : MonoBehaviour
{
    [Header("Level Values")]
    [Header("Level Width")]
    // min and max level width with a local variable of the actual width
    [SerializeField] private int minLevelWidth;
    [SerializeField] private int maxLevelWidth;
    private int levelWidth;
    [Header("Level Length")]
    // min and max level length with a local variable of the actual length
    [SerializeField] private int minLevelLength;
    [SerializeField] private int maxLevelLength;
    private int levelLength;
    [Header("Level Iterations")]
    // min and max iterations - how many divides will be in the total space given with a local variable of the actual iterations
    [SerializeField] private int minIterations;
    [SerializeField] private int maxIterations;
    private int levelIterations;

    [Header("Room Values")]
    //track the amount of rooms that we have and also their min and max values for their size
    [Header("Room Width")]
    [SerializeField] private int minRoomWidth;
    [SerializeField] private int maxRoomWidth;
    [Header("Room Length")]
    [SerializeField] private int minRoomLength;
    [SerializeField] private int maxRoomLength;
    [Header("List of Room")]

    [SerializeField] private GameObject planePrefab;
    private List<Space> spacesToDivide = new List<Space>();
    private List<Space> spacesToCheck = new List<Space>();

    public void GenerateLevel()
    {
        ClearWorld();
        GenerateRandomLevelValues();
        GenerateAllSpaces();
        Debug.Log("The width is: " + levelWidth + " and the length is: " + levelLength);
        foreach (Space space in spacesToDivide)
        {
            Debug.Log($"Space: BottomLeft={space.BottomLeftSpaceCorner}, TopRight={space.TopRightSpaceCorner}");
        }
        CreatePlanesForSpaces();
    }

    private void GenerateRandomLevelValues()
    {
        levelWidth = Random.Range(minLevelWidth, maxLevelWidth);
        levelLength = Random.Range(minLevelLength, maxLevelLength);
        levelIterations = Random.Range(minIterations, maxIterations);
    }

    private void GenerateAllSpaces()
    {
        // getting the firt space here - then dividing it for the amount of iterations, each time creating new spaces, that are on a list - after dividing remove them from the list. each time
        // check a random space to divide until run out of divisions/ iterations or running out of space to divide.
        Space firstSpace = new Space(new Vector2Int(0, 0), new Vector2Int(levelWidth, levelLength));
        spacesToDivide.Add(firstSpace);
        spacesToCheck.Add(firstSpace);
        int currentIteration = 0;

        while (currentIteration < levelIterations && spacesToDivide.Count > 0)
        {
            int randomSpaceToDivide = Random.Range(0, spacesToDivide.Count);
            Space spaceToCheck = spacesToDivide[randomSpaceToDivide];

            Debug.Log("A new space has been made: " + spaceToCheck);

            if (CheckForSpaceDivisionXAxis(spaceToCheck) && CheckForSpaceDivisionYAxis(spaceToCheck) && spacesToDivide.Contains(spaceToCheck))
            {
                //if both options are available then I want it to be randomized.
                if (Random.Range(0, 2) == 0)
                {
                    DivideSpaceXAxis(spaceToCheck);
                }
                else
                {
                    DivideSpaceYAxis(spaceToCheck);
                }
                currentIteration++;
            }
            else if (CheckForSpaceDivisionXAxis(spaceToCheck))
            {
                DivideSpaceXAxis(spaceToCheck);
                currentIteration++;
            }
            else if (CheckForSpaceDivisionYAxis(spaceToCheck))
            {
                DivideSpaceYAxis(spaceToCheck);
                currentIteration++;
            }
            else
            {
                return;
            }
        }
    }

    private void DivideSpaceXAxis(Space spaceToCheck)
    {
        //first we remove it from the list
        spacesToDivide.Remove(spaceToCheck);
        // take the total width - between the min x value + (max room length + 1) and the max x value - (max room length +1)

        int randomXValue = Random.Range(
            spaceToCheck.BottomLeftSpaceCorner.x + (maxRoomWidth + 1),
            spaceToCheck.BottomRightSpaceCorner.x - (maxRoomWidth + 1)
            );

        if (randomXValue <= spaceToCheck.BottomLeftSpaceCorner.x || randomXValue >= spaceToCheck.TopRightSpaceCorner.x)
        {
            Debug.LogWarning("Invalid X-axis division point. Skipping this space.");
            return;
        }
        //now we create two new spaces - the first one, that will be the left part of the divided space, will be having the bottom left and top left corners,
        //combined with two new points - the top right would be the top left + the newXValue and the bottom right will be the bottom left + newXValue

        Space newSpaceLeftSide = new Space(
            spaceToCheck.BottomLeftSpaceCorner,
            new Vector2Int(randomXValue,
            spaceToCheck.TopRightSpaceCorner.y)
            );
        //next we will take the other side and make a space out of it - so we will take the middle values, which are the previous space that we have created - we will take its right points
        //as our left points for the new space, and the right points would be the given space right points. Watch the files to get a better understanding for the divisions.

        //we can use the new space on the left - and take its bottom right point, and the given space's top right point to create this new space. That totally works.

        Space newSpaceRightSide = new Space(
            new Vector2Int(randomXValue, spaceToCheck.BottomLeftSpaceCorner.y),
            spaceToCheck.TopRightSpaceCorner
            );
        //now we will add these two spaces to the list

        spacesToDivide.Add(newSpaceLeftSide);
        spacesToDivide.Add(newSpaceRightSide);
    }

    private void DivideSpaceYAxis(Space spaceToCheck)
    {
        spacesToDivide.Remove(spaceToCheck);
        //take the total length and randomise between the min y value + max room length + 1 and the max y value - (max room length +1)

        int randomYValue = Random.Range(
            spaceToCheck.BottomLeftSpaceCorner.y + (maxRoomLength + 1),
            spaceToCheck.TopLeftSpaceCorner.y - (maxRoomWidth + 1)
            );

        if (randomYValue <= spaceToCheck.BottomLeftSpaceCorner.y || randomYValue >= spaceToCheck.TopRightSpaceCorner.y)
        {
            Debug.LogWarning("Invalid Y-axis division point. Skipping this space.");
            return;
        }

        //now we can create two new spaced - the upper space and bottom. first we make the upper one, so we will make the upper one first
        //it will have the top left and top right corners and then the new bottom left and bottom right points would be
        //the original bottom left and right corners + the new Y Value given.

        Space newSpaceDownSide = new Space(
            spaceToCheck.BottomLeftSpaceCorner,
            new Vector2Int(spaceToCheck.BottomRightSpaceCorner.x, randomYValue)
            );
        //now we do the same with the new space at the bottom

        Space newSpaceUpSide = new Space(
            newSpaceDownSide.TopLeftSpaceCorner,
            spaceToCheck.TopRightSpaceCorner
            );
        //now we will add these two spaces to the list

        spacesToDivide.Add(newSpaceUpSide);
        spacesToDivide.Add(newSpaceDownSide);
    }

    private bool CheckForSpaceDivisionXAxis(Space spaceToCheck)
    {
        return spaceToCheck.Width > (maxRoomWidth + 1) * 2;
    }

    private bool CheckForSpaceDivisionYAxis(Space spaceToCheck)
    {
        return spaceToCheck.Length > (maxRoomLength + 1) * 2;
    }



    private void CreatePlanesForSpaces()
    {
        foreach (Space space in spacesToDivide)
        {
            if (planePrefab == null)
            {
                Debug.LogError("Plane prefab is not assigned!");
                return;
            }

            GameObject plane = Instantiate(planePrefab, transform);

            Vector3 position = new Vector3(
                (space.BottomLeftSpaceCorner.x + space.TopRightSpaceCorner.x) / 2f,
                0,
                (space.BottomLeftSpaceCorner.y + space.TopRightSpaceCorner.y) / 2f
            );

            Vector3 scale = new Vector3(
                space.Width / 10f,
                1,
                space.Length / 10f
            );

            plane.transform.position = position;
            plane.transform.localScale = scale;
        }
    }

    private void ClearWorld()
    {
        while (transform.childCount != 0)
        {
            foreach (Transform item in transform)
            {
                DestroyImmediate(item.gameObject);
            }
        }
        spacesToDivide.Clear();
    }
}