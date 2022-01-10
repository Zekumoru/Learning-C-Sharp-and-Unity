using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCollector : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabPickup;

    Sphere sphereTheCollector;
    List<GameObject> pickups = new List<GameObject>();

    #endregion

    #region Properties

    #region Deprecated
    //// Gets the next target pickup,
    //// if none found, returns null
    //public GameObject TargetPickup
    //{
    //    get
    //    {
    //        if (pickups.Count > 0)
    //        {
    //            return pickups[0];
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}
    #endregion

    // get all pickups currently in the game
    public List<GameObject> Pickups
    {
        get { return pickups; }
    }

    #endregion

    #region Methods

    // Initialization
    void Start()
    {
        // saved for efficiency
        GameObject sphereGameObject = GameObject.FindGameObjectWithTag("The Collector");
        sphereTheCollector = sphereGameObject.GetComponent<Sphere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // calculate world position of mouse click
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // create pickup then add to list
            GameObject pickup = Instantiate<GameObject>(prefabPickup);
            pickup.transform.position = mousePosition;
            pickups.Add(pickup);

            // have the sphere update its target
            sphereTheCollector.UpdateTarget(pickup);
        }
    }

    // remove the pickup from the game
    public void RemovePickup(GameObject pickup)
    {
        pickups.Remove(pickup);
        Destroy(pickup);
    }

    #endregion
}
