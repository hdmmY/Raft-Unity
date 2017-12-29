/// <summary>
/// Each entry contains a command and term when entry was received by leader
/// </summary>
[System.Serializable]
public struct RaftEntry
{
    public string m_command;

    /// <summary>
    /// When entry was received by leader
    /// </summary>
    public int m_term;
}