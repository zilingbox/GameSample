using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class Grid : MonoBehaviour {

    public int xSize, ySize;

    private Vector3[] vertices;

    private void Awake()
    {
       StartCoroutine(Generate());
    }

    private IEnumerator  Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        //need to hold an array of 3D vectors to store the points
        //the amount of vertices depends on the size of the grid
        //( #x + 1 )( #y + 1 )
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        for(int i=0, y=0; y<= ySize; y++)
        {
            for(int x =0; x<= xSize; x++,i++)
            {
                vertices[i] = new Vector3(x, y);
                yield return wait;
            }
        }
    }

    private void OnDrawGizmos()
    {
        //OnDrawGizmos methods are also invoked while Unity is in edit mode
        //To prevent this error, check whether the array exists and jump out of the method if it isn't
        if (vertices == null)
        {
            return;
        }
        Gizmos.color = Color.black;
        for(int i=0;i<vertices.Length;i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
