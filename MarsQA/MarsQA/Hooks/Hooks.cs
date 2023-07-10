using MarsQA.Utilities;
using TechTalk.SpecFlow;

namespace MarsQA.Hooks
{
    [Binding]
    public sealed class Hooks : CommonDriver
    {
        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            //Launching a browser
            Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Closing the browser
            // Close();
        }
    }
}