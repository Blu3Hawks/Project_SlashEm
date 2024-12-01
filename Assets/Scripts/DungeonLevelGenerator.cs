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

            if (CheckForSpaceDivision(spaceToCheck))
            {
                for (; currentIteration < levelIterations; currentIteration++)
                {

                }
            }
            else
            {
                listOfSpaces.Remove(spaceToCheck);
            }
        }
    }

    private bool CheckForSpaceDivision(Space spaceToCheck)
    {
        return spaceToCheck.Width > (maxRoomWidth + 1) * 2 || spaceToCheck.Length > (maxRoomLength + 1) * 2;
    }

    private void DivideSpaceXAxis()
    {

    }

    private void DivideSpaceYAxis()
    {

    }
}
