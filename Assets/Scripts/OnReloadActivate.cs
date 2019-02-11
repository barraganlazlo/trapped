using UnityEngine;

public class OnReloadActivate : MonoBehaviour
{
    public GameObject toActivateOnReload;
    public bool inverseActivation;
    void Awake()
    {

        if (LevelManager.instance.HasReloaded())
        {
            toActivateOnReload.SetActive(!inverseActivation);
        }
    }



}
