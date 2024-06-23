using Dapper;
using GamesHub.Infrastructure.DapperRepo;
using GamesHub.Model.AppSetting;
using GamesHub.Model.RequestModel;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GamesHub.Infrastructure.IDapperRepo
{
    public class UserDapperRepo : IUserDapperRep
    {
        private readonly IDbConnection _dbConnection;

        public UserDapperRepo()
        {
            _dbConnection = new SqlConnection(AppSettingProvider.SqlConnectionString);
        }
        public async Task<int> SetUserOtp(OtpRequestModel model)
        {
            Random random = new Random();
            var parameters = new DynamicParameters();
            parameters.Add("@MobileNo", model.MobileNo, DbType.Int32);
            parameters.Add("@Otp", random.Next(9999), DbType.Int32);
            parameters.Add("@SavedOtp", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbConnection.ExecuteAsync("usp_SetUserOtp", parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("@SavedOtp");
        }
    }
}
