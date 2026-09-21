using WorkflowPlatform.Application.Documents.SubmitDocument;
using WorkflowPlatform.Domain.Entities;
using WorkflowPlatform.Domain.Enums;

namespace WorkflowPlatform.Application.Tests;

public class SubmitDocumentHandlerTests
{
    [Fact]
    public void Handle_ShouldSubmitDocument()
    {
        // Arrange
        var document = new Document("Test document");
        var handler = new SubmitDocumentHandler();

        // Act
        handler.Handle(document);

        // Assert
        Assert.Equal(DocumentStatus.PendingApproval, document.Status);
    }
}