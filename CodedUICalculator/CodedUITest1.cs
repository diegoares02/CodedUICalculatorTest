using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUICalculator
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", @"|DataDirectory|\\Data.xml", "Test", DataAccessMethod.Sequential), DeploymentItem("Data.xml"), TestMethod]
        public void CalculatorOperationsTestMethod()
        {
            foreach (char c in TestContext.DataRow["operation"].ToString())
            {
                switch (c) 
                {
                    case '+':
                        this.UIMap.Click("Add");
                        break;
                    case '-':
                        this.UIMap.Click("Subtract");
                        break;
                    case '*':
                        this.UIMap.Click("Multiply");
                        break;
                    case '/':
                        this.UIMap.Click("Divide");
                        break;
                    case '(':
                        this.UIMap.Click("Open parenthesis");
                        break;
                    case ')':
                        this.UIMap.Click("Close parenthesis");
                        break;

                    default:
                        this.UIMap.Click(c.ToString());
                        break;
                }
            }
            this.UIMap.ClickEquals();
            string val=this.UIMap.UICalculatorWindow.UIItem11Window.UIItem11Text.DisplayText;
            string res=TestContext.DataRow["answer"].ToString();
            Assert.AreEqual(res, val);
        }
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.UIMap.OpenCalculator();
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            this.UIMap.CloseCalculator();

        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
