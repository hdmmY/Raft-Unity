using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftClient : RaftSingletonMonoBehavior<RaftClient>
{
    public Queue<char?> m_commandCache;

    public List<char?> m_historicCommand;

    /// <summary>
    /// Add a command into command cache
    /// </summary>
    public void AddCommand(char? command)
    {
        if(m_commandCache == null)
        {
            m_commandCache = new Queue<char?>();
        }
        m_commandCache.Enqueue(command);
    
        if(m_historicCommand == null)
        {
            m_historicCommand = new List<char?>();
        }
        m_historicCommand.Add(command);
    }


    /// <summary>
    /// Get a command from command cache. Return null if there is no command.
    /// </summary>
    public char? GetCommand()
    {
        if(m_commandCache != null && m_commandCache.Count > 0)
        {
            return m_commandCache.Dequeue();
        }

        return null;
    }

}
