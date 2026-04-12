using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Data
{
    public class UserRateData
    {
        private readonly string _ConnectionString = string.Empty;

        public UserRateData(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<UserRate>> GetRating(int IdUserDataSeller) 
        {
            IRead<UserRate> UserRateRepository = new ContextSQL<UserRate>(_ConnectionString);
            Dictionary<string,string> lParam = new Dictionary<string, string>();
            List<UserRate> lUserRate = new ();
            DataTable dt;
            try
            {
                dt = await UserRateRepository.Fill("GetRating",lParam);
                lUserRate = UserRate.ToList<UserRate>(dt);
            }
            catch (Exception)
            {
                throw;
            }
            return lUserRate;
        }
    }
}
