using WorkflowPlatform.Domain.Entities;

namespace WorkflowPlatform.Application.Documents.Repositories;

public interface IDocumentRepository
{
    Document? GetById(Guid id);

    void Save(Document document);
}