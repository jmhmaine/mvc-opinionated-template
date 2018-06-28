namespace MvcOpinionatedTemplate.Core.Interfaces.Repositories.Base
{
    public interface IBaseRepository
    {
        IUserContext UserContext { get; set; }
    }
}
