using UnityEngine;

public class RobotArm : MonoBehaviour
{
    [Header("Joint transforms")]
    [SerializeField] private Transform baseJoint;
    [SerializeField] private Transform joint1;
    [SerializeField] private Transform joint2;
    [SerializeField] private Transform endEffector;

    [Header("Angle limits")]
    [SerializeField] private float baseMin = -180f;
    [SerializeField] private float baseMax = 180f;
    [SerializeField] private float joint1Min = -60f;
    [SerializeField] private float joint1Max = 60f;
    [SerializeField] private float joint2Min = -120f;
    [SerializeField] private float joint2Max = 120f;

    [Header("Control")]
    [SerializeField] private float degreesPerStep = 2f;

    private float baseAngle;
    private float joint1Angle;
    private float joint2Angle;

    public Transform EndEffector => endEffector;
    public float BaseAngle => baseAngle;
    public float Joint1Angle => joint1Angle;
    public float Joint2Angle => joint2Angle;

    private void Awake()
    {
        ApplyPose();
    }

    public void ResetArm(float baseA = 0f, float a1 = 0f, float a2 = 0f)
    {
        baseAngle = Mathf.Clamp(baseA, baseMin, baseMax);
        joint1Angle = Mathf.Clamp(a1, joint1Min, joint1Max);
        joint2Angle = Mathf.Clamp(a2, joint2Min, joint2Max);
        ApplyPose();
    }

    public void ApplyContinuousActions(float baseAction, float action1, float action2)
    {
        baseAngle += Mathf.Clamp(baseAction, -1f, 1f) * degreesPerStep;
        joint1Angle += Mathf.Clamp(action1, -1f, 1f) * degreesPerStep;
        joint2Angle += Mathf.Clamp(action2, -1f, 1f) * degreesPerStep;

        baseAngle = Mathf.Clamp(baseAngle, baseMin, baseMax);
        joint1Angle = Mathf.Clamp(joint1Angle, joint1Min, joint1Max);
        joint2Angle = Mathf.Clamp(joint2Angle, joint2Min, joint2Max);

        ApplyPose();
    }

    private void ApplyPose()
    {
        if (baseJoint != null)
            baseJoint.localRotation = Quaternion.Euler(0f, baseAngle, 0f);

        if (joint1 != null)
            joint1.localRotation = Quaternion.Euler(joint1Angle, 0f, 0f);

        if (joint2 != null)
            joint2.localRotation = Quaternion.Euler(joint2Angle, 0f, 0f);
    }

    public Vector3 GetEndEffectorPosition()
    {
        return endEffector != null ? endEffector.position : Vector3.zero;
    }
}