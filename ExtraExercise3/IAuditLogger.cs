using System.Collections.Generic;

namespace ExtraExercise3
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}