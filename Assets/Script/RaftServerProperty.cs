using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftServerProperty : MonoBehaviour
{
    // ***************  Persistent *********************
    // Update on stable storage before responding to RPCs
    [Header("Persistant Properties")]
    /// <summary>
    /// Id that can identify a server
    /// </summary>
    public int m_serverId;

    /// <summary>
    /// True means this server is on working, false means this server stop or crash 
    /// </summary>
    public bool m_working;

    /// <summary>
    /// Last term this server has ever seen
    /// Initialize to zero on first boot and increases monotonically
    /// </summary>
    public int m_currentTerm;

    /// <summary>
    /// Candidate Id that received vote in current term.(or null if none)
    /// </summary>
    public int m_votedFor;

    /// <summary>
    /// Log entries. 
    /// </summary>
    public List<RaftEntry> m_logs;


    // ***************** Volatile On All Servers ********************************
    [Space]
    [Header("Volatile Property")]
    /// <summary>
    /// Index of highest log entry known to be committed.
    /// Initialize to zero, increase monotonically
    /// </summary>
    public int m_commitIndex;

    /// <summary>
    /// Index of highest log entry apply to server
    /// Initialize to zero, increase monotonically
    /// </summary>
    public int m_lastApplied;


    // ****************** Volatile On Leaders ***********************************
    // Reinitialized after election
    [Space]
    [Header("Volatile Property for Leader")]
    /// <summary>
    /// For each server, index of next log entry send to that server
    /// Initialized to leader last log index + 1
    /// </summary>
    public List<int> m_nextIndex;

    /// <summary>
    /// For each server, index of highest log entry known to be replicated on server
    /// Initialize to 0, increase monotonically
    /// </summary>
    public List<int> m_matchIndex;
                    

}
