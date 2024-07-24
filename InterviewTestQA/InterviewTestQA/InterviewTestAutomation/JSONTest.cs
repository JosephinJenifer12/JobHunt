using InterviewTestQA.InterviewTestAutomation.Model;
using Newtonsoft.Json;

namespace InterviewTestQA
{
    public class JSONTest
    {
        private readonly List<CostData> _costData;
        public JSONTest()
        {
            var jsonData = File.ReadAllText(@"InterviewTestAutomation\Data\Cost Analysis.json");
            _costData = JsonConvert.DeserializeObject<List<CostData>>(jsonData);
        }

        [Fact]
        public void DeserializeCostData_VerifyCount()
        {
            Assert.NotNull(_costData);
            Assert.Equal(53, _costData.Count());
        }
        [Fact]
        public void DeserializeCostData_AssertTopItemByCost()
        {
            Assert.NotNull(_costData);
            Assert.Equal(0, _costData.OrderByDescending(x => x.Cost).First().CountryId);
        }
        [Fact]
        public void DeserializeCostData_AssertCostSum()
        {
            Assert.NotNull(_costData);
            Assert.Equal(77911.37, Math.Round(_costData.Where(x => x.YearId == "2016").Sum(y => y.Cost), 2));
        }
    }
}