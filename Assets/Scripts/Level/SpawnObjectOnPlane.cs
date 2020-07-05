using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class SpawnObjectOnPlane : MonoBehaviour
{

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    [SerializeField]
    private GameObject placeablePrefab;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        //spawnedObject = Instantiate(placeablePrefab, Vector3.zero, Quaternion.identity);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if(raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            Vector3 pos = new Vector3(hitPose.position.x, hitPose.position.y + 0.05f, hitPose.position.z);
            if (spawnedObject == null)
            {
                
                spawnedObject = Instantiate(placeablePrefab, pos, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = pos;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
        }
    }
}
