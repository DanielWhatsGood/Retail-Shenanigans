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

    //GameObject ovrRig = GameObject.Find("OVRCameraRig"); // Or adjust if it's under "OVRPlayerController"

    void Start()
	{
		int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		GameObject prefab = characterPrefabs[selectedCharacter];
		GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
		label.text = prefab.name;
	}

    private GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion identity, GameObject ovrRig)
    {
        throw new NotImplementedException();
    }
}


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
