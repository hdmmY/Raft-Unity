using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftRequestVoteReturns : RaftBaseRPCModel
{
    /// <summary>
    /// Current term, for candidate to update itself
    /// </summary>
    public int m_term;

    /// <summary>
    /// True means candidate received vote
    /// </summary>
    public bool m_voteGranted;
}
