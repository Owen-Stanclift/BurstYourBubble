 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell mazeCellPrefab;

    //width and length of the maze
    [SerializeField]
    private int mazeWidth;
    [SerializeField]
    private int mazeDepth;

    //prefab for bubbles
    [SerializeField]
    private GameObject bubblePrefab;

    //prefab for ending trigger
    [SerializeField]
    private GameObject endingPrefab;

    //probability of bubble placement
    [SerializeField]
    [Range(0f, 1f)]
    private float placementProbability = 0.2f;

    //2d array of grid cells
    private MazeCell[,] mazeGrid;

    void Start()
    {
        //init grid and fill with cell instances, adding occasional bubble
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];

        for(int x = 0; x < mazeWidth; x++)
        {
            for(int y = 0; y < mazeDepth; y++)
            {
                mazeGrid[x, y] = Instantiate(mazeCellPrefab, new Vector3(x, y, 0), Quaternion.identity);

                if (Random.value < placementProbability)
                {
                    Instantiate(bubblePrefab, new Vector3(x, y, 0), Quaternion.identity);
                }

            }
        }

        //opening in top left of the maze
        mazeGrid[0, 0].ClearLeftWall();
        mazeGrid[0, 0].ClearBackWall();

        //carve the maze
        CarveMaze(null, mazeGrid[0,0]);

        //set an ending cell
        SetEndingCell();
    }

    //recursively carve the maze using breadth first search
    private void CarveMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.VisitCell();
        ClearWalls(previousCell, currentCell);

        MazeCell nextCell;

        //continue carving until all cells have been visited
        do
        {
             nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                CarveMaze(currentCell, nextCell);
            }
        }while (nextCell != null);
    }

    //selects an unvisited neighbor
    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCell(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1,10)).FirstOrDefault();
    }

    //gets all unvisited neighbors for the given cell
    private IEnumerable<MazeCell> GetUnvisitedCell(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int y = (int)currentCell.transform.position.y;

        //check the right neighbor
        if(x + 1 < mazeWidth)
        {
            var cellToRight = mazeGrid[x + 1, y];

            if(cellToRight.IsVisted == false)
            {
                yield return cellToRight;
            }
        }

        //check the left neighbor
        if (x - 1 >= 0)
        {
            var cellToLeft = mazeGrid[x - 1, y];

            if (cellToLeft.IsVisted == false)
            {
                yield return cellToLeft;
            }
        }

        //check the front neighbor
        if(y + 1 <  mazeDepth)
        {
            var cellToFront = mazeGrid[x, y + 1];

            if(cellToFront.IsVisted == false)
            {
                yield return cellToFront;
            }
        }

        //check the back neighbor
        if(y - 1 >= 0)
        {
            var cellToBack = mazeGrid[x, y - 1];

            if(cellToBack.IsVisted == false)
            {
                yield return cellToBack;
            }
        }
    }

    //clears walls between two adjacent cells based on their positions
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if(previousCell == null)
        {
            return;
        }

        // prev cell is to the left of current cell
        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        // prev cell is to the right of current cell
        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        // prev cell is behind current cell
        if (previousCell.transform.position.y < currentCell.transform.position.y)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        // prev cell is in front of current cell
        if (previousCell.transform.position.y > currentCell.transform.position.y)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

    //set bottom right cell as maze ending point
    private void SetEndingCell()
    {
        MazeCell endingCell = mazeGrid[mazeWidth - 1, mazeDepth - 1];

        Instantiate(endingPrefab, new Vector3(mazeWidth - 1, mazeDepth - 1, 0), Quaternion.identity);

        endingCell.ClearRightWall();
        endingCell.ClearFrontWall();
    }
}
