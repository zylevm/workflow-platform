using WorkflowPlatform.Application.Documents.Repositories;
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

        var repository = new InMemoryDocumentRepository();
        repository.Save(document);

        var handler = new SubmitDocumentHandler(repository);

        // Act
        handler.Handle(document.Id);

        // Assert
        Assert.Equal(DocumentStatus.PendingApproval, document.Status);
    }
}