/*

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class WearDetect : MonoBehaviour
{

    public Boolean wore { get; set; } = false;
    public Boolean active = false;
    string traineeName;
    List<GameObject> players = new List<GameObject>();
    List<GameObject> players_hide = new List<GameObject>();
    GameObject warningPanel;

    void Start()
    {
        warningPanel = GameObject.Find("WarningPanel");
        if (ParameterForScene.Role == "Expert")
        {
            active = true;
            traineeName = "PlayerPrefab(Clone)";

        }
        else
        {
            traineeName = "Trainee";
            GameObject LocalPlayer = GameObject.Find("Player");
            players.Add(LocalPlayer);
        }
        StartCoroutine(WaitForNetworkPlayer());

        StartCoroutine(WaitForNetworkPlayerHide());

    }
    IEnumerator WaitForNetworkPlayer()
    {
        while (GameObject.Find(traineeName) == null)
        {
            yield return null; // wait for next frame
        }

        GameObject NetworkPlayer = GameObject.Find(traineeName);
        players.Add(NetworkPlayer);
    }
    IEnumerator WaitForNetworkPlayerHide()
    {
        while (GameObject.Find(ParameterForScene.Role) == null)
        {
            yield return null; // wait for next frame
        }

        GameObject NetworkPlayer = GameObject.Find(ParameterForScene.Role);
        GameObject LocalPlayer = GameObject.Find("Player");
        players_hide.Add(LocalPlayer);
        players_hide.Add(NetworkPlayer);


        SetLayer();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerExit(Collider collider)
    {

        Debug.Log("out is : " + collider.name);
        if (collider.name == "index")
        {
            if (active)
            {
                if (!Object.HasStateAuthority)
                {
                    // 请求权限并在回调中调用 RPC
                    Object.RequestStateAuthority();
                    StartCoroutine(CallRpcWhenAuthorityGranted());
                }
                else
                {
                    // 如果已经有权限，直接调用 RPC
                    RPC_dressUp();
                }
            }
            else
            {

                string warningContent = "You can't wear it now, please go back to current guided step";
                warningPanel.GetComponent<WarningController>().setupWarning(warningContent, 1);
            }

        }

    }


    void SetLayer()
    {
        foreach (GameObject player in players_hide)
        {

            Transform[] myTransforms = player.GetComponentsInChildren<Transform>();
            foreach (var child in myTransforms)
            {
                //Debug.Log(" search for gloves");
                if (child.name == "Ch31_Body")
                {
                    //Debug.Log("I found the gloves");
                    string hiddenLayerName = "Hide for Player";
                    int hiddenLayer = LayerMask.NameToLayer(hiddenLayerName);
                    if (hiddenLayer == -1)
                    {
                        Debug.LogError("Layer 'Hide for Player' not found. Check your Tags and Layers.");
                        return;
                    }
                    child.gameObject.layer = hiddenLayer;
                }
            }
        }
    }
    void wearGloves()
    {
        foreach (GameObject player in players)
        {

            Transform[] myTransforms = player.GetComponentsInChildren<Transform>();
            foreach (var child in myTransforms)
            {
                //Debug.Log(" search for gloves");
                if ((child.name == "LeftGloves") || (child.name == "RightGloves"))
                {
                    //Debug.Log("I found the gloves");
                    child.gameObject.GetComponent<Renderer>().enabled = true;
                }
                if ((child.name == "Ch31_LeftHand") || (child.name == "Ch31_RightHand"))
                {
                    child.gameObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }

    }

    void wearGown()
    {
        foreach (GameObject player in players)
        {
            Debug.Log("Found:" + player.name);
            Transform[] myTransforms = player.GetComponentsInChildren<Transform>();
            foreach (var child in myTransforms)
            {
                //Debug.Log(" search for gown");
                if (child.name == "Gown_body")
                {
                    // Debug.Log("I found the child object");
                    child.gameObject.GetComponent<Renderer>().enabled = true;
                }
                if ((child.name == "Ch31_Sweater") || (child.name == "Ch31_Pants") || (child.name == "Ch31_Shoes"))
                {
                    child.gameObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }

    }

    void wearMask()
    {

        foreach (GameObject player in players)
        {
            Transform[] myTransforms = player.GetComponentsInChildren<Transform>();
            foreach (var child in myTransforms)
            {
                //Debug.Log(" search for Mask");
                if (child.name == "Mask.002")
                {
                    // Debug.Log("I found the child object");
                    child.gameObject.GetComponent<Renderer>().enabled = true;
                    string hiddenLayerName = "Hide for Player";
                    int hiddenLayer = LayerMask.NameToLayer(hiddenLayerName);
                    if (hiddenLayer == -1)
                    {
                        Debug.LogError("Layer 'Hide for Player' not found. Check your Tags and Layers.");
                        return;
                    }
                    child.gameObject.layer = hiddenLayer;

                }

            }
        }

    }

    void wearHood()
    {

        foreach (GameObject player in players)
        {
            Transform[] myTransforms = player.GetComponentsInChildren<Transform>();
            foreach (var child in myTransforms)
            {
                //Debug.Log(" search for Mask");
                if (child.name == "Gown_hood")
                {
                    // Debug.Log("I found the child object");
                    child.gameObject.GetComponent<Renderer>().enabled = true;
                    string hiddenLayerName = "Hide for Player";
                    int hiddenLayer = LayerMask.NameToLayer(hiddenLayerName);
                    if (hiddenLayer == -1)
                    {
                        Debug.LogError("Layer 'Hide for Player' not found. Check your Tags and Layers.");
                        return;
                    }
                    child.gameObject.layer = hiddenLayer;

                }

            }
        }

    }

    private IEnumerator CallRpcWhenAuthorityGranted()
    {
        // 等待直到权限被授予
        while (!Object.HasStateAuthority)
        {
            yield return null; // 每帧检查
        }
        RPC_dressUp();
        // 如果需要释放权限，可以在逻辑完成后释放
        Object.ReleaseStateAuthority();
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_dressUp()
    {


        this.gameObject.GetComponent<Renderer>().enabled = false;
        wore = true;
        Debug.Log("RPC is called !");
        this.name = this.name.Replace("(Clone)", "");
        if (this.name == "gloves")
        {
            wearGloves();
        }
        if (this.name == "gown")
        {
            wearGown();
        }
        if (this.name == "mask")
        {
            wearMask();
        }
        if (this.name == "hood")
        {
            wearHood();
        }
    }

    public bool PassOrNot(Instruc instruc)
    {

        //Debug.Log("check Click " + bu.name);
        active = true;
        if (wore)
        {
            Debug.Log("wore");
            return true;
        }
        else
        {
            //Debug.Log("Unwore");
            return false;
        }
    }

    public Tuple<Dictionary<string, Tuple<string, string>>, bool> TestPassOrNot(GradeRubric gradeRubric)
    {
        Dictionary<string, Tuple<string, string>> targetActualPairs = new Dictionary<string, Tuple<string, string>>();
        //Debug.Log("check Click " + bu.name);
        active = true;
        if (wore)
        {
            Debug.Log("wore");
            return new Tuple<Dictionary<string, Tuple<string, string>>, bool>(targetActualPairs, true);

        }
        else
        {
            Debug.Log("Unwore");
            return new Tuple<Dictionary<string, Tuple<string, string>>, bool>(targetActualPairs, false);
        }
    }

}

*/

