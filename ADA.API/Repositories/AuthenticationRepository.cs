using ADA.API.DBManager;
using ADAClassLibrary;
using Dapper;
using ADA.API.IRepositories;
using System.Data;
using ADAClassLibrary.DTOLibraries;

namespace ADA.API.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IDapper _dapper;

        public AuthenticationRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public ClaimDTO Authenticate(LoginCredentials obj)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Username", obj.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", obj.Password, DbType.String, ParameterDirection.Input);

            var data= _dapper.Get<ClaimDTO>(@"[dbo].[usp_ValidateLogin]", parameters);
            ClaimDTO claimDTO = null;
            if(data != null)
            {
                claimDTO = new ClaimDTO();
                claimDTO = data;
                //claimDTO.DesignationId = new System.Collections.Generic.List<int>();
                //if(data.DesignationIdsText != null)
                //{
                //    claimDTO.DesignationId = data.DesignationIdsText.Split(',').Select(x => int.Parse(x)).ToList();
                //}
                ////claimDTO.MinApprovalAmount = new System.Collections.Generic.List<decimal>();
                ////if (data.MinApprovalAmountText != null)
                ////{
                ////    claimDTO.MinApprovalAmount = data.MinApprovalAmountText.Split(',').Select(x => x==null?0:decimal.Parse(x)).ToList();
                ////}
                ////claimDTO.MaxApprovalAmount = new System.Collections.Generic.List<decimal>();
                ////if (data.MaxApprovalAmountText != null)
                ////{
                ////    claimDTO.MaxApprovalAmount = data.MaxApprovalAmountText.Split(',').Select(x => x == null ? 0 : decimal.Parse(x)).ToList();
                ////}
                //claimDTO.Companies = new System.Collections.Generic.List<int>();
                //if (data.CompanyIdsText != null)
                //{
                //    claimDTO.Companies = data.CompanyIdsText.Split(',').Select(x => int.Parse(x)).ToList();
                //}
                //claimDTO.Factories = new System.Collections.Generic.List<int>();
                //if (data.FactoryIdsText != null)
                //{
                //    claimDTO.Factories = data.FactoryIdsText.Split(',').Select(x => int.Parse(x)).ToList();
                //}
                //claimDTO.Branches = new System.Collections.Generic.List<int>();
                //if (data.BranchIdsText != null)
                //{
                //    claimDTO.Branches = data.BranchIdsText.Split(',').Select(x => int.Parse(x)).ToList();
                //}
                //claimDTO.Teams = new System.Collections.Generic.List<int>();
                //if (data.TeamIdsText != null)
                //{
                //    claimDTO.Teams = data.TeamIdsText.Split(',').Select(x => int.Parse(x)).ToList();
                //}

            }
            return claimDTO;
        }

       
    }
}
