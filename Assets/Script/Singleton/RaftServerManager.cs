using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftServerManager : RaftSingletonMonoBehavior<RaftServerManager>
{
    /// <summary>
    /// Total server in current enviroment. Including active server and deactive server
    /// </summary>
    public List<RaftServerProperty> m_servers;
}
