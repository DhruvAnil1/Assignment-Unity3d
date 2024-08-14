using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManage : MonoBehaviour
{
    [SerializeField] private Transform cam;
    public GameObject gridPrefab; 
    public GameObject[] childPrefabs; 
    public int rows = 3; 
    public int columns = 3; 
    public float spacing = 2.0f; 

    void Start()
    {
        SpawnGrid();
    }

    void SpawnGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                GameObject gridElement = Instantiate(gridPrefab, new Vector3(x,y), Quaternion.identity);
                gridElement.name = $"Tile {x} {y}";

                
                int randomIndex = Random.Range(0, childPrefabs.Length);
                GameObject childObject = Instantiate(childPrefabs[randomIndex]);
                childObject.transform.SetParent(gridElement.transform);

                float randomScale = Random.Range(0.5f, 2.0f);
                childObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

                
                if (childObject.transform.localScale.y > gridElement.transform.localScale.y)
                {
                    
                    gridElement.GetComponent<Renderer>().material.color = Color.red;
                    childObject.transform.localPosition = new Vector3(0,0,-1);
                    

                    //Destroy(childObject);
                }
                else
                {
                    childObject.transform.localPosition = new Vector3(0,0,-1);
                }
                
            }
        }

        cam.transform.position = new Vector3((float)rows/2 -0.5f, (float)columns/2 -0.5f, -10);
    }

    
     
}
