using System.Collections.Generic;
using System.Threading.Tasks;
using FreelanceHunt.Models;
namespace FreelanceHunt.Service
{
    public interface IWebService
    {
        Task<string> GetMyMessage();
        Task<List<Project>> GetProjects();
        Task<List<Project>> GetProjectsByPage(ushort pageNumber);
        Task<List<Dialog>> GetDialogsByPage(ushort pageNumber);
        Task<Profile> GetAccountInfo(string login = "me");
        Task<ProjectDetail> GetProjectInfo(ulong projectId);
        Task<bool> SetRate(ulong projectId, Rate rateProject);
        Task<List<ChatMessage>> GetDialogMessages(ulong threadId);
    }
}
