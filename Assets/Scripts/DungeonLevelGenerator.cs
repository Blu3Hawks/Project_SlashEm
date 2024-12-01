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
    [SerializeField] private List<Space> listOfSpaces;

    private void Start()
    {
        GenerateRandomLevelValues();
        GenerateAllSpaces();
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
        listOfSpaces.Add(firstSpace);

        int currentIteration = 0;
        while (currentIteration < levelIterations)
        {
            int randomSpaceToDivide = Random.Range(0, listOfSpaces.Count);
            Space spaceToCheck = listOfSpaces[randomSpaceToDivide];

            if (CheckForSpaceDivisionXAxis(spaceToCheck))
            {
                for (; currentIteration < levelIterations; currentIteration++)
                {
                    DivideSpaceXAxis(spaceToCheck);
                }
            }

            else if (CheckForSpaceDivisionYAxis(spaceToCheck))
            {
                for (; currentIteration < levelIterations; currentIteration++)
                {
                    DivideSpaceYAxis(spaceToCheck);
                }
            }

            else
            {
                listOfSpaces.Remove(spaceToCheck);
                return;
            }
        }
    }

    private bool CheckForSpaceDivisionXAxis(Space spaceToCheck)
    {
        return spaceToCheck.Width > (maxRoomWidth + 1) * 2;
    }

    private bool CheckForSpaceDivisionYAxis(Space spaceToCheck)
    {
        return spaceToCheck.Length > (maxRoomLength + 1) * 2;
    }

    private void DivideSpaceXAxis(Space spaceToDivide)
    {
        // take the total width - between the min x value + (max room length + 1) and the max x value - (max room length +1)
        int newXValue = Random.Range(spaceToDivide.BottomLeftSpaceCorner.x + (maxRoomWidth + 1), spaceToDivide.BottomRightSpaceCorner.x - (maxRoomWidth + 1));
        //now we create two new spaces - the first one, that will be the left part of the divided space, will be having the bottom left and top left corners,
        //combined with two new points - the top right would be the top left + the newXValue and the bottom right will be the bottom left + newXValue

        Space newSpaceLeftSide = new Space(spaceToDivide.BottomLeftSpaceCorner, new Vector2Int(spaceToDivide.BottomLeftSpaceCorner.x + newXValue, spaceToDivide.TopLeftSpaceCorner.y));

        //next we will take the other side and make a space out of it - so we will take the middle values, which are the previous space that we have created - we will take its right points
        //as our left points for the new space, and the right points would be the given space right points. Watch the files to get a better understanding for the divisions.

        //we can use the new space on the left - and take its bottom right point, and the given space's top right point to create this new space. That totally works.
        Space newSpaceRightSide = new Space(newSpaceLeftSide.BottomRightSpaceCorner, spaceToDivide.TopRightSpaceCorner);

        //now we will add these two spaces to the list, and remove the spaceToDivide
        listOfSpaces.Add(newSpaceLeftSide);
        listOfSpaces.Add(newSpaceRightSide);
        listOfSpaces.Remove(spaceToDivide);
    }

    private void DivideSpaceYAxis(Space spaceToDivide)
    {

    }
}
