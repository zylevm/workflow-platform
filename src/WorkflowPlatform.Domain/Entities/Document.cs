using WorkflowPlatform.Domain.Enums;

namespace WorkflowPlatform.Domain.Entities;

public class Document
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;
    public DocumentStatus Status { get; private set; }
    public Document(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Document title cannot be empty.", nameof(title));

        Id = Guid.NewGuid();
        Title = title;
        Status = DocumentStatus.Draft;
    }
    public void Submit()
    {
        if (Status != DocumentStatus.Draft)
            throw new InvalidOperationException("Only draft documents can be submitted.");

        Status = DocumentStatus.PendingApproval;
    }
    public void Approve()
    {
        if (Status != DocumentStatus.PendingApproval)
            throw new InvalidOperationException(
                "Only documents pending approval can be approved.");

        Status = DocumentStatus.Approved;
    }
    public void Reject()
    {
        if (Status != DocumentStatus.PendingApproval)
            throw new InvalidOperationException(
                "Only documents pending approval can be rejected.");

        Status = DocumentStatus.Rejected;
    }
}
