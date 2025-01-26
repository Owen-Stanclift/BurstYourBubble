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

    private MazeCell[,] mazeGrid;
    // Start is called before the first frame update
    void Start()
    {
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];

        for(int x = 0; x < mazeWidth; x++)
        {
            for(int z = 0; z < mazeDepth; z++)
            {
                mazeGrid[x, z] = Instantiate(mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

        CarveMaze(null, mazeGrid[0,0]);
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
        int z = (int)currentCell.transform.position.z;

        if(x + 1 < mazeWidth)
        {
            var cellToRight = mazeGrid[x + 1, z];

            if(cellToRight.IsVisted == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = mazeGrid[x - 1, z];

            if (cellToLeft.IsVisted == false)
            {
                yield return cellToLeft;
            }
        }

        if(z + 1 <  mazeDepth)
        {
            var cellToFront = mazeGrid[x, z + 1];

            if(cellToFront.IsVisted == false)
            {
                yield return cellToFront;
            }
        }

        if(z - 1 >= 0)
        {
            var cellToBack = mazeGrid[x, z - 1];

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

        if(previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if(previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
