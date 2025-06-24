using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;

    void Start()
    {
        // Find OVRCameraRig in the scene
        GameObject ovrRig = GameObject.Find("OVRCameraRig"); // Or "OVRPlayerController" if that's your root object

        if (ovrRig == null)
        {
            Debug.LogError("OVRCameraRig not found!");
            return;
        }

        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        if (selectedCharacter < 0 || selectedCharacter >= characterPrefabs.Length)
        {
            Debug.LogError("Invalid selectedCharacter index.");
            return;
        }

        GameObject prefab = characterPrefabs[selectedCharacter];

        // Instantiate avatar as a child of OVRCameraRig
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity, ovrRig.transform);

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
