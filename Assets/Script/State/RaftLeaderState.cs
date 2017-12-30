using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftLeaderState : RaftBaseState
{
    public override void InitializeState(RaftServerProperty serverProperty)
    {
        base.InitializeState(serverProperty);

        m_stateController.m_stateType = RaftStateType.Leader;
        Debug.Log("I am a leader! My id = " + serverProperty.m_serverId);
    }

    public override void UpdateState(RaftServerProperty serverProperty)
    {
        base.UpdateState(serverProperty);
    }
}
