using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowingUpSpheres : MonoBehaviour
{
    [SerializeField]
    GameObject prefabExplosion;

    [SerializeField]
    Sprite blueSphereSprite;
    [SerializeField]
    Sprite purpleSphereSprite;
    [SerializeField]
    Sprite redSphereSprite;

    List<GameObject> gameObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        #region Old Way
        //if (Input.GetAxis("BlowUpBlueSpheres") > 0 ||
        //    Input.GetAxis("BlowUpPurpleSpheres") > 0 ||
        //    Input.GetAxis("BlowUpRedSpheres") > 0)
        //{
        //    gameObjects.Clear();
        //    gameObjects.AddRange(Object.FindObjectsOfType<GameObject>());
        //}

        //if (Input.GetAxis("BlowUpBlueSpheres") > 0)
        //{
        //    BlowUpSpheres(SphereColor.Blue, gameObjects);
        //}
        //if (Input.GetAxis("BlowUpPurpleSpheres") > 0)
        //{
        //    BlowUpSpheres(SphereColor.Purple, gameObjects);
        //}
        //if (Input.GetAxis("BlowUpRedSpheres") > 0)
        //{
        //    BlowUpSpheres(SphereColor.Red, gameObjects);
        //}
        #endregion

        if (Input.GetAxis("BlowUpBlueSpheres") > 0)
        {
            BlowUpSpheres(SphereColor.Blue);
        }
        if (Input.GetAxis("BlowUpPurpleSpheres") > 0)
        {
            BlowUpSpheres(SphereColor.Purple);
        }
        if (Input.GetAxis("BlowUpRedSpheres") > 0)
        {
            BlowUpSpheres(SphereColor.Red);
        }
    }

    void BlowUpSpheres(SphereColor color)
    {
        #region Old Way
        //for (int i = gameObjects.Count - 1; i >= 0; i--)
        //{
        //    SpriteRenderer spriteRenderer = 
        //        gameObjects[i].GetComponent<SpriteRenderer>();
        //    if (spriteRenderer != null)
        //    {
        //        Sprite sprite = spriteRenderer.sprite;
        //        if ((color == SphereColor.Blue && sprite == blueSphereSprite) ||
        //            (color == SphereColor.Purple && sprite == purpleSphereSprite) ||
        //            (color == SphereColor.Red && sprite == redSphereSprite))
        //        {
        //            BlowUpSphere(gameObjects[i]);
        //        }
        //    }
        //}
        #endregion

        gameObjects.Clear();
        gameObjects.AddRange(
            GameObject.FindGameObjectsWithTag(color.ToString()));
        for (int i = gameObjects.Count - 1; i >= 0; i--)
        {
            BlowUpSphere(gameObjects[i]);
        }
    }

    void BlowUpSphere(GameObject sphere)
    {
        Instantiate(prefabExplosion, sphere.transform.position, 
            Quaternion.identity);
        Destroy(sphere);
    }
}
