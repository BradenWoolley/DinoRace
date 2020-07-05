using UnityEngine;
using UnityEditor;
using System;

public class FloraPlacer : EditorWindow
{
    string objectBaseName = "";
    int objectId = 0;
    GameObject objectToSpawn;
    float objectScale;
    
    [MenuItem("Tools/FloraPlacer")]
    public static void ShowWindow()
    {
        GetWindow(typeof(FloraPlacer));
    }

    private void OnGUI()
    {
        GUILayout.Label("Place Flora", EditorStyles.boldLabel);

        objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);
        objectId = EditorGUILayout.IntField("ID", objectId);
        objectScale = EditorGUILayout.Slider("Object Scale", objectScale, 0.05f, 1f);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab To Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Place Object"))
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        if(objectToSpawn == null)
        {
            Debug.Log("Error: Please assign an object to be spawned.");
            return;
        }

        if(objectBaseName == string.Empty)
        {
            Debug.Log("Error: Please enter a base name for the object.");
            return;
        }

        Vector3 spawnPos = new Vector3(0, 0, 0);

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

        newObject.name = objectBaseName + "_" + objectId;
        newObject.transform.localScale = Vector3.one * objectScale;

        objectId++;
    }
}
