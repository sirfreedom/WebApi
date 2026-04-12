using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Entity;


namespace WebApi.Biz
{
    public class UserRateBiz
    {

        private readonly string _ConnectionString = string.Empty;

        public UserRateBiz(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<List<UserRate>> GetRating(int IdUserDataSeller)
        {
            UserRateData oUserRateData = new(_ConnectionString);
            List<UserRate> lUserRate;
            try
            {
                lUserRate = await oUserRateData.GetRating(IdUserDataSeller);
            }
            catch (Exception)
            {
                throw;
            }
            return lUserRate;
        }



    }
}
