using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereChanger : MonoBehaviour
{
    [SerializeField]
    GameObject prefabSphere0;
    [SerializeField]
    GameObject prefabSphere1;
    [SerializeField]
    GameObject prefabSphere2;

    // keep track of the current sphere
    GameObject currentSphere;

    // to avoid changing when left click is hold
    bool hasChangedSphere;

    // Start is called before the first frame update
    void Start()
    {
        currentSphere = Instantiate<GameObject>(
            prefabSphere0, Vector3.zero, Quaternion.identity);
        hasChangedSphere = false;
    }

    // Update is called once per frame
    void Update()
    {
        // change sphere on left mouse button
        if (Input.GetMouseButton(0) && !hasChangedSphere)
        {
            //// save current position then destroy current sphere
            //Vector3 position = currentSphere.transform.position;
            // test: make it so while holding, it still follows the mouse
            Vector3 position = Input.mousePosition;
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            string previousSphereName = currentSphere.name;
            Destroy(currentSphere);

            // instantiate a new random sphere
            int previousPrefabNumber = 0;
            int prefabNumber = Random.Range(0, 2);

            // prevent the same sphere to be instantiated
            if (previousSphereName == "Sphere1")
            {
                previousPrefabNumber = 1;
            }
            else if (previousSphereName == "Sphere2")
            {
                previousPrefabNumber = 2;
            }
            if (prefabNumber >= previousPrefabNumber)
            {
                prefabNumber++;
            }

            // instantiate the new sphere
            if (prefabNumber == 0)
            {
                currentSphere = Instantiate<GameObject>(
                    prefabSphere0, position, 
                    Quaternion.identity);
            }
            else if (prefabNumber == 1)
            {
                currentSphere = Instantiate<GameObject>(
                    prefabSphere1, position, 
                    Quaternion.identity);
            }
            else
            {
                currentSphere = Instantiate<GameObject>(
                    prefabSphere2, position,
                    Quaternion.identity);
            }

            // set changed sphere flag, set name, and clamp sphere
            currentSphere.name = "Sphere" + prefabNumber;
            currentSphere.GetComponent<Sphere>().ClampInScreen();
            hasChangedSphere = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // after the sphere has changed and left mouse is released
            hasChangedSphere = false;
        }
    }
}
