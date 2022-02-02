using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds the graph
/// </summary>
public class GraphBuilder : MonoBehaviour
{
    static Graph<Waypoint> graph;

    #region Constructor

    // Uncomment the code below after copying this class into the console
    // app for the automated grader. DON'T uncomment it now; it won't
    // compile in a Unity project

    /// <summary>
    /// Constructor
    /// 
    /// Note: The GraphBuilder class in the Unity solution doesn't 
    /// use a constructor; this constructor is to support automated grading
    /// </summary>
    /// <param name="gameObject">the game object the script is attached to</param>
    //public GraphBuilder(GameObject gameObject) :
    //    base(gameObject)
    //{
    //}

    #endregion

    /// <summary>
    /// Awake is called before Start
    ///
    /// Note: Leave this method public to support automated grading
    /// </summary>
    public void Awake()
    {
        // add nodes (all waypoints, including start and end) to graph
        graph = new Graph<Waypoint>();

        graph.AddNode(GameObject.FindGameObjectWithTag("Start").GetComponent<Waypoint>());
        graph.AddNode(GameObject.FindGameObjectWithTag("End").GetComponent<Waypoint>());
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            graph.AddNode(waypoint.GetComponent<Waypoint>());
        }

        // add neighbors for each node in graph
        Vector2 position;
        Vector2 neighborPos;
        float width = 3.5f;
        float height = 3f;
        foreach (var waypoint in graph.Nodes)
        {
            position = waypoint.Value.Position;
            foreach (var neighbor in graph.Nodes)
            {
                // ignore self
                if (waypoint == neighbor) continue;

                // find neighbors (within 3.5 units horizontally and 3 units vertically)
                neighborPos = neighbor.Value.Position;
                if (neighborPos.x > position.x - width && neighborPos.x < position.x + width &&
                    neighborPos.y > position.y - height && neighborPos.y < position.y + height)
                {
                    waypoint.AddNeighbor(neighbor, Vector2.Distance(position, neighborPos));
                }
            }
        }
    }

    /// <summary>
    /// Gets and sets the graph
    /// 
    /// CAUTION: Set should only be used by the autograder
    /// </summary>
    /// <value>graph</value>
    public static Graph<Waypoint> Graph
    {
        get { return graph; }
        set { graph = value; }
    }
}
