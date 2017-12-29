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
                ProcessRequestVote((RaftRequestVoteArgus)rpcModel);
                break;
            case RaftRPCType.RequestVoteReturn:
                ProcessRequestVoteReturn(rpcModel);
                break;
        }

        Destroy(rpcModel.gameObject);
    }


    private void ProcessAppendEntries(RaftBaseRPCModel rpcModel)
    {

    }

    private void ProcessAppendEntriesReturn(RaftBaseRPCModel rpcModel)
    {

    }

    private void ProcessRequestVote(RaftRequestVoteArgus rpcModel)
    {
        bool voteGranted;

        // Reply false if term < currentTerm
        if (rpcModel.m_term < _serverProperty.m_currentTerm)
        {
            voteGranted = false;
        }
        //  If votedFor is null or candidateId, and candidate’s log is at least as up - to - date as receiver’s log, grant vote
        if (_serverProperty.m_votedFor <= 0)
        {
            int lastIndex = _serverProperty.m_logs.Count - 1;

            if (lastIndex < 0)
            {
                voteGranted = true;
            }
            else
            {
                int lastTerm = _serverProperty.m_logs[lastIndex].m_term;
                voteGranted = CompareLogPriority(rpcModel.m_lastLogIndex, rpcModel.m_lastLogTerm, lastIndex, lastTerm) >= 0;
            }
        }
        else
        {
            voteGranted = false;
        }

        // Chage server property if vote granted
        if(voteGranted)
        {
            _serverProperty.m_votedFor = rpcModel.m_candidateId;
        }

        // Send the returns
        var candidate = RaftServerManager.Instance.GetServer(rpcModel.m_candidateId).transform;
        GetComponent<RaftRPCSender>().SendRequestVoteRPCReturn(_serverProperty.m_currentTerm, voteGranted, candidate);
    }

    private void ProcessRequestVoteReturn(RaftBaseRPCModel rpcModel)
    {

    }


    // Raft determines which of two logs is more up-to-date by comparing the index and term of the last entries in the logs
    // If the logs have last entries with different terms, then the log with the later term is more up-to-date.
    // If the logs end with the same term, then whichever log is longer is more up-to-date.
    /// <summary>
    /// Compare which log is more up-to-date
    /// </summary> 
    /// <returns>Return positive number if log1 is more up-to-date than log2. Return zero if their priority are same</returns>
    private int CompareLogPriority(int lastLogIndex1, int lastLogTerm1, int lastLogIndex2, int lastLogTerm2)
    {
        if (lastLogTerm1 != lastLogTerm2)
        {
            return lastLogTerm1 - lastLogTerm2;
        }
        else
        {
            return lastLogIndex1 - lastLogIndex2;
        }
    }
}
