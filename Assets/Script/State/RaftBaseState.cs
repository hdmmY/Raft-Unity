using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftBaseState : MonoBehaviour
{
    [Header("References")]
    public RaftStateController m_stateController;

    public virtual void InitializeState(RaftServerProperty serverProperty) { }

    public virtual void UpdateState(RaftServerProperty serverProperty) { }
}
