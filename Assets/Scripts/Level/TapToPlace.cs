using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    private GameObject indicator;
    private ARRaycastManager rayManager;
    private Pose placementPose;
    private bool placementIsValid = false;
    void Start()
    {
        indicator = transform.GetChild(0).gameObject;
        rayManager = FindObjectOfType<ARRaycastManager>();
        indicator.SetActive(false);
    }

    void Update()
    {
        UpdatePlacementPose();
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector2(Screen.width/2, Screen.height/2));
        var hits = new List<ARRaycastHit>();
        rayManager.Raycast(screenCenter, hits, TrackableType.Planes);

        if (hits.Count>0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
            if (!indicator.activeInHierarchy)
                indicator.SetActive(true);
        }
    }
}
