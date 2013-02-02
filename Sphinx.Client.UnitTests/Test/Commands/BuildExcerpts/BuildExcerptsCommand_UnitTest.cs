using System;
using System.Collections;
using System.IO;
using SharpTestsEx;
using Sphinx.Client.Commands.BuildExcerpts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.Commands.BuildExcerpts.Moles;
using Sphinx.Client.Connections;
using System.Collections.Generic;
using Sphinx.Client.IO;
using Sphinx.Client.Commands;
using Sphinx.Client.IO.Moles;
using Sphinx.Client.Network;
using Sphinx.Client.UnitTests.Mock.Connections;
using Sphinx.Client.UnitTests.Mock.IO;
using Sphinx.Client.UnitTests.Mock.Network;

namespace Sphinx.Client.UnitTests.Test.Commands.BuildExcerpts
{
	[TestClass]
	public class BuildExcerptsCommand_UnitTest
	{
		public TestContext TestContext { get; set; }

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		#region Tests

		#region Constructors
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "ArgumentNullException must be thrown for null argument")]
		public void Constructor_NullConnection_ThrowsArgumentNullException()
		{
			new BuildExcerptsCommand(null);
		}

		[TestMethod]
		public void Constructor_PassValidArguments_CopyValues()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				string[] documents = new string[] { "doc 1", "doc 2", "doc 3" };
				string[] keywords = new string[] { "keyword1", "keyword2" };
				string index = "test";

				BuildExcerptsCommand target = new BuildExcerptsCommand(connection, documents, keywords, index);

				target.Documents.Should().Have.SameValuesAs(documents);
				target.Keywords.Should().Have.SameValuesAs(keywords);
				target.Index.Should().Be.EqualTo(index);
			}
		}
		
		#endregion

		#region Properties and fields
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "ArgumentException must be thrown for null value")]
		public void BeforeMatchTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.BeforeMatch, BuildExcerptsCommand_Accessor.DEFAULT_BEFORE_MATCH);
				// valid value
				string expected = "<pre>";
				target.BeforeMatch = expected;

				target.BeforeMatch.Should().Be.EqualTo(expected);
				// invalid value
				target.BeforeMatch = null;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "ArgumentException must be thrown for null value")]
		public void AfterMatchTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.AfterMatch, BuildExcerptsCommand_Accessor.DEFAULT_AFTER_MATCH);
				// valid value
				string expected = "</pre>";
				target.AfterMatch = expected;
				string actual = target.AfterMatch;
				Assert.AreEqual(expected, actual);
				// invalid value
				target.AfterMatch = null;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException must be thrown for negative value")]
		public void WordsAroundKeywordTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.WordsAroundKeyword, BuildExcerptsCommand_Accessor.DEFAULT_WORDS_AROUND_KEYWORD);
				// valid value
				int expected = 0;
				target.WordsAroundKeyword = expected;
				Assert.AreEqual(expected, target.WordsAroundKeyword);
				// invalid value
				target.WordsAroundKeyword = -1;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException must be thrown for zero value")]
		public void SnippetSizeLimitTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.SnippetSizeLimit, BuildExcerptsCommand_Accessor.DEFAULT_SNIPPET_SIZE_LIMIT);
				// valid value
				int expected = 1;
				target.SnippetSizeLimit = expected;
				Assert.AreEqual(expected, target.SnippetSizeLimit);
				// invalid value
				target.SnippetSizeLimit = 0;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), "ArgumentNullException must be thrown for null value")]
		public void SnippetsDelimiterTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.SnippetsDelimiter, BuildExcerptsCommand_Accessor.DEFAULT_SNIPPETS_DELIMITER);
				// valid value
				string expected = String.Empty;
				target.SnippetsDelimiter = expected;
				Assert.AreEqual(expected, target.SnippetsDelimiter);
				// invalid value
				target.SnippetsDelimiter = null;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException must be thrown for null value")]
		public void SnippetsCountLimitTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.SnippetsCountLimit, BuildExcerptsCommand_Accessor.DEFAULT_SNIPPETS_COUNT_LIMIT);
				// valid value
				int expected = 1;
				target.SnippetsCountLimit = expected;
				Assert.AreEqual(expected, target.SnippetsCountLimit);
				// invalid value
				target.SnippetsCountLimit = -1;
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException), "ArgumentOutOfRangeException must be thrown for null value")]
		public void WordsCountLimitTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.WordsCountLimit, BuildExcerptsCommand_Accessor.DEFAULT_WORDS_COUNT_LIMIT);
				// valid value
				int expected = 1;
				target.WordsCountLimit = expected;
				Assert.AreEqual(expected, target.WordsCountLimit);
				// invalid value
				target.WordsCountLimit = -1;
			}
		}

		[TestMethod]
		public void StartPassageIdTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.StartPassageId, BuildExcerptsCommand_Accessor.DEFAULT_START_PASSAGE_ID);
				// valid value
				int expected = 1;
				target.StartPassageId = expected;
				Assert.AreEqual(expected, target.StartPassageId);
				// valid value
				target.StartPassageId = -1;
			}
		}

		[TestMethod]
		public void HtmlStripModeTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.HtmlStripMode, BuildExcerptsCommand_Accessor.DEFAULT_HTML_STRIP_MODE);
				// valid value
				HtmlStripMode expected = HtmlStripMode.Retain;
				target.HtmlStripMode = expected;
				Assert.AreEqual(expected, target.HtmlStripMode);
			}
		}

		[TestMethod]
		public void PassageBoundaryTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.PassageBoundary, BuildExcerptsCommand_Accessor.DEFAULT_PASSAGE_BOUNDARY);
				// valid value
				PassageBoundary expected = PassageBoundary.Paragraph;
				target.PassageBoundary = expected;
				Assert.AreEqual(expected, target.PassageBoundary);
			}
		}

		[TestMethod]
		public void OptionsTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.Options, BuildExcerptsCommand_Accessor.DEFAULT_OPTIONS);
				// valid value
				BuildExcerptsOptions expected = BuildExcerptsOptions.OrderByWeight;
				target.Options = expected;
				Assert.AreEqual(expected, target.Options);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "ArgumentException must be thrown for null value")]
		public void IndexTest()
		{
			using (ConnectionBase connection = new ConnectionMock())
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				// default value
				Assert.AreEqual(target.Index, null);
				// valid value
				string expected = "test";
				target.Index = expected;
				Assert.AreEqual(expected, target.Index);
				// invalid value
				target.Index = null;
			}
		}

		[TestMethod]
		public void KeywordsTest()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				Assert.IsNotNull(target.Keywords);
				Assert.IsInstanceOfType(target.Keywords, typeof(IList<string>));
			}
		}

		[TestMethod]
		public void DocumentsTest()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				Assert.IsNotNull(target.Documents);
				Assert.IsInstanceOfType(target.Documents, typeof (IList<string>));
			}
		}

		[TestMethod]
		public void CommandInfoTest()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				BuildExcerptsCommand_Accessor accessor = GetCommandAccessor(target);
				Assert.IsNotNull(accessor.CommandInfo);
				Assert.AreEqual(accessor.CommandInfo.Id, ServerCommand.Excerpt);
				Assert.AreEqual(accessor.CommandInfo.Version, BuildExcerptsCommand_Accessor.COMMAND_VERSION);
			}
		} 
		#endregion

		#region Methods
		[TestMethod]
		public void ExecuteTest_EmptyDocuments_ThrowsException()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				connection.SkipHandshake = true;
				connection.SkipDeserializeCommand = true;
				connection.SkipSerializeCommand = true;

				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				target.Index = "test";
				target.Keywords.Add("test");
				Executing.This(target.Execute).Should().Throw<ArgumentException>();
				
				target.Documents.Add("test doc content");
				Executing.This(target.Execute).Should().NotThrow();
			}
		}

		[TestMethod]
		public void ExecuteTest_EmptyKeywords_ThrowsException()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				connection.SkipHandshake = true;
				connection.SkipDeserializeCommand = true;
				connection.SkipSerializeCommand = true;

				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				target.Documents.Add("test doc content");
				target.Index = "test";
				Executing.This(target.Execute).Should().Throw<ArgumentException>();

				target.Keywords.Add("test");
				Executing.This(target.Execute).Should().NotThrow();
			}
		}

		[TestMethod]
		public void ExecuteTest_EmptyIndex_ThrowsException()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				connection.SkipHandshake = true;
				connection.SkipDeserializeCommand = true;
				connection.SkipSerializeCommand = true;

				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				target.Documents.Add("test doc content");
				target.Keywords.Add("test");
				Executing.This(target.Execute).Should().Throw<ArgumentException>();

				target.Index = "test";
				Executing.This(target.Execute).Should().NotThrow();
			}
		}


		[TestMethod]
		public void SerializeRequestTest()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				var accessor = GetCommandAccessor(target);
				ArrayList values = new ArrayList();

				IBinaryWriter writer = new ArrayListWriterMock(values);
				accessor.SerializeRequest(writer);

				Assert.AreEqual(values.Count, 15);
				Assert.AreEqual(values[0], BuildExcerptsCommand_Accessor.MODE);
				Assert.AreEqual(values[1], (int)target.Options);
				Assert.AreEqual(values[2], target.Index);
				// Keywords skipped, will be tested in unit-test for StringList class
				Assert.AreEqual(values[4], target.BeforeMatch);
				Assert.AreEqual(values[5], target.AfterMatch);
				Assert.AreEqual(values[6], target.SnippetsDelimiter);
				Assert.AreEqual(values[7], target.SnippetSizeLimit);
				Assert.AreEqual(values[8], target.WordsAroundKeyword);
				Assert.AreEqual(values[9], target.SnippetsCountLimit);
				Assert.AreEqual(values[10], target.WordsCountLimit);
				Assert.AreEqual(values[11], target.StartPassageId);
				Assert.AreEqual(values[12], target.HtmlStripMode.ToString().ToLowerInvariant());
				Assert.AreEqual(values[13], target.PassageBoundary.ToString().ToLowerInvariant());
				// Documents skipped, for same reason
			}
		}

		[TestMethod]
		[HostType("Moles")]
		public void DeserializeResponseTest()
		{
			using (ConnectionMock connection = new ConnectionMock("test"))
			{
				bool deserializeCalled = false;
				BuildExcerptsCommand target = new BuildExcerptsCommand(connection);
				var accessor = GetCommandAccessor(target);
				IBinaryReader arrayReader = new ArrayListReaderMock(new ArrayList());
				accessor.Result = new MBuildExcerptsCommandResult
              	{
              		DeserializeIBinaryReaderInt32 = (reader, count) => { deserializeCalled = (reader == arrayReader && count == 1); }
              	};
				target.Documents.Add("test");

				accessor.DeserializeResponse(arrayReader);

				Assert.IsTrue(deserializeCalled);
			}
		}

		#endregion

		#endregion

		#region Helper methods
		protected BuildExcerptsCommand_Accessor GetCommandAccessor(BuildExcerptsCommand command)
		{
			PrivateObject po = new PrivateObject(command);
			BuildExcerptsCommand_Accessor accessor = new BuildExcerptsCommand_Accessor(po);
			return accessor;
		}

		#endregion
	}
}
