using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftCandidateState : RaftBaseState
{
    [Header("Candidate Relative Property")]
    /// <summary>
    /// If a candidate timeout, it will start a new election by 
    /// increamenting its term and initiating another round of RequestVote RPCs 
    /// </summary>
    [HideInInspector]
    public float m_electionTimeout;

    // Election timeout range.
    // Use randomized election timeout to ensure that split vote are rare and can be resolved quikly
    public float m_maxElectionTimeout = 0.15f;
    public float m_minElectionTimeout = 0.3f;

    /// <summary>
    /// Timer for electionTimeout
    /// </summary>
    [HideInInspector]
    public float m_electionTimer;

    /// <summary>
    /// All servers in the cluster vote result for candidata
    /// Key : server id. Value : vote result
    /// </summary>
    public Dictionary<int, bool> m_voteResult;

    public override void InitializeState(RaftServerProperty serverProperty)
    {
        base.InitializeState(serverProperty);

        m_stateController.m_stateType = RaftStateType.Candidate;

        m_electionTimeout = Random.Range(m_minElectionTimeout, m_maxElectionTimeout);
        m_electionTimer = 0;

        // Vote for itself and issues RequestVote RPC to other server
        serverProperty.m_votedFor = serverProperty.m_serverId;
        IssueRquestVotes(serverProperty);
        InitiVoteGranded(serverProperty);
    }

    public override void UpdateState(RaftServerProperty serverProperty)
    {
        base.UpdateState(serverProperty);

        m_electionTimer += RaftTime.Instance.DeltTime;

        // If a candidate timeout, it will start a new election by
        // increamenting its term and initiating another round of RequestVote RPCs 
        if (m_electionTimer >= m_electionTimeout)
        {
            serverProperty.m_currentTerm++;

            m_electionTimeout = Random.Range(m_minElectionTimeout, m_maxElectionTimeout);
            m_electionTimer = 0;

            IssueRquestVotes(serverProperty);
            InitiVoteGranded(serverProperty);
        }
    }


    private void IssueRquestVotes(RaftServerProperty serverProperty)
    {
        int lastLogIndex = serverProperty.m_logs.Count - 1;
        int lastLogTerm = (lastLogIndex < 0) ? -1 : serverProperty.m_logs[lastLogIndex].m_term;

        var sender = serverProperty.GetComponent<RaftRPCSender>();
        sender.SendRequestVoteRPCArgu(serverProperty.m_currentTerm, serverProperty.m_serverId, lastLogIndex, lastLogTerm);
    }

    private void InitiVoteGranded(RaftServerProperty serverProperty)
    {
        m_voteResult = new Dictionary<int, bool>();

        foreach(var server in RaftServerManager.Instance.m_servers)
        {
            m_voteResult.Add(server.m_serverId, false);
        }

        m_voteResult[serverProperty.m_serverId] = true;
    }

}
