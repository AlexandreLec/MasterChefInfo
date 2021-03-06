using MCI_Common.Tools;
using System;
using Kitchen.Model;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kitchen.Tests
{
    /// <summary>
    /// Description résumée pour UnitTest1
    /// </summary>
    [TestClass]
    public class ToolsManagersTest
    {
        private ToolsManager Manager;
        private Tool TestTool;

        public ToolsManagersTest()
        {
            this.Manager = new ToolsManager(false);
            this.TestTool = new Tool();
            this.TestTool.Name = "Tool";
        }

        [TestMethod]
        public void TestLeaseTool()
        {
            this.Manager.AvailableTools.Add(this.TestTool.Name, 1);
            this.Manager.LeasedTools.Add(this.TestTool.Name, 0);

            bool resp = this.Manager.LeaseTool(this.TestTool);
            int nb = (int)this.Manager.LeasedTools[this.TestTool.Name];

            Assert.AreEqual(true, resp);
            Assert.AreEqual(1,nb);
        }

        [TestMethod]
        public void TestReleaseTool()
        {
            this.Manager.AvailableTools.Add(this.TestTool.Name, 1);
            this.Manager.LeasedTools.Add(this.TestTool.Name, 1);
            this.Manager.ReleaseTool(this.TestTool);

            int resp = (int)this.Manager.LeasedTools[this.TestTool.Name];

            Assert.AreEqual(0, resp);
        }
    }
}
