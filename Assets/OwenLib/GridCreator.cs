using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    // Start is called before the first frame update
   
    public  static Vector2[,] gridPosition;
    public  int row, col; 
    public static int currRow, currCol;
    public static int rowSize, colSize;
    public float spaceX, spaceY;
    public void StartGrid()
    {
        currRow = 0;
        currCol = 0;
        rowSize = row;
        colSize = col;
        gridPosition = new Vector2[row, col];
        gameObject.SetActive(true);
        gridPosition[0,0] = new Vector2(transform.position.x, transform.position.y);
        CreateGrid(row, col,gridPosition);
    }
    void CreateGrid(int row, int column, Vector2[,] gridPosition)
    {

        Instantiate(gameObject, new Vector3(gridPosition[0,0].x, gridPosition[0,0].y, 1), gameObject.transform.rotation);
        
        for (int i = 0; i < row; i++)
        {
            for(int j = 0; j < column; j++)
            {
                if (!(i == 0 && j == 0))
                gridPosition[i,j] = new Vector2(gameObject.transform.position.x + (i * spaceX), gameObject.transform.position.y - (j * spaceY));
                Instantiate(gameObject, new Vector3(gridPosition[i,j].x, gridPosition[i,j].y,1),gameObject.transform.rotation);;
            }
        }
        gameObject.SetActive(false);
    }

   public static Vector2 getPosistion(int num1, int num2)
    {
        return gridPosition[num1,num2];
    }
    public static void setRow(int pos)
    {
        currRow = pos;
    }
    public static void setCol(int pos)
    {
        currCol = pos;
    }
    // Update is called once per frame
}