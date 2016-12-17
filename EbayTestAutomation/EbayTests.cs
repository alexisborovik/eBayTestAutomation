using NUnit.Framework;
using EbayTestAutomation.Steps;

namespace EbayTestAutomation
{
    class EbayTests
    {
        private TestSteps steps = new TestSteps();

        [SetUp]
        public void Init()
        {
            steps.StartBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void RegisterWithEmptyFields()
        {
            steps.Register("", "", "", "", "","");
            Assert.True(steps.IsRegisterErrorsExist());
        }

        [Test]
        public void Register()
        {
            steps.Register("", "", "", "", "","Belarus");
            Assert.True(steps.IsRegisterErrorsExist());
        }
    }
}
