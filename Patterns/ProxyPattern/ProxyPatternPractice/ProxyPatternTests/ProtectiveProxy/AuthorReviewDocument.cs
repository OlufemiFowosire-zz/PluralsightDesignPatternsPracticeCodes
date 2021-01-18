﻿using ProtectiveProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProxyPatternTests.ProtectiveProxy
{
    public class AuthorReviewDocument
    {
        [Fact]
        public void ThrowsUnauthorizedExceptionAndDoesNotSetDateReviewed()
        {
            var author = new User { Role = Roles.Author };
            var document = Document.CreateDocument(TestConstants.TEST_DOCUMENT_NAME, TestConstants.TEST_DOCUMENT_CONTENT);

            Assert.Throws<UnauthorizedAccessException>(
                ()=>document.CompleteReview(author)
            );
            Assert.Null(document.DateReviewed);
        }
    }
}
