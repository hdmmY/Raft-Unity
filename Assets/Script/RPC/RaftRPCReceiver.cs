using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RaftServerProperty))]
public class RaftRPCReceiver : MonoBehaviour
{
    private RaftServerProperty _serverProperty;
    private RaftStateController _serverStateController;

    private void Awake()
    {
        _serverProperty = GetComponent<RaftServerProperty>();
        _serverStateController = GetComponent<RaftStateController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Receive(collision.gameObject.GetComponent<RaftBaseRPCModel>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Receive(collision.gameObject.GetComponent<RaftBaseRPCModel>());
    }

    private void Receive(RaftBaseRPCModel rpcModel)
    {
        if (rpcModel == null || rpcModel.m_target != transform)
        {
            return;
        }

        switch (rpcModel.m_rpcType)
        {
            case RaftRPCType.AppendEntriesArgu:
                ProcessAppendEntries(rpcModel);
                break;
            case RaftRPCType.AppendEntriesReturn:
                ProcessAppendEntriesReturn(rpcModel);
                break;
            case RaftRPCType.RequestVoteArgu:
                ProcessRequestVote(rpcModel);
                break;
            case RaftRPCType.RequestVoteReturn:
                ProcessRequestVoteReturn(rpcModel);
                break;
        }
    }


    private void ProcessAppendEntries(RaftBaseRPCModel rpcModel)
    {
        
    }

    private void ProcessAppendEntriesReturn(RaftBaseRPCModel rpcModel)
    {

    }

    private void ProcessRequestVote(RaftBaseRPCModel rpcModel)
    {
        
    }

    private void ProcessRequestVoteReturn(RaftBaseRPCModel rpcModel)
    {

    }
}
