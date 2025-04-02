namespace TA_Upsidedown
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Redirect Console output to TestContext to capture the output
            Console.SetOut(new System.IO.StringWriter());
        }

        [Test]
        public void Test1()
        {
            // Output to the Test Explorer Output window
            TestContext.WriteLine("Running Test1...");

            GameDriver.doTheThing();

            // This ensures that Console output will appear in the Test Explorer output
            string consoleOutput = Console.Out.ToString();
            TestContext.WriteLine(consoleOutput);

            Assert.Pass();
        }
    }
}