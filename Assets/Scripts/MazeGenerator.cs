 using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell mazeCellPrefab;

    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    [Range(0f, 1f)]
    private float placementProbability = 0.2f;

    private MazeCell[,] mazeGrid;

    void Start()
    {
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];

        for(int x = 0; x < mazeWidth; x++)
        {
            for(int y = 0; y < mazeDepth; y++)
            {
                mazeGrid[x, y] = Instantiate(mazeCellPrefab, new Vector3(x, y, 0), Quaternion.identity);

                if (Random.value < placementProbability)
                {
                    Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
                }

            }
        }

        //opening in top left of the maze:
        mazeGrid[0, 0].ClearLeftWall(); // Open the left wall
        mazeGrid[0, 0].ClearBackWall();

        //carve the maze
        CarveMaze(null, mazeGrid[0,0]);

        //set an ending cell
        SetEndingCell();
    }

    private void CarveMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.VisitCell();
        ClearWalls(previousCell, currentCell);

        MazeCell nextCell;

        do
        {
             nextCell = GetNextUnvisitedCell(currentCell);

            if (nextCell != null)
            {
                CarveMaze(currentCell, nextCell);
            }
        }while (nextCell != null);
    }

    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCell(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1,10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCell(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int y = (int)currentCell.transform.position.y;

        if(x + 1 < mazeWidth)
        {
            var cellToRight = mazeGrid[x + 1, y];

            if(cellToRight.IsVisted == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = mazeGrid[x - 1, y];

            if (cellToLeft.IsVisted == false)
            {
                yield return cellToLeft;
            }
        }

        if(y + 1 <  mazeDepth)
        {
            var cellToFront = mazeGrid[x, y + 1];

            if(cellToFront.IsVisted == false)
            {
                yield return cellToFront;
            }
        }

        if(y - 1 >= 0)
        {
            var cellToBack = mazeGrid[x, y - 1];

            if(cellToBack.IsVisted == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if(previousCell == null)
        {
            return;
        }

        if(previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }
    
        if(previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if(previousCell.transform.position.y < currentCell.transform.position.y)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if(previousCell.transform.position.y > currentCell.transform.position.y)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

    private void SetEndingCell()
    {
        MazeCell endingCell = mazeGrid[mazeWidth - 1, mazeDepth - 1];

        endingCell.ClearRightWall();
        endingCell.ClearFrontWall();
    }
}
