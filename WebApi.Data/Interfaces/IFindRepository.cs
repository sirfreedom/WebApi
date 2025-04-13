using System.Collections.Generic;

namespace WebApi.Data
{
    public interface IFindRepository
    {
        string EntityName { get; }

        List<dynamic> Find(Dictionary<string, string> lParam);

    }
}
