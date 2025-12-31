using System.Net;

namespace TaskManagement.Communication.Excepetions;

public abstract class TaskManagementException : SystemException
{
    public TaskManagementException(string errorMessage) : base(errorMessage)
    {
    }

    public abstract List<string> GetErrors();
    public abstract HttpStatusCode GetHttpStatusCode();
}
