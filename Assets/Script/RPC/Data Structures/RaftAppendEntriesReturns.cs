using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftAppendEntriesReturns : RaftBaseRPCModel
{
    /// <summary>
    /// Follower's current term, for leader to update itself
    /// </summary>
    public int m_term;

    /// <summary>
    /// True if follower contain log entry matching prevLogIndex and prevLogTerm
    /// </summary>
    public bool m_success;
}
