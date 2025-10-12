using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputHandlerScript : MonoBehaviour
{
    private AllImputs allImputs;
    public static ImputHandlerScript _instance;
    public static ImputHandlerScript Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        allImputs = new AllImputs();

    }
    private void OnEnable()
    {
        allImputs.Enable();
    }
    private void OnDisable()
    {
        allImputs.Disable();
    }
    public Vector2 GetPlayerMove() => allImputs.PlayerActionMap.PlayerMove.ReadValue<Vector2>();
    public Vector2 GetPlayerCam() => allImputs.PlayerActionMap.Mouse.ReadValue<Vector2>();
    public float GetInteraction() => allImputs.PlayerActionMap.Interaction.ReadValue<float>();
    public float GetLMB() => allImputs.PlayerActionMap.LMB.ReadValue<float>();
    public float GetRMB() => allImputs.PlayerActionMap.RMB.ReadValue<float>();
    public float GetSpace() => allImputs.PlayerActionMap.Space.ReadValue<float>();
}
