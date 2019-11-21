using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphComponent : MonoBehaviour
{

   

    private Graph<Vector3> graphPlayer;

    [SerializeField] private Transform pointZero=null;
    [SerializeField] private LineRenderer lineRenderer = null;
    [SerializeField] private int idPlayer=0;
    [SerializeField] private float lineWidth = 0.35f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private List<float> listValueX;
    private List<float> listValueY;

    // Start is called before the first frame update
    void Start()
    {

      

        switch (idPlayer)
        {

            case 1:
                listValueX = new List<float>() { pointZero.position.x, 2.9f, 14.14f, 17.08f, 20.41f, 21.91f, 27.25f, 29.56f, 30, 32.8f };
                listValueY = new List<float>() { pointZero.position.y, 3.04f, 10.9f, 20.11f, 22, 28.96f, 30.98f, 32.73f, 45.9f, 50.11f };
                break;

            case 2:
                listValueX = new List<float>() { pointZero.position.x, 9.9f, 19.14f, 22.08f, 28.41f, 32.91f, 40.25f, 45.56f, 50f, 54.8f };
                listValueY = new List<float>() { pointZero.position.y, 6.04f, 14.9f, 15.11f, 29.5f, 35.96f, 39.98f, 43.73f, 45.9f, 50.11f };
                break;

            case 3:
                listValueX = new List<float>() { pointZero.position.x, 0.9f, 11.14f, 10.08f, 15.41f, 20.91f, 23.25f, 26.56f, 30f, 35.8f };
                listValueY = new List<float>() { pointZero.position.y, 2.04f, 7.9f, 9.11f, 12.5f, 15.96f, 18.98f, 24.73f, 29.9f, 34.11f };
                break;
            default:
                break;
        }


        if (listValueX != null)
        {

            graphPlayer = InitializeGraph(listValueX, listValueY);    

            lineRenderer.positionCount = graphPlayer.Nodes.Count;

            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;



            for (int i = 0; i < graphPlayer.Nodes.Count; i++)
            {
                if (i==0)
                {
                     lineRenderer.SetPosition(i, graphPlayer.Nodes[i].nodeValue);
                }
                else
                    lineRenderer.SetPosition(i, graphPlayer.Nodes[i].nodeValue);

            }
        }

      
    }

       
    private Graph<Vector3> InitializeGraph(List<float> xList, List<float> yList)
    {
        Graph<Vector3> graph = new Graph<Vector3>();

        graph = new Graph<Vector3>();

        for (int i = 0; i < xList.Count; i++)
        {

            var node = new Node<Vector3>() { nodeValue = new Vector3(xList[i], yList[i], 0) };
           
            graph.Nodes.Add(node );
        }

        return graph;
    }




}
