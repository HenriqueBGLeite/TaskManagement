using System.Net;

namespace TaskManagement.Communication.Excepetions;

public class NotFoundException : TaskManagementException
{
    public NotFoundException(string errorMessages) : base(errorMessages)
    {
    }

    public override List<string> GetErrors() => [Message];

    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}
