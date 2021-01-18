using ProtectiveProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProxyPatternTests.ProtectiveProxy
{
    public class AuthorAddDocument
    {
        [Fact]
        public void AddsDocumentToAuthoredDocuments()
        {
            var author = new User { Role = Roles.Author };
            author.AddDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            Assert.Contains(author.AuthoredDocuments,
                document => document.Name == TestConstants.TEST_DOCUMENT_NAME
            );
        }
    }
}
