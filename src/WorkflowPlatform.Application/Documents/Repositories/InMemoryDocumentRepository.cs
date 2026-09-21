using WorkflowPlatform.Domain.Entities;

namespace WorkflowPlatform.Application.Documents.Repositories;

public class InMemoryDocumentRepository : IDocumentRepository
{
    private readonly List<Document> _documents = new();

    public Document? GetById(Guid id)
    {
        return _documents.FirstOrDefault(x => x.Id == id);
    }

    public void Save(Document document)
    {
        _documents.Add(document);
    }
}