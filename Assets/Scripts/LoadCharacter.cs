using Oculus.Platform;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;

    /*
    Transform FindHeadMesh(Transform root)
    {
        foreach (Transform t in root.GetComponentsInChildren<Transform>())
        {
            if (t.name.ToLower().Contains("head") && t.GetComponent<Renderer>() != null)
            {
                UnityEngine.Debug.Log("Removed Head: " + t.name);
                return t;
            }
        }
        return null;
    }

    void SetLayerRecursively(Transform obj, int layer)
    {
        obj.gameObject.layer = layer;
        foreach (Transform child in obj)
        {
            UnityEngine.Debug.Log("Removed: " + child.name);
            SetLayerRecursively(child, layer);
        }
    }
    */

    void Start()
    {
        // Find OVRCameraRig in the scene
        GameObject ovrRig = GameObject.Find("OVRCameraRig"); // Or "OVRPlayerController" if that's your root object

        if (ovrRig == null)
        {
            UnityEngine.Debug.LogError("OVRCameraRig not found!");
            return;
        }

        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        if (selectedCharacter < 0 || selectedCharacter >= characterPrefabs.Length)
        {
            UnityEngine.Debug.LogError("Invalid selectedCharacter index.");
            return;
        }

        GameObject prefab = characterPrefabs[selectedCharacter];

        //Instantiate avatar as a child of OVRCameraRig
        GameObject avatar = Instantiate(prefab, spawnPoint.position, Quaternion.identity, ovrRig.transform);

        //Test code for hiding head mesh in first person POV
        //Transform head = avatar.transform.Find("FixedDefaultManAvatar/Armature/Hips/Spine/Spine1/Spine2/Neck/Head");

        //FixedDefaultManAvatar/Armature/Hips/Spine/Spine1/Spine2/Neck/Head
        //FixedDefaultManAvatar/Armature/Hips/Spine/Spine1/Spine2/Neck/Head/Head_end

        /*
        Transform head = FindHeadMesh(avatar.transform);
        if (head != null)
        {
            head.gameObject.layer = LayerMask.NameToLayer("FirstPersonHidden");
        }
        */

        /*
        Transform head = FindHeadMesh(avatar.transform);

        if (head != null)
        {
            int hiddenLayer = LayerMask.NameToLayer("FirstPersonHidden");
            SetLayerRecursively(head, hiddenLayer);
        }
        */

        label.text = prefab.name;

    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LoadCharacter : MonoBehaviour
{
	public GameObject[] characterPrefabs;
	public Transform spawnPoint;

    public TMP_Text label;

    GameObject ovrRig = GameObject.Find("OVRCameraRig"); // Or adjust if it's under "OVRPlayerController"

    void Start()
	{
		int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		GameObject prefab = characterPrefabs[selectedCharacter];
		GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity, ovrRig);
		label.text = prefab.name;
	}

    private GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion identity, GameObject ovrRig)
    {
        throw new NotImplementedException();
    }
}
*/


/*
public GameObject avatarPrefab; // Assign your avatar prefab in the Inspector

void Start()
{
    // Find the OVRCameraRig
    GameObject ovrRig = GameObject.Find("OVRCameraRig"); // Or adjust if it's under "OVRPlayerController"
    if (ovrRig != null)
    {
        // Find the CenterEyeAnchor (the camera's position)
        Transform centerEye = ovrRig.transform.Find("TrackingSpace/CenterEyeAnchor");

        if (centerEye != null)
        {
            // Instantiate avatar and parent to CenterEyeAnchor
            GameObject avatar = Instantiate(avatarPrefab, centerEye);

            // Optional: Adjust avatar's position/rotation relative to the camera
            avatar.transform.localPosition = Vector3.zero;
            avatar.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogWarning("CenterEyeAnchor not found.");
        }
    }
    else
    {
        Debug.LogError("OVRCameraRig not found.");
    }
}
*/
