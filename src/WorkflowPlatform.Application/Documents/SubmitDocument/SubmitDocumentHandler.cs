using WorkflowPlatform.Application.Documents.Repositories;

namespace WorkflowPlatform.Application.Documents.SubmitDocument;

public class SubmitDocumentHandler
{
    private readonly IDocumentRepository _repository;

    public SubmitDocumentHandler(IDocumentRepository repository)
    {
        _repository = repository;
    }

    public void Handle(Guid documentId)
    {
        var document = _repository.GetById(documentId);

        if (document is null)
        {
            throw new InvalidOperationException("Document not found.");
        }

        document.Submit();

        _repository.Save(document);
    }
}
