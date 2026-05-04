using UnityEngine;
using UnityEngine.InputSystem;

public class ManualRobotArm : MonoBehaviour
{
    [SerializeField] private RobotArm arm;

    private void Update()
    {
        float baseA = 0f;
        float a1 = 0f;
        float a2 = 0f;
        
        if (Keyboard.current.qKey.wasPressedThisFrame) baseA = -1f;
        if (Keyboard.current.eKey.wasPressedThisFrame) baseA =  1f;

        if (Keyboard.current.aKey.wasPressedThisFrame) a1 = -1f;
        if (Keyboard.current.dKey.wasPressedThisFrame) a1 =  1f;

        if (Keyboard.current.wKey.wasPressedThisFrame) a2 = -1f;
        if (Keyboard.current.sKey.wasPressedThisFrame) a2 =  1f;

        arm.ApplyContinuousActions(baseA, a1, a2);

        if (Keyboard.current.rKey.wasPressedThisFrame)
            arm.ResetArm();
    }
}