using WorkflowPlatform.Domain.Entities;

namespace WorkflowPlatform.Application.Documents.SubmitDocument;

public class SubmitDocumentHandler
{
    public void Handle(Document document)
    {
        document.Submit();
    }
}
