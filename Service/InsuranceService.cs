using Model;
using Repository;

namespace Service
{
    public class InsuranceService
    {
        private InsuranceRepository _insuranceRepository;

        public InsuranceService() => _insuranceRepository = new();

        public int InsertInsurance(Insurance insurance) => _insuranceRepository.InsertInsurance(insurance);
    }
}