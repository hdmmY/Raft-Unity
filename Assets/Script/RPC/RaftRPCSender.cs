﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftRPCSender : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject m_appendEntriesArguPrefab;
    public GameObject m_appendEntriesRetuPrefab;
    public GameObject m_requestVoteArguPrefab;
    public GameObject m_requestVoteRetuPrefab;

    [Header("Icons")]
    public Sprite m_normalSendIcon;
    public Sprite m_voteTrueSendIcon;
    public Sprite m_voteFalseSendIcon;


    public bool SendAppendEntriesRPCArgu(RaftServerProperty serverProperty, Transform target)
    {
        return false;
    }

    public bool SendAppendEntriesRPCReturn(RaftServerProperty serverProperty, Transform target)
    {
        return false;
    }

    /// <summary>
    /// Invoked by candidates to gather vote
    /// </summary>
    /// <param name="term">Candidate's term</param>
    /// <param name="candidateId">Id of the candidate which request vote</param>
    /// <param name="lastLogIndex">Index of candidatas last log entry</param>
    /// <param name="lastLogTerm">Term of candidata last log entry</param>
    /// <returns></returns>
    public void SendRequestVoteRPCArgu(int term, int candidateId, int lastLogIndex, int lastLogTerm)
    {
        foreach (var server in RaftServerManager.Instance.m_servers)
        {
            if (server.m_serverId != candidateId)
            {
                GameObject requestVoteGo = Instantiate(m_requestVoteArguPrefab, transform.position, Quaternion.identity);

                // Set request vote arguments
                var argus = requestVoteGo.GetComponent<RaftRequestVoteArgus>();
                argus.m_rpcType = RaftRPCType.RequestVoteArgu;
                argus.m_target = server.transform;
                argus.m_term = term;
                argus.m_candidateId = candidateId;
                argus.m_lastLogIndex = lastLogIndex;
                argus.m_lastLogTerm = lastLogTerm;

                // Init move script
                var moveToward = requestVoteGo.GetComponent<MoveToward>();
                moveToward.m_target = server.transform;
                moveToward.enabled = true;

                // Set sprite
                requestVoteGo.GetComponent<SpriteRenderer>().sprite = m_normalSendIcon;
            }
        }

    }

    public bool SendRequestVoteRPCReturn(RaftServerProperty serverProperty, Transform target)
    {
        return false;
    }

}