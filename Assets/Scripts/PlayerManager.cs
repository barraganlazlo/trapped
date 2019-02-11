using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public CharacterController2D mainPlayer;
    #region Monobehaviour API
    void Awake()
    {
        instance = this;
    }
    #endregion
}
