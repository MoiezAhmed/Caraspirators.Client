
namespace Caraspirator.Core.Base;

public class ResponseHandler
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
    {
        this._stringLocalizer = stringLocalizer;
    }
    public Response<T> Deleted<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = Message == null ? "Deleted Successfully" : Message
        };
    }
    public Response<T> Success<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = "Added Successfully",
            Meta = Meta
        };
    }

    public Response<T> Unauthorized<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = Message == null ? _stringLocalizer[SharedResourcesKeys.UnAuthorized] : Message
        };
    }
    public Response<T> Unauthorized<T>()
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = "UnAuthorized"
        };
    }
    public Response<T> BadRequest<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? "Bad Request" : Message
        };
    }

    public Response<T> UnprocessableEntity<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = Message == null ? "UnprocessableEntity Request" : Message
        };
    }
    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? _stringLocalizer[SharedResourcesKeys.NotFound] : message
        };
    }

    public Response<T> Created<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = "Created",
            Meta = Meta
        };
    }
}