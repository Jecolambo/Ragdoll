using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollBehavior : MonoBehaviour
{
    private Rigidbody[] ragdollRG;
    private Collider[] ragdollCollider;

    public bool isRagdoll;
    void Start()
    {
        ragdollRG = GetComponentsInChildren<Rigidbody>();
        ragdollCollider = GetComponentsInChildren<Collider>();
    }
    void Update()
    {
        SetRagdollEnable(isRagdoll);
    }
    public void SetRagdollEnable(bool enable)
    {
        foreach(var rb in ragdollRG)
        {
            rb.isKinematic = enabled;
        }
        foreach (var col in ragdollCollider)
        {
            col.enabled = !enabled;
        }
    }

}
