/*
using TMPro;
using UnityEngine;
using Avaturn.Core.Runtime.Scripts.Avatar;
using Avaturn.Core.Runtime.Scripts.Avatar.Data;

public class LoadCharacterV2 : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;

    public GameObject avaturnMobile; // Assign in Inspector (this is the AvaturnMobile prefab instance in the scene)

    private GameObject avatarInstance;
    private PrepareAvatar prepareAvatar;
    private DownloadAvatar downloadAvatar;
    private AvatarReceiver avatarReceiver;

    void Start()
    {
        // Find OVRCameraRig
        GameObject ovrRig = GameObject.Find("OVRCameraRig");
        if (ovrRig == null)
        {
            Debug.LogError("OVRCameraRig not found!");
            return;
        }

        // Load selected character
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
        if (selectedCharacter < 0 || selectedCharacter >= characterPrefabs.Length)
        {
            Debug.LogError("Invalid selectedCharacter index.");
            return;
        }

        GameObject prefab = characterPrefabs[selectedCharacter];
        avatarInstance = Instantiate(prefab, spawnPoint.position, Quaternion.identity, ovrRig.transform);
        label.text = prefab.name;

        // Hook into AvaturnMobile
        prepareAvatar = avaturnMobile.GetComponent<PrepareAvatar>();
        downloadAvatar = avaturnMobile.GetComponent<DownloadAvatar>();
        avatarReceiver = avaturnMobile.GetComponent<AvatarReceiver>();

        if (prepareAvatar == null || downloadAvatar == null || avatarReceiver == null)
        {
            Debug.LogError("AvaturnMobile is missing required components.");
            return;
        }

        // Step 1: Pass the character instance to PrepareAvatar
        prepareAvatar.SetCustomCharacter(avatarInstance);

        // Step 2: Hook download pipeline
        downloadAvatar.SetOnDownloaded(OnAvaturnAvatarDownloaded);
        avatarReceiver.SetOnReceived(OnAvatarReceivedFromWebview);
    }

    // Called when webview delivers avatar metadata
    void OnAvatarReceivedFromWebview(AvatarInfo avatarInfo)
    {
        Debug.Log("Avatar URL received: " + avatarInfo.Url);
        downloadAvatar.Download(avatarInfo);
    }

    // Called when the .glb avatar finishes downloading
    void OnAvaturnAvatarDownloaded(Transform downloadedModel)
    {
        Debug.Log("Avaturn avatar downloaded.");
        prepareAvatar.PrepareModel(downloadedModel);
    }
}
*/
