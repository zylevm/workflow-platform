using WorkflowPlatform.Domain.Entities;
using WorkflowPlatform.Domain.Enums;

namespace WorkflowPlatform.Domain.Tests;

public class DocumentTests
{
    [Fact]
    public void NewDocument_ShouldHaveDraftStatus()
    {
        // Arrange
        var document = new Document("Test document");

        // Act
        var status = document.Status;

        // Assert
        Assert.Equal(DocumentStatus.Draft, status);
    }

    [Fact]
    public void Submit_ShouldChangeStatusToPendingApproval()
    {
        // Arrange
        var document = new Document("Test document");

        // Act
        document.Submit();

        // Assert
        Assert.Equal(DocumentStatus.PendingApproval, document.Status);
    }

    [Fact]
    public void Approve_DraftDocument_ShouldThrow()
    {
        // Arrange
        var document = new Document("Test document");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => document.Approve());
    }

    [Fact]
    public void Approve_SubmittedDocument_ShouldChangeStatusToApproved()
    {
        // Arrange
        var document = new Document("Test document");

        // Act
        document.Submit();
        document.Approve();

        // Assert
        Assert.Equal(DocumentStatus.Approved, document.Status);
    }

    [Fact]
    public void Reject_SubmittedDocument_ShouldChangeStatusToRejected()
    {
        // Arrange
        var document = new Document("Test document");

        // Act
        document.Submit();
        document.Reject();

        // Assert
        Assert.Equal(DocumentStatus.Rejected, document.Status);
    }
}