using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaftServerEventMaster : MonoBehaviour
{
    /// <summary>
    /// Called when server change its term
    /// </summary>
    public Action<int> OnChangeTerm;

    /// <summary>
    /// Called when server apply a command.
    /// Parameter 1 : command.
    /// Parameter 2 : log term.
    /// Parameter 3 : log index.
    /// </summary>
    public Action<char?, int, int> OnApplyCommand;

    public void CallOnChangeTerm(int currentTerm)
    {
        if(OnChangeTerm != null)
        {
            OnChangeTerm(currentTerm);
        }
    }

    public void CallOnApplyCommand(char? command, int logTerm, int logIndex)
    {
        if(OnApplyCommand != null)
        {
            OnApplyCommand(command, logTerm, logIndex);
        }
    }
}
