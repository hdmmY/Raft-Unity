/// <summary>
/// Each entry contains a command and term when entry was received by leader
/// </summary>
[System.Serializable]
public struct RaftEntry
{
    public char? m_command;

    /// <summary>
    /// When entry was received by leader.
    /// -1 if this entry not applied.
    /// </summary>
    public int m_term;

    public RaftEntry(char? command, int term)
    {
        this.m_command = command;
        this.m_term = term;
    }
}