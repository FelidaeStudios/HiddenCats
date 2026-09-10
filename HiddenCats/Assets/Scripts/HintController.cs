using UnityEngine;
using System.Collections.Generic;

public class HintController : MonoBehaviour
{
    // Hint functionality.
    public GameObject cameraToMove;
    private GameObject[] objectsToFind;
    private GameObject hintObject;
    private Vector3 HintLocation;
    private GameObject objectController;
    private int index;

    void Start()
    {
        objectsToFind = GameObject.FindGameObjectsWithTag("Object");
    }

    /*void Update()
    {
        SelectRandomObject();
    }*/

    /*void OnMouseDown()
    {
        if (gameObject.CompareTag("Hint"))
        {
            // Show hint to the player.
            ShowHint();
        }
    }*/

    private void SelectRandomObject()
    {
        List<GameObject> unfoundObjects = new List<GameObject>();

        foreach (var obj in objectsToFind)
        {
            if (!obj.GetComponent<ObjectController>().isFound)
            {
                unfoundObjects.Add(obj);
            }
        }

        if (unfoundObjects.Count == 0)
        {
            Debug.LogWarning("All objects found!");
            return;
        }

        index = Random.Range(0, unfoundObjects.Count);
        hintObject = unfoundObjects[index];
    }

    private void GetHintLocation()
    {
        if (hintObject != null)
        {
            HintLocation = hintObject.GetComponent<ObjectController>().locationIndicator.transform.position;
        }
    }

    public void ShowHint()
    {
        // Move camera to an object with isFound = false.
        SelectRandomObject();
        GetHintLocation();
        Debug.Log("Hint object: " + hintObject.name);
        //cameraToMove.transform.position = new Vector3(hintObject.transform.position.x, hintObject.transform.position.y, cameraToMove.transform.position.z);
        cameraToMove.transform.position = new Vector3(HintLocation.x, HintLocation.y, cameraToMove.transform.position.z);
    }
}
