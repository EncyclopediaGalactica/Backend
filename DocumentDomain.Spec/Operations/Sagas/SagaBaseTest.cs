namespace DocumentDomain.Spec.Operations.Sagas;

using Contracts;
using DocumentDomain.Operations.Commands;
using DocumentDomain.Operations.Sagas;
using FluentValidation;
using Infrastructure.Database;
using Infrastructure.Mappers;
using Infrastructure.Validators;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class SagaBaseTest : IDisposable
{
    private readonly IValidator<DocumentInput> _addDocumentSagaInputValidator;
    private readonly IDocumentInputMapper _documentInputMapper;
    private readonly IDocumentMapper _documentMapper;
    private readonly DocumentStructureNodeInputValidator _documentStructureNodeInputValidator;
    private readonly IDocumentStructureNodeMapper _documentStructureNodeMapper;
    private IAddDocumentCommand _addDocumentCommand;
    private IAddStructureNodeTreeCommand _addStructureNodeTreeCommand;
    private DbContextOptions<DocumentDomainDbContext> _dbContextOptions;
    private GetDocumentByIdCommand _getDocumentByIdCommand;
    protected AddDocumentSaga AddDocumentSaga;
    private SqliteConnection connection;

    protected SagaBaseTest()
    {
        InitializeDbContext();
        _documentMapper = new DocumentMapper();
        _documentInputMapper = new DocumentInputMapper();
        _addDocumentSagaInputValidator = new AddDocumentSagaInputValidator();
        InitializeAddDocumentCommand();

        _documentStructureNodeMapper = new DocumentStructureNodeMapper();
        _documentStructureNodeInputValidator = new DocumentStructureNodeInputValidator();
        InitialzeAddStructureNodeTreeCommand();

        InitializeGetDocumentByIdCommand();
        AddDocumentSaga = new AddDocumentSaga(
            _addDocumentCommand,
            _addStructureNodeTreeCommand,
            _getDocumentByIdCommand,
            InitializeLogging<AddDocumentSaga>()
        );
    }

    public void Dispose() => connection.Dispose();

    private void InitializeGetDocumentByIdCommand()
    {
        _getDocumentByIdCommand = new GetDocumentByIdCommand(
            _documentMapper,
            _dbContextOptions,
            InitializeLogging<GetDocumentByIdCommand>());
    }

    private void InitialzeAddStructureNodeTreeCommand()
    {
        _addStructureNodeTreeCommand = new AddStructureNodeTreeCommand(
            _documentStructureNodeMapper,
            _dbContextOptions,
            _documentStructureNodeInputValidator,
            InitializeLogging<AddStructureNodeTreeCommand>()
        );
    }

    private void InitializeAddDocumentCommand()
    {
        _addDocumentCommand = new AddDocumentCommand(
            _documentMapper,
            _documentInputMapper,
            _addDocumentSagaInputValidator,
            _dbContextOptions,
            InitializeLogging<AddDocumentCommand>()
        );
    }

    private ILogger<T> InitializeLogging<T>()
    {
        return LoggerFactory.Create(builder => { builder.AddConsole(); }).CreateLogger<T>();
    }

    private void InitializeDbContext()
    {
        connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        _dbContextOptions = new DbContextOptionsBuilder<DocumentDomainDbContext>()
            .UseSqlite(connection)
            .LogTo(Console.WriteLine)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .Options;

        using DocumentDomainDbContext context = new DocumentDomainDbContext(_dbContextOptions);
        context.Database.EnsureCreated();
    }
}