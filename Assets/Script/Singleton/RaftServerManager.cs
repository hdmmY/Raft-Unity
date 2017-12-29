using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftServerManager : RaftSingletonMonoBehavior<RaftServerManager>
{
    /// <summary>
    /// Total server in current enviroment. Including active server and deactive server
    /// </summary>
    public List<RaftServerProperty> m_servers;

    /// <summary>
    /// Get a server by its id
    /// </summary>           
    /// <returns>Return server property or null if not find</returns>
    public RaftServerProperty GetServer(int serverId)
    {
        foreach(var server in m_servers)
        {
            if(server.m_serverId == serverId)
            {
                return server;
            }
        }

        return null;
    }
}
